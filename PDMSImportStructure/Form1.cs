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

namespace PDMSImportStructure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string MDTfile = string.Empty;
        public static string MDTfilePath = string.Empty;
        public static string MDTfileName = string.Empty;
        public static string MDTfileNameWOExt = string.Empty;

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            GetStart();
            GenerateMacro.GenerateMacrofile();
        }

        public void GetStart()
        {
            MDTfile = textBox1.Text;
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
            majorPropertiesDataGridView.DataSource = ReadMDT.PropertiesList;
            //foreach (var item in ReadMDT.PropertiesList)
            //{
            //    dataGridView1.Rows.Add(
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
            label2.Text = "Number of member : " + ReadMDT.PropertiesList.Count.ToString();

            int k = 1;
            listBox3.Items.Clear();
            foreach (var item in ReadMDT.SectionList)
            {
                listBox3.Items.Add(k++ + " " + item);
            }
            label4.Text = "Number of used section : " + ReadMDT.SectionList.Count.ToString();

            int l = 1;
            listBox4.Items.Clear();
            foreach (var item in ReadMDT.MaterialGradeList)
            {
                listBox4.Items.Add(l++ + " " + item);
            }
            label5.Text = "Number of used material grade : " + ReadMDT.MaterialGradeList.Count.ToString();

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
            this.textBox1.Text = file.FileName;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
