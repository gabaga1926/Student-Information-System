using System.Data;

public partial class Form1 : Form
{
    // Control names: share these with your teammates
    TextBox txtStudentId = new(), txtFullName = new(), txtYearLevel = new(),
            txtProgram = new(), txtContactNumber = new();
    ComboBox cboGender = new();
    Button btnAdd = new(), btnUpdate = new(), btnDelete = new(), btnClear = new();
    DataGridView dgvStudents = new();



    public Form1()
    {
        Text = "Student Information System";
        Size = new Size(1300, 600);
        MinimumSize = new Size(1300, 600);
        StartPosition = FormStartPosition.CenterScreen;


        BuildLayout();
        Load += Form1_Load;
    }

    void BuildLayout()
    {
        var group = new GroupBox
        {
            Text = "Student Details",
            Dock = DockStyle.Left,
            Width = 400,
            
            Padding = new Padding(10)
        };

        var fields = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            ColumnCount = 2,
            RowCount = 6,
            AutoSize = true
        };
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
        cboGender.Items.AddRange(new object[] { "Male", "Female", "Other" });

        AddRow(fields, 0, "Student ID", txtStudentId);
        AddRow(fields, 1, "Full name", txtFullName);
        AddRow(fields, 2, "Gender", cboGender);
        AddRow(fields, 3, "Year level", txtYearLevel);
        AddRow(fields, 4, "Program", txtProgram);
        AddRow(fields, 5, "Contact number", txtContactNumber);

        var buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            Padding = new Padding(0, 15, 0, 0)
        };
        foreach (var (btn, text) in new[] {
            (btnAdd, "Add"), (btnUpdate, "Update"),
            (btnDelete, "Delete"), (btnClear, "Clear") })
        {
            btn.Text = text;
            btn.Width = 70;
            btn.Height = 30;
            buttons.Controls.Add(btn);
        }

        group.Controls.Add(buttons);
        group.Controls.Add(fields);

        dgvStudents.Dock = DockStyle.Fill;
        dgvStudents.ReadOnly = true;
        dgvStudents.AllowUserToAddRows = false;
        dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStudents.MultiSelect = false;
        dgvStudents.RowHeadersVisible = false;

        Controls.Add(dgvStudents);
        Controls.Add(group);

        txtStudentId.PlaceholderText = "e.g. 2024-0001";
        txtFullName.PlaceholderText = "Enter full name";
        txtYearLevel.PlaceholderText = "1 - 4";
        txtProgram.PlaceholderText = "e.g. BSCS";
        txtContactNumber.PlaceholderText = "e.g. 09171234567";
    }

    static void AddRow(TableLayoutPanel panel, int row, string label, Control input)
    {
        panel.Controls.Add(new Label
        {
            Text = label,
            Anchor = AnchorStyles.Left,
            AutoSize = true
        }, 0, row);
        input.Dock = DockStyle.Fill;
        input.Margin = new Padding(3, 6, 3, 6);
        panel.Controls.Add(input, 1, row);
    }

    // Temporary fake data until the MySQL connection is ready
    void Form1_Load(object? sender, EventArgs e)
    {
        var table = new DataTable();
        table.Columns.Add("Student_ID");
        table.Columns.Add("Full_Name");
        table.Columns.Add("Gender");
        table.Columns.Add("Year_Level", typeof(int));
        table.Columns.Add("Program");
        table.Columns.Add("Contact_Number");

        dgvStudents.DataSource = table;
    }
}