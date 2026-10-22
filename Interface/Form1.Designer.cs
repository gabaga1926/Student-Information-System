namespace Interface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtContactNumber = new TextBox();
            txtProgram = new TextBox();
            txtYearLevel = new TextBox();
            txtFullName = new TextBox();
            txtStudentId = new TextBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvStudents = new DataGridView();
            cboGender = new ComboBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboGender);
            groupBox1.Controls.Add(txtContactNumber);
            groupBox1.Controls.Add(txtProgram);
            groupBox1.Controls.Add(txtYearLevel);
            groupBox1.Controls.Add(txtFullName);
            groupBox1.Controls.Add(txtStudentId);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 553);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Student Details";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(169, 354);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.PlaceholderText = "e.g. 09171234567";
            txtContactNumber.Size = new Size(225, 31);
            txtContactNumber.TabIndex = 24;
            // 
            // txtProgram
            // 
            txtProgram.Location = new Point(169, 294);
            txtProgram.Name = "txtProgram";
            txtProgram.PlaceholderText = "e.g. BSCS";
            txtProgram.Size = new Size(225, 31);
            txtProgram.TabIndex = 23;
            txtProgram.TextChanged += textBox3_TextChanged;
            // 
            // txtYearLevel
            // 
            txtYearLevel.Location = new Point(169, 234);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.PlaceholderText = "1 - 4";
            txtYearLevel.Size = new Size(225, 31);
            txtYearLevel.TabIndex = 22;
            txtYearLevel.TextChanged += textBox2_TextChanged;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(169, 114);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Enter full name";
            txtFullName.Size = new Size(225, 31);
            txtFullName.TabIndex = 21;
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(169, 54);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.PlaceholderText = "e.g. 2024-0001";
            txtStudentId.Size = new Size(225, 31);
            txtStudentId.TabIndex = 20;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(277, 403);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(79, 29);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(192, 403);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(79, 29);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(107, 403);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(79, 29);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(22, 403);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(79, 29);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 360);
            label6.Name = "label6";
            label6.Size = new Size(143, 25);
            label6.TabIndex = 5;
            label6.Text = "Contact Number";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 300);
            label5.Name = "label5";
            label5.Size = new Size(81, 25);
            label5.TabIndex = 4;
            label5.Text = "Program";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 240);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 3;
            label4.Text = "Year level";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 180);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 2;
            label3.Text = "Gender";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 120);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 1;
            label2.Text = "Full name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 60);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 0;
            label1.Text = "Student ID";
            label1.Click += label1_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(400, 0);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(882, 553);
            dgvStudents.TabIndex = 1;
            dgvStudents.CellContentClick += dvgStudents_CellContentClick;
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cboGender.Location = new Point(169, 172);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(225, 33);
            cboGender.TabIndex = 25;
            cboGender.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 553);
            Controls.Add(dgvStudents);
            Controls.Add(groupBox1);
            MinimumSize = new Size(1300, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Information System";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvStudents;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label6;
        private Button btnAdd;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private TextBox txtStudentId;
        private TextBox txtContactNumber;
        private TextBox txtProgram;
        private TextBox txtYearLevel;
        private TextBox txtFullName;
        private ComboBox cboGender;
    }
}
