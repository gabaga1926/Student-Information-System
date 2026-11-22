namespace Interface
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            backbtnform1 = new Button();
            btntoexcl = new Button();
            btntopdf = new Button();
            btnloadchart = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            formsPlot3 = new ScottPlot.WinForms.FormsPlot();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // backbtnform1
            // 
            backbtnform1.BackColor = Color.FromArgb(15, 15, 15);
            backbtnform1.Font = new Font("Consolas", 10.2F);
            backbtnform1.ForeColor = Color.White;
            backbtnform1.Location = new Point(12, 12);
            backbtnform1.Name = "backbtnform1";
            backbtnform1.Size = new Size(124, 37);
            backbtnform1.TabIndex = 1;
            backbtnform1.Text = "Back";
            backbtnform1.UseVisualStyleBackColor = false;
            // 
            // btntoexcl
            // 
            btntoexcl.BackColor = Color.FromArgb(15, 15, 15);
            btntoexcl.Font = new Font("Consolas", 10.2F);
            btntoexcl.ForeColor = Color.White;
            btntoexcl.Location = new Point(12, 76);
            btntoexcl.Name = "btntoexcl";
            btntoexcl.Size = new Size(155, 54);
            btntoexcl.TabIndex = 2;
            btntoexcl.Text = "Export to EXCEL";
            btntoexcl.UseVisualStyleBackColor = false;
            // 
            // btntopdf
            // 
            btntopdf.BackColor = Color.FromArgb(15, 15, 15);
            btntopdf.Font = new Font("Consolas", 10.2F);
            btntopdf.ForeColor = Color.White;
            btntopdf.Location = new Point(12, 136);
            btntopdf.Name = "btntopdf";
            btntopdf.Size = new Size(155, 54);
            btntopdf.TabIndex = 3;
            btntopdf.Text = "Export to PDF";
            btntopdf.UseVisualStyleBackColor = false;
            // 
            // btnloadchart
            // 
            btnloadchart.BackColor = Color.FromArgb(15, 15, 15);
            btnloadchart.Font = new Font("Consolas", 10.2F);
            btnloadchart.ForeColor = Color.White;
            btnloadchart.Location = new Point(538, 378);
            btnloadchart.Name = "btnloadchart";
            btnloadchart.Size = new Size(362, 58);
            btnloadchart.TabIndex = 4;
            btnloadchart.Text = "Load Charts";
            btnloadchart.UseVisualStyleBackColor = false;
            btnloadchart.Click += button2_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(888, 465);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(8, 8);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(formsPlot1, 0, 0);
            tableLayoutPanel2.Controls.Add(formsPlot2, 1, 0);
            tableLayoutPanel2.Controls.Add(formsPlot3, 2, 0);
            tableLayoutPanel2.Location = new Point(188, 12);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(1048, 349);
            tableLayoutPanel2.TabIndex = 6;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Font = new Font("Consolas", 10.2F, FontStyle.Bold);
            formsPlot1.ForeColor = Color.White;
            formsPlot1.Location = new Point(3, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(343, 346);
            formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Font = new Font("Consolas", 10.2F, FontStyle.Bold);
            formsPlot2.ForeColor = Color.White;
            formsPlot2.Location = new Point(352, 3);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(343, 346);
            formsPlot2.TabIndex = 1;
            // 
            // formsPlot3
            // 
            formsPlot3.Dock = DockStyle.Fill;
            formsPlot3.Font = new Font("Consolas", 10.2F, FontStyle.Bold);
            formsPlot3.ForeColor = Color.White;
            formsPlot3.Location = new Point(701, 3);
            formsPlot3.Name = "formsPlot3";
            formsPlot3.Size = new Size(344, 346);
            formsPlot3.TabIndex = 2;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(1261, 453);
            Controls.Add(btnloadchart);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btntopdf);
            Controls.Add(btntoexcl);
            Controls.Add(backbtnform1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Graphs";
            Load += Form2_Load;
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button backbtnform1;
        private Button btntoexcl;
        private Button btntopdf;
        private Button btnloadchart;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ScottPlot.WinForms.FormsPlot formsPlotprogram;
        private ScottPlot.WinForms.FormsPlot formsPlotgender;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private ScottPlot.WinForms.FormsPlot formsPlot3;
    }
}