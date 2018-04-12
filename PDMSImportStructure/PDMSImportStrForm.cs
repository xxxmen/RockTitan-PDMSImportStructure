using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using SortableBindingList;

namespace PDMSImportStructure
{
    public partial class PDMSImportStrForm : Form
    {
        public PDMSImportStrForm()
        {
            InitializeComponent();
        }

        public static string MDTfile = string.Empty;
        public static string MDTfilePath = string.Empty;
        public static string MDTfileName = string.Empty;
        public static string MDTfileNameWOExt = string.Empty;

        private void BtnLoadData_Click(object sender, EventArgs e)
        {
            GetStart();
        }

        public void GetStart()
        {
            MDTfile = filePathtextBox.Text;
            MDTfilePath = Path.GetDirectoryName(MDTfile);
            MDTfileName = Path.GetFileName(MDTfile);
            MDTfileNameWOExt = Path.GetFileNameWithoutExtension(MDTfile);
            if (File.Exists(MDTfile) != true | MDTfile.Contains(".MDT") != true)
            {
                MessageBox.Show("No MDT file selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ReadMDT.ReadMDTfile(MDTfile, out string Message);

            if (Message.ToUpper().Contains("ERROR"))
            {
                MessageBox.Show(Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //majorPropertiesDataGridView.Rows.Clear(); //Binding時無法清除
            //majorPropertiesDataGridView.Rows.Add(i);
            majorPropertiesDataGridView.DataSource = null; //清除前一次DataGridView中資料
            //為了解決無法排序問題, 重做BindingCollection物件
            BindingCollection<MajorProperties> objList = new BindingCollection<MajorProperties>();
            foreach (MajorProperties item in ReadMDT.PropertiesList)
            {
                objList.Add(item);
            }
            majorPropertiesDataGridView.DataSource = objList; //填入List資料
            //以迴圈方式一筆一筆填入資料效能差, 已用上述替代
            //foreach (var item in ReadMDT.PropertiesList)
            //{
            //    majorPropertiesDataGridView.Rows.Add(
            //        item.countNo,
            //        item.ID,
            //        item.Section,
            //        item.Material,
            //        item.MaterialGrade,
            //        item.MemberLength,
            //        item.StartX,
            //        item.StartY,
            //        item.StartZ,
            //        item.EndX,
            //        item.EndY,
            //        item.EndZ,
            //        item.Type,
            //        item.SP,
            //        item.IT,
            //        item.CP,
            //        item.Reflect,
            //        item.OvX,
            //        item.OvY,
            //        item.OvZ,
            //        item.ReleaseS,
            //        item.ReleaseE,
            //        item.Grid
            //        );
            //    //dataGridView1.Rows.Add();
            //    //DataGridViewCell cell = dataGridView1.Rows[i - 1].Cells[0];
            //    //cell.Value = item.ID;
            //}
            MemberDatalabel.Text = "Number of member : " + ReadMDT.PropertiesList.Count.ToString();

            int k = 1;
            SectionlistBox.Items.Clear();
            foreach (var item in ReadMDT.SectionList)
            {
                SectionlistBox.Items.Add(k++ + " " + item);
            }
            SectionListlabel.Text = "Number of used section : " + ReadMDT.SectionList.Count.ToString();

            int l = 1;
            MaterialGradelistBox.Items.Clear();
            foreach (var item in ReadMDT.MaterialGradeList)
            {
                MaterialGradelistBox.Items.Add(l++ + " " + item);
            }
            MaterialGradeListlabel.Text = "Number of used material grade : " + ReadMDT.MaterialGradeList.Count.ToString();

            //TODO
            //Form2 form2 = new Form2();
            //form2.Show();
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog path = new FolderBrowserDialog();
            //path.ShowDialog();
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "MDT files (*.MDT)|*.MDT|All files (*.*)|*.*"
            };
            file.ShowDialog();
            this.filePathtextBox.Text = file.FileName;
        }

        private void BtnViewFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(filePathtextBox.Text));
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            GenerateMacro.GenerateMacrofile();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
