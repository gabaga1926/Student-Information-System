using MySqlConnector;
using StudentSystem.Mobile.Models;

namespace StudentSystem.Mobile.Data;

public static class StudentReadRepository
{
    private const string SelectColumns = "`Student_ID`, `First_Name`, `Last_Name`, `Full_Name`, `Gender`, `Year_Level`, `Program`, `Contact_Number`";

    public static async Task<List<Student>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        const string query = $"SELECT {SelectColumns} FROM `v_Student_Active` ORDER BY `Student_ID`";
        return await ReadStudentsAsync(query, null, cancellationToken);
    }

    public static async Task<List<Student>> SearchAsync(string term, CancellationToken cancellationToken = default)
    {
        const string query = $"SELECT {SelectColumns} FROM `v_Student_Active` WHERE `Student_ID` LIKE @term OR `Full_Name` LIKE @term ORDER BY `Student_ID`";
        return await ReadStudentsAsync(query, command => command.Parameters.AddWithValue("@term", $"%{term.Trim()}%"), cancellationToken);
    }

    public static async Task<Dictionary<string, int>> CountByProgramAsync(CancellationToken cancellationToken = default)
    {
        const string query = "SELECT `Program`, COUNT(*) AS `Total` FROM `v_Student_Active` GROUP BY `Program` ORDER BY `Program`";
        var counts = new Dictionary<string, int>(StringComparer.Ordinal);

        await using var connection = await OpenAsync(cancellationToken);
        await using var command = new MySqlCommand(query, connection);
        await using var reader = await ExecuteReaderAsync(command, cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            counts[reader["Program"]?.ToString() ?? string.Empty] = reader.GetInt32("Total");
        }

        return counts;
    }

    public static async Task<Dictionary<string, int>> CountByGenderAsync(CancellationToken cancellationToken = default)
    {
        const string query = "SELECT `Gender`, COUNT(*) AS `Total` FROM `v_Student_Active` GROUP BY `Gender` ORDER BY `Gender`";
        var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        await using var connection = await OpenAsync(cancellationToken);
        await using var command = new MySqlCommand(query, connection);
        await using var reader = await ExecuteReaderAsync(command, cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            counts[reader["Gender"]?.ToString() ?? string.Empty] = reader.GetInt32("Total");
        }

        return counts;
    }

    public static async Task<Dictionary<(int Year, string Gender), int>> CountByYearAndGenderAsync(CancellationToken cancellationToken = default)
    {
        const string query = "SELECT `Year_Level`, `Gender`, COUNT(*) AS `Total` FROM `v_Student_Active` GROUP BY `Year_Level`, `Gender` ORDER BY `Year_Level`, `Gender`";
        var counts = new Dictionary<(int Year, string Gender), int>();

        await using var connection = await OpenAsync(cancellationToken);
        await using var command = new MySqlCommand(query, connection);
        await using var reader = await ExecuteReaderAsync(command, cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            counts[(reader.GetInt32("Year_Level"), reader["Gender"]?.ToString() ?? string.Empty)] = reader.GetInt32("Total");
        }

        return counts;
    }

    private static async Task<MySqlConnection> OpenAsync(CancellationToken cancellationToken)
    {
        var connection = new MySqlConnection(Secrets.ConnectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }

    private static async Task<MySqlDataReader> ExecuteReaderAsync(MySqlCommand command, CancellationToken cancellationToken)
    {
        return await command.ExecuteReaderAsync(cancellationToken);
    }

    private static async Task<List<Student>> ReadStudentsAsync(string query, Action<MySqlCommand>? configure, CancellationToken cancellationToken)
    {
        var students = new List<Student>();
        await using var connection = await OpenAsync(cancellationToken);
        await using var command = new MySqlCommand(query, connection);
        configure?.Invoke(command);
        await using var reader = await ExecuteReaderAsync(command, cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            students.Add(new Student
            {
                StudentId = reader["Student_ID"]?.ToString() ?? string.Empty,
                FirstName = reader["First_Name"]?.ToString() ?? string.Empty,
                LastName = reader["Last_Name"]?.ToString() ?? string.Empty,
                FullName = reader["Full_Name"]?.ToString() ?? string.Empty,
                Gender = reader["Gender"]?.ToString() ?? string.Empty,
                YearLevel = reader.GetInt32("Year_Level"),
                Program = reader["Program"]?.ToString() ?? string.Empty,
                ContactNumber = reader["Contact_Number"] == DBNull.Value ? null : reader["Contact_Number"]?.ToString() ?? string.Empty
            });
        }

        return students;
    }
}
