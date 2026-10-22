using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Interface;

public static class StudentRepository
{
    private const string DefaultConnectionName = "StudentDb";
    private static readonly string[] AllowedGenders = ["Male", "Female", "Other"];
    private static readonly string[] CandidateTableNames = ["Student", "students", "student", "student_information", "student_information_system"];

    public static string GetConnectionString()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory != null)
        {
            var appSettingsPath = Path.Combine(directory.FullName, "appsettings.json");
            if (File.Exists(appSettingsPath))
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(directory.FullName)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                    .Build();

                var connectionString = configuration.GetConnectionString(DefaultConnectionName);
                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    return connectionString;
                }

                throw new InvalidOperationException($"Connection string '{DefaultConnectionName}' was not found in appsettings.json.");
            }

            directory = directory.Parent;
        }

        throw new FileNotFoundException("appsettings.json was not found. Place the file in the project root or output folder.");
    }

    public static bool IsAllowedGender(string gender)
    {
        return AllowedGenders.Contains(gender, StringComparer.OrdinalIgnoreCase);
    }

    public static string GetStudentTableName()
    {
        using var connection = new MySqlConnection(GetConnectionString());
        connection.Open();

        foreach (var tableName in CandidateTableNames)
        {
            using var checkCommand = new MySqlCommand(
                "SELECT 1 FROM information_schema.tables WHERE table_schema = DATABASE() AND table_name = @tableName LIMIT 1",
                connection);
            checkCommand.Parameters.AddWithValue("@tableName", tableName);

            var exists = checkCommand.ExecuteScalar();
            if (exists != null)
            {
                return tableName;
            }
        }

        throw new InvalidOperationException("No student table was found in the configured database. Verify the table name matches Student_ID, Full_Name, Gender, Year_Level, and Program.");
    }

    public static bool HasColumn(string columnName)
    {
        using var connection = new MySqlConnection(GetConnectionString());
        connection.Open();

        using var command = new MySqlCommand(
            "SELECT 1 FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = @tableName AND column_name = @columnName LIMIT 1",
            connection);

        command.Parameters.AddWithValue("@tableName", GetStudentTableName());
        command.Parameters.AddWithValue("@columnName", columnName);

        var exists = command.ExecuteScalar();
        return exists != null;
    }

    public static void EnsureSchema()
    {
        GetStudentTableName();
    }

    public static DataTable LoadStudents()
    {
        var tableName = GetStudentTableName();
        var hasContactColumn = HasColumn("Contact_Number");

        var table = new DataTable();
        table.Columns.Add("Student_ID");
        table.Columns.Add("Full_Name");
        table.Columns.Add("Gender");
        table.Columns.Add("Year_Level", typeof(int));
        table.Columns.Add("Program");

        if (hasContactColumn)
        {
            table.Columns.Add("Contact_Number");
        }

        using var connection = new MySqlConnection(GetConnectionString());
        connection.Open();

        var columns = new[] { "Student_ID", "Full_Name", "Gender", "Year_Level", "Program" };
        if (hasContactColumn)
        {
            columns = columns.Concat(new[] { "Contact_Number" }).ToArray();
        }

        var selectQuery = $"SELECT {string.Join(", ", columns.Select(c => $"`{c}`"))} FROM `{tableName}` ORDER BY Student_ID";

        using var command = new MySqlCommand(selectQuery, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var row = table.NewRow();
            row["Student_ID"] = reader["Student_ID"]?.ToString() ?? string.Empty;
            row["Full_Name"] = reader["Full_Name"]?.ToString() ?? string.Empty;
            row["Gender"] = reader["Gender"]?.ToString() ?? string.Empty;
            row["Year_Level"] = reader.GetInt32("Year_Level");
            row["Program"] = reader["Program"]?.ToString() ?? string.Empty;
            if (hasContactColumn)
            {
                row["Contact_Number"] = reader["Contact_Number"]?.ToString() ?? string.Empty;
            }

            table.Rows.Add(row);
        }

        return table;
    }

    public static void AddStudent(Student student)
    {
        var tableName = GetStudentTableName();
        var hasContactColumn = HasColumn("Contact_Number");
        var columns = new List<string> { "Student_ID", "Full_Name", "Gender", "Year_Level", "Program" };
        var parameters = new List<string> { "@Student_ID", "@Full_Name", "@Gender", "@Year_Level", "@Program" };

        if (hasContactColumn)
        {
            columns.Add("Contact_Number");
            parameters.Add("@Contact_Number");
        }

        using var connection = new MySqlConnection(GetConnectionString());
        connection.Open();

        using var command = new MySqlCommand($"INSERT INTO `{tableName}` ({string.Join(", ", columns.Select(c => $"`{c}`"))}) VALUES ({string.Join(", ", parameters)})", connection);

        command.Parameters.AddWithValue("@Student_ID", student.StudentId.Trim());
        command.Parameters.AddWithValue("@Full_Name", student.FullName.Trim());
        command.Parameters.AddWithValue("@Gender", student.Gender);
        command.Parameters.AddWithValue("@Year_Level", student.YearLevel);
        command.Parameters.AddWithValue("@Program", student.Program.Trim());
        if (hasContactColumn)
        {
            command.Parameters.AddWithValue("@Contact_Number", string.IsNullOrWhiteSpace(student.ContactNumber) ? DBNull.Value : student.ContactNumber.Trim());
        }

        command.ExecuteNonQuery();
    }

    public static void UpdateStudent(Student student)
    {
        var tableName = GetStudentTableName();
        var hasContactColumn = HasColumn("Contact_Number");

        using var connection = new MySqlConnection(GetConnectionString());
        connection.Open();

        var setClauses = new List<string>
        {
            "`Full_Name` = @Full_Name",
            "`Gender` = @Gender",
            "`Year_Level` = @Year_Level",
            "`Program` = @Program"
        };

        if (hasContactColumn)
        {
            setClauses.Add("`Contact_Number` = @Contact_Number");
        }

        using var command = new MySqlCommand($"UPDATE `{tableName}` SET {string.Join(", ", setClauses)} WHERE `Student_ID` = @Student_ID", connection);

        command.Parameters.AddWithValue("@Student_ID", student.StudentId.Trim());
        command.Parameters.AddWithValue("@Full_Name", student.FullName.Trim());
        command.Parameters.AddWithValue("@Gender", student.Gender);
        command.Parameters.AddWithValue("@Year_Level", student.YearLevel);
        command.Parameters.AddWithValue("@Program", student.Program.Trim());
        if (hasContactColumn)
        {
            command.Parameters.AddWithValue("@Contact_Number", string.IsNullOrWhiteSpace(student.ContactNumber) ? DBNull.Value : student.ContactNumber.Trim());
        }

        var rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException("Student ID was not found for update.");
        }
    }

    public static void DeleteStudent(string studentId)
    {
        var tableName = GetStudentTableName();
        using var connection = new MySqlConnection(GetConnectionString());
        connection.Open();

        using var command = new MySqlCommand($"DELETE FROM `{tableName}` WHERE `Student_ID` = @Student_ID", connection);
        command.Parameters.AddWithValue("@Student_ID", studentId.Trim());

        var rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new InvalidOperationException("Student ID was not found for deletion.");
        }
    }
    public static DataTable SearchStudents(string searchText)
    {
        var tableName = GetStudentTableName();
        var hasContactColumn = HasColumn("Contact_Number");

        var table = new DataTable();
        table.Columns.Add("Student_ID");
        table.Columns.Add("Full_Name");
        table.Columns.Add("Gender");
        table.Columns.Add("Year_Level", typeof(int));
        table.Columns.Add("Program");
        if (hasContactColumn)
        {
            table.Columns.Add("Contact_Number");
        }

        using var connection = new MySqlConnection(GetConnectionString());
        connection.Open();

        var columns = new List<string> { "`Student_ID`", "`Full_Name`", "`Gender`", "`Year_Level`", "`Program`" };
        if (hasContactColumn)
        {
            columns.Add("`Contact_Number`");
        }

        var query = $@"
        SELECT {string.Join(", ", columns)}
        FROM `{tableName}`
        WHERE `Student_ID` LIKE @term OR `Full_Name` LIKE @term
        ORDER BY `Student_ID`;";

        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@term", $"%{searchText.Trim()}%");

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var row = table.NewRow();
            row["Student_ID"] = reader["Student_ID"]?.ToString() ?? string.Empty;
            row["Full_Name"] = reader["Full_Name"]?.ToString() ?? string.Empty;
            row["Gender"] = reader["Gender"]?.ToString() ?? string.Empty;
            row["Year_Level"] = reader.GetInt32("Year_Level");
            row["Program"] = reader["Program"]?.ToString() ?? string.Empty;
            if (hasContactColumn)
            {
                row["Contact_Number"] = reader["Contact_Number"]?.ToString() ?? string.Empty;
            }
            table.Rows.Add(row);
        }

        return table;
    }
}