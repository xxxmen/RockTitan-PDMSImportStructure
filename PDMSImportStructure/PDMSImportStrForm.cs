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
        public static string MDTfilePathWNameWOExt = string.Empty;
        public static bool GrdFileExists = false;

        #region Events

        private void PDMSImportStrForm_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void FilePathtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            SelectFile();
            LoadData();
        }

        private void BtnViewFile_Click(object sender, EventArgs e)
        {
            ViewFile();
        }
        
        private void BtnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void BtnSendtoPDMS_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void FormTopMostcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FormTopMostcheckBoxCheckedChanged();
        }

        private void MembDataGridViewcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MembDataGridViewcheckBoxCheckedChanged();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Methods

        void FormLoad()
        {
            //顯示版本於Form title
            this.Text = "PDMS Import Structure  V" + Application.ProductVersion;

            MemberDatalabel.Text = " ";
            SectionListlabel.Text = " ";
            MaterialGradeListlabel.Text = " ";
            LengthUnitlabel.Text = " ";

            if (ReadMDT.PropertiesList.Count == 0)
            {
                BtnSendtoPDMS.Enabled = false;
                BtnExport.Enabled = false;
            }
        }

        void SelectFile()
        {
            //FolderBrowserDialog path = new FolderBrowserDialog();
            //path.ShowDialog();
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "MDT files (*.MDT)|*.MDT|All files (*.*)|*.*"
            };
            file.ShowDialog();
            this.FilePathtextBox.Text = file.FileName;
        }

        void ViewFile()
        {
            System.Diagnostics.Process.Start("explorer.exe", (FilePathtextBox.Text == null || FilePathtextBox.Text == string.Empty) ? @".MDT" : Path.GetDirectoryName(FilePathtextBox.Text));
        }

        void LoadData()
        {
            BtnExport.Enabled = false;
            BtnSendtoPDMS.Enabled = false;

            //背景執行
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (sender_obj, obj) =>
            {
                MDTfile = FilePathtextBox.Text;
                if (File.Exists(MDTfile) != true | MDTfile.Contains(".MDT") != true)
                {
                    MessageBox.Show("No MDT file selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MDTfilePath = Path.GetDirectoryName(MDTfile);
                MDTfileName = Path.GetFileName(MDTfile);
                MDTfileNameWOExt = Path.GetFileNameWithoutExtension(MDTfile);
                MDTfilePathWNameWOExt = MDTfilePath + ((MDTfilePath == null) || (MDTfilePath == string.Empty) ? string.Empty : @"\") + MDTfileNameWOExt;

                //先讀Grd file, 再讀MDT file, 如果Grd file不存在, 則在執行ReadMDT.ReadMDTfile時依member data自動產生(call方法)
                string GrdMessage = string.Empty;
                if (File.Exists(MDTfilePathWNameWOExt + ".Grd"))
                {
                    GrdFileExists = true;
                    ReadGrd.ReadGrdfile(MDTfilePathWNameWOExt + ".Grd", out GrdMessage);
                }
                else
                {
                    GrdFileExists = false;
                    var result = MessageBox.Show("Warning! Grd file is not exist, the program will generate grid lines automatically.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    //TODO
                }

                ReadMDT.ReadMDTfile(MDTfile, out string MDTMessage);

                if (MDTMessage.ToUpper().Contains("ERROR"))
                {
                    MessageBox.Show(MDTMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (GrdMessage.ToUpper().Contains("ERROR"))
                {
                    MessageBox.Show(GrdMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            };

            bw.RunWorkerCompleted += (sender_obj, obj) =>
            {
                if (ReadMDT.PropertiesList.Count != 0)
                {
                    WriteListtoListBox();
                    LengthUnitlabel.Text = string.Format("Length Unit : {0}", ReadMDT.MDTLengthUnit);
                    BtnExport.Enabled = true;
                    MessageBox.Show("Successfully load all data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            bw.RunWorkerAsync();
        }

        void WriteListtoListBox()
        {
            MemberDatalabel.Text = "Number of members : " + ReadMDT.PropertiesList.Count.ToString();

            int k = 1;
            SectionlistBox.Items.Clear();
            foreach (var item in ReadMDT.SectionList)
            {
                SectionlistBox.Items.Add(k++ + " " + item);
            }
            SectionListlabel.Text = "Number of used sections : " + ReadMDT.SectionList.Count.ToString();

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

        void WriteDatatoDataGridView()
        {
            majorPropertiesDataGridView.DataSource = null; //清除前一次DataGridView中資料

            //為了解決無法排序問題, 重做BindingCollection物件
            BindingCollection<MajorProperties> objList = new BindingCollection<MajorProperties>();
            foreach (MajorProperties item in ReadMDT.PropertiesList)
            {
                objList.Add(item);
            }
            majorPropertiesDataGridView.DataSource = objList; //填入List資料
        }

        void MembDataGridViewcheckBoxCheckedChanged()
        {
            //先後順序有學問!!
            if (MembDataGridViewcheckBox.Checked)
            {
                WriteDatatoDataGridView();

                this.MinimumSize = new System.Drawing.Size(800, 600);
                this.ClientSize = new System.Drawing.Size(784, 561);

                this.MemberDatalabel.Location = new System.Drawing.Point(12, 357);

                this.SecListgroupBox.Size = new System.Drawing.Size(202, 117);
                this.MatGradeListgroupBox.Size = new System.Drawing.Size(202, 117);
                this.SectionlistBox.Size = new System.Drawing.Size(190, 95);
                this.MaterialGradelistBox.Size = new System.Drawing.Size(190, 95);

                this.SecListgroupBox.Location = new System.Drawing.Point(12, 379);
                this.MatGradeListgroupBox.Location = new System.Drawing.Point(237, 379);
                this.SectionlistBox.Location = new System.Drawing.Point(6, 15);
                this.MaterialGradelistBox.Location = new System.Drawing.Point(6, 15);

                this.MainDatagroupBox.Visible = true;
            }
            else
            {
                this.MainDatagroupBox.Visible = false;

                this.MinimumSize = new System.Drawing.Size(570, 330);
                this.ClientSize = new System.Drawing.Size(554, 291);

                this.MemberDatalabel.Location = new System.Drawing.Point(12, 57);

                this.SecListgroupBox.Size = new System.Drawing.Size(202, 145);
                this.MatGradeListgroupBox.Size = new System.Drawing.Size(202, 145);
                this.SectionlistBox.Size = new System.Drawing.Size(190, 121);
                this.MaterialGradelistBox.Size = new System.Drawing.Size(190, 121);

                this.SecListgroupBox.Location = new System.Drawing.Point(12, 83);
                this.MatGradeListgroupBox.Location = new System.Drawing.Point(237, 83);
                this.SectionlistBox.Location = new System.Drawing.Point(6, 17);
                this.MaterialGradelistBox.Location = new System.Drawing.Point(6, 17);
            }
        }

        void Export()
        {
            GenerateMacro.GenerateMacrofile();

            if (File.Exists(MDTfilePathWNameWOExt + ".MAC") == true)
            {
                MessageBox.Show("Completed export macro file. Please send to PDMS.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnSendtoPDMS.Enabled = true;
            }
        }

        void Send()
        {
            //TODO
            MessageBox.Show("Successfully upload to PDMS.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnSendtoPDMS.Enabled = false;
        }

        void FormTopMostcheckBoxCheckedChanged()
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

        #endregion


    }
}
