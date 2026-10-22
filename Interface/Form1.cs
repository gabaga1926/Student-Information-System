using System.Data;
using MySql.Data.MySqlClient;

namespace Interface;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Load += Form1_Load;
        btnClear.Click += btnClear_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        try
        {
            StudentRepository.EnsureSchema();
            LoadStudents();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unable to connect to the database.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadStudents()
    {
        try
        {
            var table = StudentRepository.LoadStudents();
            dgvStudents.DataSource = table;
            dgvStudents.ClearSelection();
            UpdateActionButtons();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unable to load student records.\n\n{ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ApplySearchFilter()
    {
        try
        {
            var searchText = txtSearch.Text.Trim();
            dgvStudents.DataSource = string.IsNullOrWhiteSpace(searchText)
                ? StudentRepository.LoadStudents()
                : StudentRepository.SearchStudents(searchText);
            dgvStudents.ClearSelection();
            UpdateActionButtons();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unable to search student records.\n\n{ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool IsEditMode()
    {
        return !string.IsNullOrWhiteSpace(txtStudentId.Text.Trim());
    }

    private void UpdateActionButtons()
    {
        var isEditMode = IsEditMode();
        btnAdd.Enabled = !isEditMode;
        btnClear.Enabled = !isEditMode;
        btnUpdate.Enabled = isEditMode;
        btnDelete.Enabled = isEditMode;
    }

    private void ClearForm()
    {
        txtStudentId.Clear();
        txtFullName.Clear();
        cboGender.SelectedIndex = -1;
        txtYearLevel.Clear();
        txtProgram.Clear();
        txtContactNumber.Clear();
        dgvStudents.ClearSelection();
        UpdateActionButtons();
        txtStudentId.Focus();
    }

    private Student? BuildStudentFromForm(bool validateStudentId = true)
    {
        var studentId = txtStudentId.Text.Trim();
        if (validateStudentId && string.IsNullOrWhiteSpace(studentId))
        {
            ShowValidationError("Student ID is required.");
            return null;
        }

        if (validateStudentId && studentId.Length < 3)
        {
            ShowValidationError("Student ID must be at least 3 characters long.");
            return null;
        }

        var fullName = txtFullName.Text.Trim();
        if (string.IsNullOrWhiteSpace(fullName))
        {
            ShowValidationError("Full name is required.");
            return null;
        }

        var selectedGender = cboGender.SelectedItem?.ToString();
        if (string.IsNullOrWhiteSpace(selectedGender) || !StudentRepository.IsAllowedGender(selectedGender))
        {
            ShowValidationError("Please select a valid gender: Male, Female, or Other.");
            return null;
        }

        if (!int.TryParse(txtYearLevel.Text.Trim(), out var yearLevel) || yearLevel < 1 || yearLevel > 8)
        {
            ShowValidationError("Year level must be a number from 1 to 8.");
            return null;
        }

        var program = txtProgram.Text.Trim();
        if (string.IsNullOrWhiteSpace(program))
        {
            ShowValidationError("Program is required.");
            return null;
        }

        var contactNumber = txtContactNumber.Text.Trim();
        if (StudentRepository.HasColumn("Contact_Number"))
        {
            if (string.IsNullOrWhiteSpace(contactNumber))
            {
                ShowValidationError("Contact number is required.");
                return null;
            }

            if (!contactNumber.All(char.IsDigit))
            {
                ShowValidationError("Contact number must contain exactly 11 digits only.");
                return null;
            }

            if (contactNumber.Length != 11)
            {
                ShowValidationError("Contact number must contain exactly 11 digits only.");
                return null;
            }
        }

        return new Student
        {
            StudentId = studentId,
            FullName = fullName,
            Gender = selectedGender,
            YearLevel = yearLevel,
            Program = program,
            ContactNumber = contactNumber
        };
    }

    private void ShowValidationError(string message)
    {
        MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }

    private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            var student = BuildStudentFromForm();
            if (student is null)
            {
                return;
            }

            StudentRepository.AddStudent(student);
            MessageBox.Show("Student record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStudents();
            ClearForm();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show($"Database error while adding the student.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unable to add student.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            var student = BuildStudentFromForm();
            if (student is null)
            {
                return;
            }

            StudentRepository.UpdateStudent(student);
            MessageBox.Show("Student record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStudents();
            ClearForm();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show($"Database error while updating the student.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unable to update student.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var studentId = txtStudentId.Text.Trim();
        if (string.IsNullOrWhiteSpace(studentId))
        {
            ShowValidationError("Select a student or enter a Student ID to delete.");
            return;
        }

        var confirm = MessageBox.Show($"Delete student '{studentId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes)
        {
            return;
        }

        try
        {
            StudentRepository.DeleteStudent(studentId);
            MessageBox.Show("Student record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStudents();
            ClearForm();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show($"Database error while deleting the student.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unable to delete student.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox6_TextChanged(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        ApplySearchFilter();
    }

    private void dvgStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        var row = dgvStudents.Rows[e.RowIndex];
        txtStudentId.Text = row.Cells["Student_ID"].Value?.ToString() ?? string.Empty;
        txtFullName.Text = row.Cells["Full_Name"].Value?.ToString() ?? string.Empty;
        var gender = row.Cells["Gender"].Value?.ToString() ?? string.Empty;
        cboGender.SelectedIndex = cboGender.Items.IndexOf(gender);
        txtYearLevel.Text = row.Cells["Year_Level"].Value?.ToString() ?? string.Empty;
        txtProgram.Text = row.Cells["Program"].Value?.ToString() ?? string.Empty;

        if (dgvStudents.Columns.Contains("Contact_Number"))
        {
            txtContactNumber.Text = row.Cells["Contact_Number"].Value?.ToString() ?? string.Empty;
        }
        else
        {
            txtContactNumber.Clear();
        }

        UpdateActionButtons();
    }

    private void Form1_Load_1(object sender, EventArgs e)
    {

    }
}