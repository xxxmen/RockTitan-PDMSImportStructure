namespace PDMSImportStructure
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnSelectFile = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnCloseForm1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reflect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OvX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OvY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OvZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnConvert
            // 
            this.BtnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConvert.Location = new System.Drawing.Point(806, 667);
            this.BtnConvert.Name = "BtnConvert";
            this.BtnConvert.Size = new System.Drawing.Size(80, 30);
            this.BtnConvert.TabIndex = 0;
            this.BtnConvert.Text = "Convert";
            this.BtnConvert.UseVisualStyleBackColor = true;
            this.BtnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input File :";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(74, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(590, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "PR-11.MDT";
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelectFile.Location = new System.Drawing.Point(670, 7);
            this.BtnSelectFile.Name = "BtnSelectFile";
            this.BtnSelectFile.Size = new System.Drawing.Size(25, 23);
            this.BtnSelectFile.TabIndex = 5;
            this.BtnSelectFile.Text = "...";
            this.BtnSelectFile.UseVisualStyleBackColor = true;
            this.BtnSelectFile.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(12, 499);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(189, 134);
            this.listBox3.TabIndex = 6;
            // 
            // listBox4
            // 
            this.listBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(231, 499);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(194, 134);
            this.listBox4.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 649);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(228, 649);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = " ";
            // 
            // BtnCloseForm1
            // 
            this.BtnCloseForm1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCloseForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCloseForm1.Location = new System.Drawing.Point(892, 667);
            this.BtnCloseForm1.Name = "BtnCloseForm1";
            this.BtnCloseForm1.Size = new System.Drawing.Size(80, 30);
            this.BtnCloseForm1.TabIndex = 14;
            this.BtnCloseForm1.Text = "Close";
            this.BtnCloseForm1.UseVisualStyleBackColor = true;
            this.BtnCloseForm1.Click += new System.EventHandler(this.Close_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(12, 671);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(652, 25);
            this.progressBar1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountNo,
            this.ID,
            this.Section,
            this.Material,
            this.MaterialGrade,
            this.MemberLength,
            this.StartX,
            this.StartY,
            this.StartZ,
            this.EndX,
            this.EndY,
            this.EndZ,
            this.Type,
            this.SP,
            this.IT,
            this.CP,
            this.Reflect,
            this.OvX,
            this.OvY,
            this.OvZ,
            this.ReleaseS,
            this.ReleaseE,
            this.Grid});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(959, 427);
            this.dataGridView1.TabIndex = 16;
            // 
            // CountNo
            // 
            this.CountNo.FillWeight = 40F;
            this.CountNo.HeaderText = "Count No.";
            this.CountNo.MinimumWidth = 40;
            this.CountNo.Name = "CountNo";
            this.CountNo.ReadOnly = true;
            this.CountNo.Width = 40;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.FillWeight = 40F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 50;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // Section
            // 
            this.Section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Section.FillWeight = 60F;
            this.Section.HeaderText = "Section";
            this.Section.MinimumWidth = 60;
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            this.Section.Width = 68;
            // 
            // Material
            // 
            this.Material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Material.FillWeight = 50F;
            this.Material.HeaderText = "Material";
            this.Material.MinimumWidth = 50;
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Width = 50;
            // 
            // MaterialGrade
            // 
            this.MaterialGrade.FillWeight = 45F;
            this.MaterialGrade.HeaderText = "Grade";
            this.MaterialGrade.MinimumWidth = 45;
            this.MaterialGrade.Name = "MaterialGrade";
            this.MaterialGrade.ReadOnly = true;
            this.MaterialGrade.Width = 45;
            // 
            // MemberLength
            // 
            this.MemberLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemberLength.FillWeight = 40F;
            this.MemberLength.HeaderText = "Length";
            this.MemberLength.MinimumWidth = 40;
            this.MemberLength.Name = "MemberLength";
            this.MemberLength.ReadOnly = true;
            this.MemberLength.Width = 65;
            // 
            // StartX
            // 
            this.StartX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StartX.FillWeight = 40F;
            this.StartX.HeaderText = "StartX";
            this.StartX.MinimumWidth = 40;
            this.StartX.Name = "StartX";
            this.StartX.ReadOnly = true;
            this.StartX.Width = 61;
            // 
            // StartY
            // 
            this.StartY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StartY.FillWeight = 40F;
            this.StartY.HeaderText = "StartY";
            this.StartY.MinimumWidth = 40;
            this.StartY.Name = "StartY";
            this.StartY.ReadOnly = true;
            this.StartY.Width = 61;
            // 
            // StartZ
            // 
            this.StartZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StartZ.FillWeight = 40F;
            this.StartZ.HeaderText = "StartZ";
            this.StartZ.MinimumWidth = 40;
            this.StartZ.Name = "StartZ";
            this.StartZ.ReadOnly = true;
            this.StartZ.Width = 61;
            // 
            // EndX
            // 
            this.EndX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EndX.FillWeight = 40F;
            this.EndX.HeaderText = "EndX";
            this.EndX.MinimumWidth = 40;
            this.EndX.Name = "EndX";
            this.EndX.ReadOnly = true;
            this.EndX.Width = 58;
            // 
            // EndY
            // 
            this.EndY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EndY.FillWeight = 40F;
            this.EndY.HeaderText = "EndY";
            this.EndY.MinimumWidth = 40;
            this.EndY.Name = "EndY";
            this.EndY.ReadOnly = true;
            this.EndY.Width = 58;
            // 
            // EndZ
            // 
            this.EndZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EndZ.FillWeight = 40F;
            this.EndZ.HeaderText = "EndZ";
            this.EndZ.MinimumWidth = 40;
            this.EndZ.Name = "EndZ";
            this.EndZ.ReadOnly = true;
            this.EndZ.Width = 58;
            // 
            // Type
            // 
            this.Type.FillWeight = 30F;
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 38;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 38;
            // 
            // SP
            // 
            this.SP.FillWeight = 30F;
            this.SP.HeaderText = "SP";
            this.SP.MinimumWidth = 30;
            this.SP.Name = "SP";
            this.SP.ReadOnly = true;
            this.SP.Width = 30;
            // 
            // IT
            // 
            this.IT.FillWeight = 30F;
            this.IT.HeaderText = "IT";
            this.IT.MinimumWidth = 30;
            this.IT.Name = "IT";
            this.IT.ReadOnly = true;
            this.IT.Width = 30;
            // 
            // CP
            // 
            this.CP.HeaderText = "CP";
            this.CP.MinimumWidth = 30;
            this.CP.Name = "CP";
            this.CP.ReadOnly = true;
            this.CP.Width = 30;
            // 
            // Reflect
            // 
            this.Reflect.HeaderText = "Reflect";
            this.Reflect.MinimumWidth = 47;
            this.Reflect.Name = "Reflect";
            this.Reflect.ReadOnly = true;
            this.Reflect.Width = 47;
            // 
            // OvX
            // 
            this.OvX.FillWeight = 30F;
            this.OvX.HeaderText = "OvX";
            this.OvX.MinimumWidth = 35;
            this.OvX.Name = "OvX";
            this.OvX.ReadOnly = true;
            this.OvX.Width = 35;
            // 
            // OvY
            // 
            this.OvY.FillWeight = 30F;
            this.OvY.HeaderText = "OvY";
            this.OvY.MinimumWidth = 35;
            this.OvY.Name = "OvY";
            this.OvY.ReadOnly = true;
            this.OvY.Width = 35;
            // 
            // OvZ
            // 
            this.OvZ.FillWeight = 30F;
            this.OvZ.HeaderText = "OvZ";
            this.OvZ.MinimumWidth = 35;
            this.OvZ.Name = "OvZ";
            this.OvZ.ReadOnly = true;
            this.OvZ.Width = 35;
            // 
            // ReleaseS
            // 
            this.ReleaseS.FillWeight = 50F;
            this.ReleaseS.HeaderText = "Release Start";
            this.ReleaseS.MinimumWidth = 50;
            this.ReleaseS.Name = "ReleaseS";
            this.ReleaseS.ReadOnly = true;
            this.ReleaseS.Width = 50;
            // 
            // ReleaseE
            // 
            this.ReleaseE.FillWeight = 50F;
            this.ReleaseE.HeaderText = "Release End";
            this.ReleaseE.MinimumWidth = 50;
            this.ReleaseE.Name = "ReleaseE";
            this.ReleaseE.ReadOnly = true;
            this.ReleaseE.Width = 50;
            // 
            // Grid
            // 
            this.Grid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Grid.FillWeight = 50F;
            this.Grid.HeaderText = "Grid";
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.Width = 51;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnCloseForm1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.BtnSelectFile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConvert);
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "Form1";
            this.Text = "PDMS Import Structure V1.0";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnSelectFile;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnCloseForm1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartX;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartY;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndX;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndY;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn IT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reflect;
        private System.Windows.Forms.DataGridViewTextBoxColumn OvX;
        private System.Windows.Forms.DataGridViewTextBoxColumn OvY;
        private System.Windows.Forms.DataGridViewTextBoxColumn OvZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid;
    }
}

