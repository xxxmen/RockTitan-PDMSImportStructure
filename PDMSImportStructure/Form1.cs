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
using System.Text.RegularExpressions;

namespace PDMSImportStructure
{
    public partial class Form1 : Form
    {
        public static ReadMDTs MatchList = new ReadMDTs();
        List<string> IDList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            GetStart();

            ReadMDT.MatCodeList.Clear();
            ReadMDT.MaterialList.Clear();
            ReadMDT.MaterialGradeList.Clear();
            ReadMDT.SectionList.Clear();
            ReadMDT.PropertiesList.Clear();
        }

        public void GetStart()
        {
            string MDTfile = textBox1.Text;
            if (File.Exists(MDTfile) != true | MDTfile.Contains(".MDT") != true)
            {
                MessageBox.Show("No MDT file selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string MDTfilePath = Path.GetDirectoryName(MDTfile);
            string MDTfileName = Path.GetFileName(MDTfile);

            using (StreamReader sr = new StreamReader(MDTfile))
            {
                string content = sr.ReadToEnd();
                ReadMDT.ReadMDTfile(content, out string Message);

                if (Message.ToUpper().Contains("ERROR"))
                {
                    MessageBox.Show(Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                int i = 1;
                listBox1.Items.Clear();
                foreach (var item in ReadMDT.PropertiesList)
                {
                    listBox1.Items.Add(i++ + " " + item.ID + " " + item.Section);
                    //dataGridView1.Rows.Add();
                }
                label2.Text = "Number of member : " + ReadMDT.PropertiesList.Count.ToString();

                int j = 1;
                listBox3.Items.Clear();
                foreach (var item in ReadMDT.SectionList)
                {
                    listBox3.Items.Add(j++ + " " + item);
                }
                label4.Text = "Number of used section : " + ReadMDT.SectionList.Count.ToString();

                int k = 1;
                listBox4.Items.Clear();
                foreach (var item in ReadMDT.MaterialGradeList)
                {
                    listBox4.Items.Add(k++ + " " + item);
                }
                label5.Text = "Number of used material grade : " + ReadMDT.MaterialGradeList.Count.ToString();

                sr.Close();
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
            this.textBox1.Text = file.FileName;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
