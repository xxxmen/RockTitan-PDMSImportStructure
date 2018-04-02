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
            this.components = new System.ComponentModel.Container();
            this.BtnConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.BtnSelectFile = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCloseForm1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reflectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ovXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ovYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ovZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialGradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.majorPropertiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.majorPropertiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnConvert
            // 
            this.BtnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvert.Location = new System.Drawing.Point(1050, 615);
            this.BtnConvert.Name = "BtnConvert";
            this.BtnConvert.Size = new System.Drawing.Size(80, 28);
            this.BtnConvert.TabIndex = 0;
            this.BtnConvert.Text = "Convert";
            this.BtnConvert.UseVisualStyleBackColor = true;
            this.BtnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input File :";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(74, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(590, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "C:\\Users\\RockTitan\\Desktop\\C# Practice\\MDT test\\CIMAS-CV-141-14R001.MDT";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(140, 244);
            this.listBox1.TabIndex = 3;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(172, 66);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(152, 244);
            this.listBox2.TabIndex = 4;
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Location = new System.Drawing.Point(670, 8);
            this.BtnSelectFile.Name = "BtnSelectFile";
            this.BtnSelectFile.Size = new System.Drawing.Size(25, 21);
            this.BtnSelectFile.TabIndex = 5;
            this.BtnSelectFile.Text = "...";
            this.BtnSelectFile.UseVisualStyleBackColor = true;
            this.BtnSelectFile.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(12, 339);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(196, 244);
            this.listBox3.TabIndex = 6;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 12;
            this.listBox4.Location = new System.Drawing.Point(231, 339);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(201, 244);
            this.listBox4.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 586);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(8, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 586);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(8, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = " ";
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 12;
            this.listBox5.Location = new System.Drawing.Point(458, 339);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(189, 244);
            this.listBox5.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(456, 586);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = " ";
            // 
            // BtnCloseForm1
            // 
            this.BtnCloseForm1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCloseForm1.Location = new System.Drawing.Point(1136, 615);
            this.BtnCloseForm1.Name = "BtnCloseForm1";
            this.BtnCloseForm1.Size = new System.Drawing.Size(80, 28);
            this.BtnCloseForm1.TabIndex = 14;
            this.BtnCloseForm1.Text = "Close";
            this.BtnCloseForm1.UseVisualStyleBackColor = true;
            this.BtnCloseForm1.Click += new System.EventHandler(this.Close_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(14, 620);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(652, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.startXDataGridViewTextBoxColumn,
            this.startYDataGridViewTextBoxColumn,
            this.startZDataGridViewTextBoxColumn,
            this.endXDataGridViewTextBoxColumn,
            this.endYDataGridViewTextBoxColumn,
            this.endZDataGridViewTextBoxColumn,
            this.gridDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.sPDataGridViewTextBoxColumn,
            this.iTDataGridViewTextBoxColumn,
            this.cPDataGridViewTextBoxColumn,
            this.reflectDataGridViewTextBoxColumn,
            this.ovXDataGridViewTextBoxColumn,
            this.ovYDataGridViewTextBoxColumn,
            this.ovZDataGridViewTextBoxColumn,
            this.releaseSDataGridViewTextBoxColumn,
            this.releaseEDataGridViewTextBoxColumn,
            this.sectionDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.materialGradeDataGridViewTextBoxColumn});
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.majorPropertiesBindingSource, "ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "Null"));
            this.dataGridView1.DataSource = this.majorPropertiesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(670, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(542, 517);
            this.dataGridView1.TabIndex = 16;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 42;
            // 
            // startXDataGridViewTextBoxColumn
            // 
            this.startXDataGridViewTextBoxColumn.DataPropertyName = "StartX";
            this.startXDataGridViewTextBoxColumn.HeaderText = "StartX";
            this.startXDataGridViewTextBoxColumn.Name = "startXDataGridViewTextBoxColumn";
            this.startXDataGridViewTextBoxColumn.Width = 59;
            // 
            // startYDataGridViewTextBoxColumn
            // 
            this.startYDataGridViewTextBoxColumn.DataPropertyName = "StartY";
            this.startYDataGridViewTextBoxColumn.HeaderText = "StartY";
            this.startYDataGridViewTextBoxColumn.Name = "startYDataGridViewTextBoxColumn";
            this.startYDataGridViewTextBoxColumn.Width = 59;
            // 
            // startZDataGridViewTextBoxColumn
            // 
            this.startZDataGridViewTextBoxColumn.DataPropertyName = "StartZ";
            this.startZDataGridViewTextBoxColumn.HeaderText = "StartZ";
            this.startZDataGridViewTextBoxColumn.Name = "startZDataGridViewTextBoxColumn";
            this.startZDataGridViewTextBoxColumn.Width = 58;
            // 
            // endXDataGridViewTextBoxColumn
            // 
            this.endXDataGridViewTextBoxColumn.DataPropertyName = "EndX";
            this.endXDataGridViewTextBoxColumn.HeaderText = "EndX";
            this.endXDataGridViewTextBoxColumn.Name = "endXDataGridViewTextBoxColumn";
            this.endXDataGridViewTextBoxColumn.Width = 57;
            // 
            // endYDataGridViewTextBoxColumn
            // 
            this.endYDataGridViewTextBoxColumn.DataPropertyName = "EndY";
            this.endYDataGridViewTextBoxColumn.HeaderText = "EndY";
            this.endYDataGridViewTextBoxColumn.Name = "endYDataGridViewTextBoxColumn";
            this.endYDataGridViewTextBoxColumn.Width = 57;
            // 
            // endZDataGridViewTextBoxColumn
            // 
            this.endZDataGridViewTextBoxColumn.DataPropertyName = "EndZ";
            this.endZDataGridViewTextBoxColumn.HeaderText = "EndZ";
            this.endZDataGridViewTextBoxColumn.Name = "endZDataGridViewTextBoxColumn";
            this.endZDataGridViewTextBoxColumn.Width = 56;
            // 
            // gridDataGridViewTextBoxColumn
            // 
            this.gridDataGridViewTextBoxColumn.DataPropertyName = "Grid";
            this.gridDataGridViewTextBoxColumn.HeaderText = "Grid";
            this.gridDataGridViewTextBoxColumn.Name = "gridDataGridViewTextBoxColumn";
            this.gridDataGridViewTextBoxColumn.Width = 51;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Width = 54;
            // 
            // sPDataGridViewTextBoxColumn
            // 
            this.sPDataGridViewTextBoxColumn.DataPropertyName = "SP";
            this.sPDataGridViewTextBoxColumn.HeaderText = "SP";
            this.sPDataGridViewTextBoxColumn.Name = "sPDataGridViewTextBoxColumn";
            this.sPDataGridViewTextBoxColumn.Width = 42;
            // 
            // iTDataGridViewTextBoxColumn
            // 
            this.iTDataGridViewTextBoxColumn.DataPropertyName = "IT";
            this.iTDataGridViewTextBoxColumn.HeaderText = "IT";
            this.iTDataGridViewTextBoxColumn.Name = "iTDataGridViewTextBoxColumn";
            this.iTDataGridViewTextBoxColumn.Width = 41;
            // 
            // cPDataGridViewTextBoxColumn
            // 
            this.cPDataGridViewTextBoxColumn.DataPropertyName = "CP";
            this.cPDataGridViewTextBoxColumn.HeaderText = "CP";
            this.cPDataGridViewTextBoxColumn.Name = "cPDataGridViewTextBoxColumn";
            this.cPDataGridViewTextBoxColumn.Width = 44;
            // 
            // reflectDataGridViewTextBoxColumn
            // 
            this.reflectDataGridViewTextBoxColumn.DataPropertyName = "Reflect";
            this.reflectDataGridViewTextBoxColumn.HeaderText = "Reflect";
            this.reflectDataGridViewTextBoxColumn.Name = "reflectDataGridViewTextBoxColumn";
            this.reflectDataGridViewTextBoxColumn.Width = 63;
            // 
            // ovXDataGridViewTextBoxColumn
            // 
            this.ovXDataGridViewTextBoxColumn.DataPropertyName = "OvX";
            this.ovXDataGridViewTextBoxColumn.HeaderText = "OvX";
            this.ovXDataGridViewTextBoxColumn.Name = "ovXDataGridViewTextBoxColumn";
            this.ovXDataGridViewTextBoxColumn.Width = 52;
            // 
            // ovYDataGridViewTextBoxColumn
            // 
            this.ovYDataGridViewTextBoxColumn.DataPropertyName = "OvY";
            this.ovYDataGridViewTextBoxColumn.HeaderText = "OvY";
            this.ovYDataGridViewTextBoxColumn.Name = "ovYDataGridViewTextBoxColumn";
            this.ovYDataGridViewTextBoxColumn.Width = 52;
            // 
            // ovZDataGridViewTextBoxColumn
            // 
            this.ovZDataGridViewTextBoxColumn.DataPropertyName = "OvZ";
            this.ovZDataGridViewTextBoxColumn.HeaderText = "OvZ";
            this.ovZDataGridViewTextBoxColumn.Name = "ovZDataGridViewTextBoxColumn";
            this.ovZDataGridViewTextBoxColumn.Width = 51;
            // 
            // releaseSDataGridViewTextBoxColumn
            // 
            this.releaseSDataGridViewTextBoxColumn.DataPropertyName = "ReleaseS";
            this.releaseSDataGridViewTextBoxColumn.HeaderText = "ReleaseS";
            this.releaseSDataGridViewTextBoxColumn.Name = "releaseSDataGridViewTextBoxColumn";
            this.releaseSDataGridViewTextBoxColumn.Width = 71;
            // 
            // releaseEDataGridViewTextBoxColumn
            // 
            this.releaseEDataGridViewTextBoxColumn.DataPropertyName = "ReleaseE";
            this.releaseEDataGridViewTextBoxColumn.HeaderText = "ReleaseE";
            this.releaseEDataGridViewTextBoxColumn.Name = "releaseEDataGridViewTextBoxColumn";
            this.releaseEDataGridViewTextBoxColumn.Width = 72;
            // 
            // sectionDataGridViewTextBoxColumn
            // 
            this.sectionDataGridViewTextBoxColumn.DataPropertyName = "Section";
            this.sectionDataGridViewTextBoxColumn.HeaderText = "Section";
            this.sectionDataGridViewTextBoxColumn.Name = "sectionDataGridViewTextBoxColumn";
            this.sectionDataGridViewTextBoxColumn.Width = 64;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.Width = 68;
            // 
            // materialGradeDataGridViewTextBoxColumn
            // 
            this.materialGradeDataGridViewTextBoxColumn.DataPropertyName = "MaterialGrade";
            this.materialGradeDataGridViewTextBoxColumn.HeaderText = "MaterialGrade";
            this.materialGradeDataGridViewTextBoxColumn.Name = "materialGradeDataGridViewTextBoxColumn";
            this.materialGradeDataGridViewTextBoxColumn.Width = 96;
            // 
            // majorPropertiesBindingSource
            // 
            this.majorPropertiesBindingSource.DataSource = typeof(PDMSImportStructure.MajorProperties);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 655);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnCloseForm1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.BtnSelectFile);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConvert);
            this.Name = "Form1";
            this.Text = "PDMS Import Structure V1.0";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.majorPropertiesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button BtnSelectFile;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCloseForm1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource majorPropertiesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reflectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ovXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ovYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ovZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialGradeDataGridViewTextBoxColumn;
    }
}

