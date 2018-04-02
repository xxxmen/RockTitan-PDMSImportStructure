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
                }
                else
                {
                    label2.Text = "Number of matches(MDL Data) : " + ReadMDT.PropertiesList.Count.ToString();
                    listBox1.Items.Clear();
                    int i = 1;
                    foreach (var item in ReadMDT.PropertiesList)
                    {
                        listBox1.Items.Add(i++ + " " + item.ID + " " + item.Section);
                    }
                }
                
                //listBox1.Items.Clear();
                //listBox1.Items.Add(i++ + sep + ID + sep + MaterialCode + sep + SectionCode + sep + StartX + sep + StartY + sep + StartZ + sep + EndX + sep + EndY + sep + EndZ + sep + Grid);
                //label2.Text = "Number of matches(MDL Data) : " + label2Text;

                //listBox2.Items.Clear();
                //listBox2.Items.Add(j++ + sep + compID + sep + Type + sep + SP + sep
                //        + IT + sep + CP + sep + Reflect + sep + OvX + sep + OvY + sep + OvZ + sep
                //        + ReleaseS + sep + ReleaseSNo + sep + ReleaseE + sep + ReleaseENo + sep + Section);
                //label3.Text = "Number of matches(PhyMemb Data) : " + rgxPhy.Matches(content).Count.ToString();

                //label4.Text = "Number of matches(Material Data) : " + rgxMat.Matches(content).Count.ToString();
                //listBox3.Items.Clear();
                //listBox3.Items.Add(k++ + sep + ArrMat[0, 0] + sep + ArrMat[0, 1] + sep + ArrMat[0, 2]);

                //listBox4.Items.Clear();
                //listBox4.Items.Add(l++ + sep + ArrMatType[0, 0] + sep + ArrMatType[0, 1]);
                //label5.Text = "Number of matches(Material Code List) : " + rgxMatCode.Matches(content).Count.ToString();

                //listBox5.Items.Clear();
                //listBox5.Items.Add(m++ + sep + ArrSecList[0, 0] + sep + ArrSecList[0, 1]);
                //label6.Text = "Number of matches(Section Data) : " + rgxSec.Matches(content).Count.ToString();

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
