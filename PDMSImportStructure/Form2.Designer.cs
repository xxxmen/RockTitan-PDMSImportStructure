namespace PDMSImportStructure
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSourceClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.majorPropertiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nodeSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nodeEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reflectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ovXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ovYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ovZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseSNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseENoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compSectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialGradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.majorPropertiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.materialCodeDataGridViewTextBoxColumn,
            this.sectionCodeDataGridViewTextBoxColumn,
            this.startXDataGridViewTextBoxColumn,
            this.startYDataGridViewTextBoxColumn,
            this.startZDataGridViewTextBoxColumn,
            this.endXDataGridViewTextBoxColumn,
            this.endYDataGridViewTextBoxColumn,
            this.endZDataGridViewTextBoxColumn,
            this.gridDataGridViewTextBoxColumn,
            this.compIDDataGridViewTextBoxColumn,
            this.nodeSDataGridViewTextBoxColumn,
            this.nodeEDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.sPDataGridViewTextBoxColumn,
            this.iTDataGridViewTextBoxColumn,
            this.mATDataGridViewTextBoxColumn,
            this.cPDataGridViewTextBoxColumn,
            this.reflectDataGridViewTextBoxColumn,
            this.ovXDataGridViewTextBoxColumn,
            this.ovYDataGridViewTextBoxColumn,
            this.ovZDataGridViewTextBoxColumn,
            this.releaseSDataGridViewTextBoxColumn,
            this.releaseSNoDataGridViewTextBoxColumn,
            this.releaseEDataGridViewTextBoxColumn,
            this.releaseENoDataGridViewTextBoxColumn,
            this.sRDataGridViewTextBoxColumn,
            this.sectionDataGridViewTextBoxColumn,
            this.compSectionDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.materialGradeDataGridViewTextBoxColumn,
            this.memberLengthDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.majorPropertiesBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(757, 445);
            this.dataGridView1.TabIndex = 0;
            // 
            // bindingSourceClassBindingSource
            // 
            this.bindingSourceClassBindingSource.DataSource = typeof(PDMSImportStructure.BindingSourceClass);
            // 
            // majorPropertiesBindingSource
            // 
            this.majorPropertiesBindingSource.DataSource = typeof(PDMSImportStructure.MajorProperties);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // materialCodeDataGridViewTextBoxColumn
            // 
            this.materialCodeDataGridViewTextBoxColumn.DataPropertyName = "MaterialCode";
            this.materialCodeDataGridViewTextBoxColumn.HeaderText = "MaterialCode";
            this.materialCodeDataGridViewTextBoxColumn.Name = "materialCodeDataGridViewTextBoxColumn";
            this.materialCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sectionCodeDataGridViewTextBoxColumn
            // 
            this.sectionCodeDataGridViewTextBoxColumn.DataPropertyName = "SectionCode";
            this.sectionCodeDataGridViewTextBoxColumn.HeaderText = "SectionCode";
            this.sectionCodeDataGridViewTextBoxColumn.Name = "sectionCodeDataGridViewTextBoxColumn";
            this.sectionCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startXDataGridViewTextBoxColumn
            // 
            this.startXDataGridViewTextBoxColumn.DataPropertyName = "StartX";
            this.startXDataGridViewTextBoxColumn.HeaderText = "StartX";
            this.startXDataGridViewTextBoxColumn.Name = "startXDataGridViewTextBoxColumn";
            this.startXDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startYDataGridViewTextBoxColumn
            // 
            this.startYDataGridViewTextBoxColumn.DataPropertyName = "StartY";
            this.startYDataGridViewTextBoxColumn.HeaderText = "StartY";
            this.startYDataGridViewTextBoxColumn.Name = "startYDataGridViewTextBoxColumn";
            this.startYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startZDataGridViewTextBoxColumn
            // 
            this.startZDataGridViewTextBoxColumn.DataPropertyName = "StartZ";
            this.startZDataGridViewTextBoxColumn.HeaderText = "StartZ";
            this.startZDataGridViewTextBoxColumn.Name = "startZDataGridViewTextBoxColumn";
            this.startZDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endXDataGridViewTextBoxColumn
            // 
            this.endXDataGridViewTextBoxColumn.DataPropertyName = "EndX";
            this.endXDataGridViewTextBoxColumn.HeaderText = "EndX";
            this.endXDataGridViewTextBoxColumn.Name = "endXDataGridViewTextBoxColumn";
            this.endXDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endYDataGridViewTextBoxColumn
            // 
            this.endYDataGridViewTextBoxColumn.DataPropertyName = "EndY";
            this.endYDataGridViewTextBoxColumn.HeaderText = "EndY";
            this.endYDataGridViewTextBoxColumn.Name = "endYDataGridViewTextBoxColumn";
            this.endYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endZDataGridViewTextBoxColumn
            // 
            this.endZDataGridViewTextBoxColumn.DataPropertyName = "EndZ";
            this.endZDataGridViewTextBoxColumn.HeaderText = "EndZ";
            this.endZDataGridViewTextBoxColumn.Name = "endZDataGridViewTextBoxColumn";
            this.endZDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gridDataGridViewTextBoxColumn
            // 
            this.gridDataGridViewTextBoxColumn.DataPropertyName = "Grid";
            this.gridDataGridViewTextBoxColumn.HeaderText = "Grid";
            this.gridDataGridViewTextBoxColumn.Name = "gridDataGridViewTextBoxColumn";
            this.gridDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // compIDDataGridViewTextBoxColumn
            // 
            this.compIDDataGridViewTextBoxColumn.DataPropertyName = "CompID";
            this.compIDDataGridViewTextBoxColumn.HeaderText = "CompID";
            this.compIDDataGridViewTextBoxColumn.Name = "compIDDataGridViewTextBoxColumn";
            this.compIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nodeSDataGridViewTextBoxColumn
            // 
            this.nodeSDataGridViewTextBoxColumn.DataPropertyName = "NodeS";
            this.nodeSDataGridViewTextBoxColumn.HeaderText = "NodeS";
            this.nodeSDataGridViewTextBoxColumn.Name = "nodeSDataGridViewTextBoxColumn";
            this.nodeSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nodeEDataGridViewTextBoxColumn
            // 
            this.nodeEDataGridViewTextBoxColumn.DataPropertyName = "NodeE";
            this.nodeEDataGridViewTextBoxColumn.HeaderText = "NodeE";
            this.nodeEDataGridViewTextBoxColumn.Name = "nodeEDataGridViewTextBoxColumn";
            this.nodeEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sPDataGridViewTextBoxColumn
            // 
            this.sPDataGridViewTextBoxColumn.DataPropertyName = "SP";
            this.sPDataGridViewTextBoxColumn.HeaderText = "SP";
            this.sPDataGridViewTextBoxColumn.Name = "sPDataGridViewTextBoxColumn";
            this.sPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iTDataGridViewTextBoxColumn
            // 
            this.iTDataGridViewTextBoxColumn.DataPropertyName = "IT";
            this.iTDataGridViewTextBoxColumn.HeaderText = "IT";
            this.iTDataGridViewTextBoxColumn.Name = "iTDataGridViewTextBoxColumn";
            this.iTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mATDataGridViewTextBoxColumn
            // 
            this.mATDataGridViewTextBoxColumn.DataPropertyName = "MAT";
            this.mATDataGridViewTextBoxColumn.HeaderText = "MAT";
            this.mATDataGridViewTextBoxColumn.Name = "mATDataGridViewTextBoxColumn";
            this.mATDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cPDataGridViewTextBoxColumn
            // 
            this.cPDataGridViewTextBoxColumn.DataPropertyName = "CP";
            this.cPDataGridViewTextBoxColumn.HeaderText = "CP";
            this.cPDataGridViewTextBoxColumn.Name = "cPDataGridViewTextBoxColumn";
            this.cPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // reflectDataGridViewTextBoxColumn
            // 
            this.reflectDataGridViewTextBoxColumn.DataPropertyName = "Reflect";
            this.reflectDataGridViewTextBoxColumn.HeaderText = "Reflect";
            this.reflectDataGridViewTextBoxColumn.Name = "reflectDataGridViewTextBoxColumn";
            this.reflectDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ovXDataGridViewTextBoxColumn
            // 
            this.ovXDataGridViewTextBoxColumn.DataPropertyName = "OvX";
            this.ovXDataGridViewTextBoxColumn.HeaderText = "OvX";
            this.ovXDataGridViewTextBoxColumn.Name = "ovXDataGridViewTextBoxColumn";
            this.ovXDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ovYDataGridViewTextBoxColumn
            // 
            this.ovYDataGridViewTextBoxColumn.DataPropertyName = "OvY";
            this.ovYDataGridViewTextBoxColumn.HeaderText = "OvY";
            this.ovYDataGridViewTextBoxColumn.Name = "ovYDataGridViewTextBoxColumn";
            this.ovYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ovZDataGridViewTextBoxColumn
            // 
            this.ovZDataGridViewTextBoxColumn.DataPropertyName = "OvZ";
            this.ovZDataGridViewTextBoxColumn.HeaderText = "OvZ";
            this.ovZDataGridViewTextBoxColumn.Name = "ovZDataGridViewTextBoxColumn";
            this.ovZDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // releaseSDataGridViewTextBoxColumn
            // 
            this.releaseSDataGridViewTextBoxColumn.DataPropertyName = "ReleaseS";
            this.releaseSDataGridViewTextBoxColumn.HeaderText = "ReleaseS";
            this.releaseSDataGridViewTextBoxColumn.Name = "releaseSDataGridViewTextBoxColumn";
            this.releaseSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // releaseSNoDataGridViewTextBoxColumn
            // 
            this.releaseSNoDataGridViewTextBoxColumn.DataPropertyName = "ReleaseSNo";
            this.releaseSNoDataGridViewTextBoxColumn.HeaderText = "ReleaseSNo";
            this.releaseSNoDataGridViewTextBoxColumn.Name = "releaseSNoDataGridViewTextBoxColumn";
            this.releaseSNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // releaseEDataGridViewTextBoxColumn
            // 
            this.releaseEDataGridViewTextBoxColumn.DataPropertyName = "ReleaseE";
            this.releaseEDataGridViewTextBoxColumn.HeaderText = "ReleaseE";
            this.releaseEDataGridViewTextBoxColumn.Name = "releaseEDataGridViewTextBoxColumn";
            this.releaseEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // releaseENoDataGridViewTextBoxColumn
            // 
            this.releaseENoDataGridViewTextBoxColumn.DataPropertyName = "ReleaseENo";
            this.releaseENoDataGridViewTextBoxColumn.HeaderText = "ReleaseENo";
            this.releaseENoDataGridViewTextBoxColumn.Name = "releaseENoDataGridViewTextBoxColumn";
            this.releaseENoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sRDataGridViewTextBoxColumn
            // 
            this.sRDataGridViewTextBoxColumn.DataPropertyName = "SR";
            this.sRDataGridViewTextBoxColumn.HeaderText = "SR";
            this.sRDataGridViewTextBoxColumn.Name = "sRDataGridViewTextBoxColumn";
            this.sRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sectionDataGridViewTextBoxColumn
            // 
            this.sectionDataGridViewTextBoxColumn.DataPropertyName = "Section";
            this.sectionDataGridViewTextBoxColumn.HeaderText = "Section";
            this.sectionDataGridViewTextBoxColumn.Name = "sectionDataGridViewTextBoxColumn";
            this.sectionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // compSectionDataGridViewTextBoxColumn
            // 
            this.compSectionDataGridViewTextBoxColumn.DataPropertyName = "CompSection";
            this.compSectionDataGridViewTextBoxColumn.HeaderText = "CompSection";
            this.compSectionDataGridViewTextBoxColumn.Name = "compSectionDataGridViewTextBoxColumn";
            this.compSectionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // materialGradeDataGridViewTextBoxColumn
            // 
            this.materialGradeDataGridViewTextBoxColumn.DataPropertyName = "MaterialGrade";
            this.materialGradeDataGridViewTextBoxColumn.HeaderText = "MaterialGrade";
            this.materialGradeDataGridViewTextBoxColumn.Name = "materialGradeDataGridViewTextBoxColumn";
            this.materialGradeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // memberLengthDataGridViewTextBoxColumn
            // 
            this.memberLengthDataGridViewTextBoxColumn.DataPropertyName = "MemberLength";
            this.memberLengthDataGridViewTextBoxColumn.HeaderText = "MemberLength";
            this.memberLengthDataGridViewTextBoxColumn.Name = "memberLengthDataGridViewTextBoxColumn";
            this.memberLengthDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 445);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.majorPropertiesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSourceClassBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectionCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn compIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reflectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ovXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ovYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ovZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseSNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseENoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn compSectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialGradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource majorPropertiesBindingSource;
    }
}