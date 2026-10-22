using System.Data;

namespace Interface;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Load += Form1_Load;
    }

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

    private void dvgStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}