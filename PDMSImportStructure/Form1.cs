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

        private void button1_Click(object sender, EventArgs e)
        {
            GetStart();
        }

        public void GetStart()
        {
            string MDTfile = textBox1.Text;
            if (File.Exists(MDTfile) != true | MDTfile.Contains(".MDT") != true)
            {
                MessageBox.Show("No MDT file selected.");
                return;
            }

            string MDTfilePath = Path.GetDirectoryName(MDTfile);
            string MDTfileName = Path.GetFileName(MDTfile);

            using (StreamReader sr = new StreamReader(MDTfile))
            {
                string content = sr.ReadToEnd();
                ReadMDT.readMDT(MDTfile, content);

                //listBox1.Items.Clear();
                //listBox1.Items.Add(i++ + sep + ID + sep + MaterialCode + sep + SectionCode + sep + StartX + sep + StartY + sep + StartZ + sep + EndX + sep + EndY + sep + EndZ + sep + Grid);
                //label2.Text = "Number of matches(MDL Data) : " + rgxMDL.Matches(content).Count.ToString();

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

        private void CartesianToPolar_Degrees(double x, double y, out double angle, out double magnitude)
        {
            angle = Math.Atan2(x, y) * 180.0 / Math.PI;
            if (angle < 0) angle += 360;
            magnitude = Math.Sqrt(x * x + y * y);
        }

        private void PolarToCartesian_Degrees(double angle, double magnitude, out double x, out double y)
        {
            double radians = angle * Math.PI / 180.0;
            x = Math.Sin(radians) * magnitude;
            y = Math.Cos(radians) * magnitude;
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog path = new FolderBrowserDialog();
            //path.ShowDialog();
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "MDT files (*.MDT)|*.MDT|All files (*.*)|*.*";
            file.ShowDialog();
            this.textBox1.Text = file.FileName;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
