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

        #region Events

        private void PDMSImportStrForm_Load(object sender, EventArgs e)
        {
            if (ReadMDT.PropertiesList.Count == 0)
            {
                BtnViewData.Enabled = false;
                BtnExport.Enabled = false;
            }
        }

        private void filePathtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
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

            LoadData();
        }

        private void BtnViewFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", (filePathtextBox.Text == null || filePathtextBox.Text == string.Empty) ? @".MDT" : Path.GetDirectoryName(filePathtextBox.Text));
        }

        private void BtnViewData_Click(object sender, EventArgs e)
        {
            WriteDatatoUI();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            GenerateMacro.GenerateMacrofile();
        }

        private void FormTopMostcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FormTopMostcheckBox.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Methods

        void LoadData()
        {
            //背景執行
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (sender_obj, obj) =>
            {
                MDTfile = filePathtextBox.Text;
                if (File.Exists(MDTfile) != true | MDTfile.Contains(".MDT") != true)
                {
                    MessageBox.Show("No MDT file selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MDTfilePath = Path.GetDirectoryName(MDTfile);
                MDTfileName = Path.GetFileName(MDTfile);
                MDTfileNameWOExt = Path.GetFileNameWithoutExtension(MDTfile);

                ReadMDT.ReadMDTfile(MDTfile, out string Message);

                if (Message.ToUpper().Contains("ERROR"))
                {
                    MessageBox.Show(Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            };

            bw.RunWorkerCompleted += (sender_obj, obj) =>
            {
                if (ReadMDT.PropertiesList.Count != 0)
                {
                    BtnViewData.Enabled = true;
                    BtnExport.Enabled = true;
                }
            };

            bw.RunWorkerAsync();
        }

        void WriteDatatoUI()
        {
            majorPropertiesDataGridView.DataSource = null; //清除前一次DataGridView中資料

            //為了解決無法排序問題, 重做BindingCollection物件
            BindingCollection<MajorProperties> objList = new BindingCollection<MajorProperties>();
            foreach (MajorProperties item in ReadMDT.PropertiesList)
            {
                objList.Add(item);
            }
            majorPropertiesDataGridView.DataSource = objList; //填入List資料
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

        #endregion

    }
}
