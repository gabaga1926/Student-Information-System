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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            btntoGraph = new Button();
            lblFirstName = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            cboGender = new ComboBox();
            txtContactNumber = new TextBox();
            txtProgram = new TextBox();
            txtYearLevel = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
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
            lblFirstName = new Label();
            dgvStudents = new DataGridView();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btntoGraph = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btntoGraph);
            groupBox1.Controls.Add(lblFirstName);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(cboGender);
            groupBox1.Controls.Add(txtContactNumber);
            groupBox1.Controls.Add(txtProgram);
            groupBox1.Controls.Add(txtYearLevel);
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
            groupBox1.Font = new Font("Consolas", 10.5F);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(411, 553);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Student Details";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btntoGraph
            // 
            btntoGraph.BackColor = Color.FromArgb(15, 15, 15);
            btntoGraph.Font = new Font("Consolas", 10.5F);
            btntoGraph.ForeColor = Color.White;
            btntoGraph.Location = new Point(122, 506);
            btntoGraph.Name = "btntoGraph";
            btntoGraph.Size = new Size(166, 39);
            btntoGraph.TabIndex = 29;
            btntoGraph.Text = "Graphs";
            btntoGraph.UseVisualStyleBackColor = false;
            btntoGraph.Click += button1_Click_1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Consolas", 10.5F);
            lblFirstName.Location = new Point(20, 180);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(100, 22);
            lblFirstName.TabIndex = 26;
            lblFirstName.Text = "Last name";
            lblFirstName.Click += label7_Click;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(15, 15, 15);
            txtLastName.Font = new Font("Consolas", 10.5F);
            txtLastName.ForeColor = Color.White;
            txtLastName.Location = new Point(169, 174);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Dela Cruz";
            txtLastName.Size = new Size(225, 28);
            txtLastName.TabIndex = 22;
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.FromArgb(15, 15, 15);
            txtFirstName.Font = new Font("Consolas", 10.5F);
            txtFirstName.ForeColor = Color.White;
            txtFirstName.Location = new Point(169, 114);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Juan";
            txtFirstName.Size = new Size(225, 28);
            txtFirstName.TabIndex = 21;
            // 
            // cboGender
            // 
            cboGender.BackColor = Color.White;
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Consolas", 10.5F);
            cboGender.ForeColor = Color.Black;
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cboGender.Location = new Point(169, 232);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(225, 28);
            cboGender.TabIndex = 25;
            cboGender.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(169, 414);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.PlaceholderText = "09935382981";
            txtContactNumber.Size = new Size(225, 28);
            txtContactNumber.TabIndex = 24;
            // 
            // txtProgram
            // 
            txtProgram.Location = new Point(169, 354);
            txtProgram.Name = "txtProgram";
            txtProgram.PlaceholderText = "BS Computer Science";
            txtProgram.Size = new Size(225, 28);
            txtProgram.TabIndex = 23;
            txtProgram.TextChanged += textBox3_TextChanged;
            // 
            // txtYearLevel
            // 
            txtYearLevel.Location = new Point(169, 294);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.PlaceholderText = "2";
            txtYearLevel.Size = new Size(225, 28);
            txtYearLevel.TabIndex = 22;
            txtYearLevel.TextChanged += textBox2_TextChanged;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(169, 114);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Juan";
            txtFirstName.Size = new Size(225, 31);
            txtFirstName.TabIndex = 21;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(169, 174);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Dela Cruz";
            txtLastName.Size = new Size(225, 31);
            txtLastName.TabIndex = 22;
            // 
            // txtStudentId
            // 
            txtStudentId.BackColor = Color.FromArgb(15, 15, 15);
            txtStudentId.Font = new Font("Consolas", 10.5F);
            txtStudentId.ForeColor = Color.White;
            txtStudentId.Location = new Point(169, 54);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.PlaceholderText = "2025-01-0001";
            txtStudentId.Size = new Size(225, 28);
            txtStudentId.TabIndex = 20;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(277, 463);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(79, 37);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(192, 463);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(79, 37);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(107, 463);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(79, 37);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(22, 463);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(79, 37);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 420);
            label6.Name = "label6";
            label6.Size = new Size(150, 22);
            label6.TabIndex = 5;
            label6.Text = "Contact Number";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 360);
            label5.Name = "label5";
            label5.Size = new Size(80, 22);
            label5.TabIndex = 4;
            label5.Text = "Program";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 300);
            label4.Name = "label4";
            label4.Size = new Size(110, 22);
            label4.TabIndex = 3;
            label4.Text = "Year level";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 240);
            label3.Name = "label3";
            label3.Size = new Size(70, 22);
            label3.TabIndex = 2;
            label3.Text = "Gender";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 10.5F);
            label2.Location = new Point(22, 114);
            label2.Name = "label2";
            label2.Size = new Size(110, 22);
            label2.TabIndex = 1;
            label2.Text = "First name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 10.5F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(20, 60);
            label1.Name = "label1";
            label1.Size = new Size(110, 22);
            label1.TabIndex = 0;
            label1.Text = "Student ID";
            label1.Click += label1_Click;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(20, 180);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(82, 25);
            lblFirstName.TabIndex = 26;
            lblFirstName.Text = "Last name";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.FromArgb(15, 15, 15);
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.GridColor = Color.Black;
            dgvStudents.Location = new Point(411, 51);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(871, 502);
            dgvStudents.TabIndex = 1;
            dgvStudents.CellContentClick += dvgStudents_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(15, 15, 15);
            txtSearch.Dock = DockStyle.Top;
            txtSearch.Font = new Font("Consolas", 10.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(411, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by Student ID or Full Name...";
            txtSearch.Size = new Size(871, 28);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.BackColor = Color.FromArgb(15, 15, 15);
            lblSearch.Dock = DockStyle.Top;
            lblSearch.Font = new Font("Consolas", 10.5F);
            lblSearch.ForeColor = SystemColors.ButtonHighlight;
            lblSearch.Location = new Point(411, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Padding = new Padding(8, 3, 0, 0);
            lblSearch.Size = new Size(871, 23);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Search:";
            // 
            // btntoGraph
            // 
            btntoGraph.Location = new Point(20, 505);
            btntoGraph.Name = "btntoGraph";
            btntoGraph.Size = new Size(166, 39);
            btntoGraph.TabIndex = 29;
            btntoGraph.Text = "Graphs";
            btntoGraph.UseVisualStyleBackColor = true;
            btntoGraph.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1282, 553);
            Controls.Add(dgvStudents);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1300, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Klink Klank System";
            Load += Form1_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private TextBox txtFirstName;
        private ComboBox cboGender;
        private TextBox txtSearch;
        private Label lblSearch;
        private Label lblFirstName;
        private TextBox txtLastName;
        private Button btntoGraph;
    }
}
