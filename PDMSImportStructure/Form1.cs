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
            readMDT();
        }

        public void readMDT()
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

                var patternMDLData = @"(?<ID>\d*)\s+:\s+(?<MT>\d+)\s+(?<SEC>\d+)\s+(?<Start_X>-?\d+.\d*)\s+(?<Start_Y>-?\d+.\d*)\s+(?<Start_Z>-?\d+.\d*)\s+(?<End_X>-?\d+.\d*)\s+(?<End_Y>-?\d+.\d*)\s+(?<End_Z>-?\d+.\d*)\s+(?<Grid>[\w\s.]*-[\w\s.]*\n)?";
                var matchcontentMDLData = Regex.Matches(content, patternMDLData);

                var patternPhyMembData = @"(?<compID>\d*)\s+:\s+(?<Node_Start>\d*),?\s+(?<Node_End>\d*)\s+(?<TP>[A-Z]+)\s+(?<SP>[A-Z]+)\s+(?<IT>\d+.\d+)\s+(?<MT>[A-Z]+)+\s+(?<CP>\d+)\s+(?<Reflect>[YN])\s+\[\s*(?<OvX>-?\d.\d+)\s+(?<OvY>-?\d.\d+)\s+(?<OvZ>-?\d.\d+)\s*\]\s+\[(?<Release_Start>[-R]+)\s+(?<Release_Start_NO>\d+)\s*\]\s+\[(?<Release_End>[-R]+)\s+(?<Release_End_NO>\d+)\s*\]\s(?<SR>\d+.\d+)\s+(?<Section>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*)";
                var matchcontentPhyMembData = Regex.Matches(content, patternPhyMembData);

                var patternMatData = @"(?<MatItemNo>\d+)\s+:\s+(?<MatCode>\d+)\s+(?<MatGrade>[A-Z]+[0-9A-Z]*)";
                var matchcontentMatData = Regex.Matches(content, patternMatData);

                var patternMatCodeList = @"\s(?<MatCodeNo>\d+):(?<Material>[A-Za-z]+)[,)]";
                var matchcontentMatCodeList = Regex.Matches(content, patternMatCodeList);

                var patternSectionData = @"(?<SectionItemNo>\d+)\s:\s(?<compSection>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*)";
                var matchcontentSectionData = Regex.Matches(content, patternSectionData);

                string sep = "  ";

                listBox1.Items.Clear();
                int i = 1;
                foreach (Match match in matchcontentMDLData)
                {
                    string ID = match.Groups["ID"].Value;
                    MatchList.Add(new ReadMDT()
                    {
                        ID = match.Groups["ID"].Value,
                        //MaterialCode = match.Groups["MT"].Value,
                        //SectionCode = match.Groups["SEC"].Value
                    });

                    string MaterialCode = match.Groups["MT"].Value;
                    string SectionCode = match.Groups["SEC"].Value;
                    double StartX = double.Parse(match.Groups["Start_X"].Value);
                    double StartY = double.Parse(match.Groups["Start_Y"].Value);
                    double StartZ = double.Parse(match.Groups["Start_Z"].Value);
                    double EndX = double.Parse(match.Groups["End_X"].Value);
                    double EndY = double.Parse(match.Groups["End_Y"].Value);
                    double EndZ = double.Parse(match.Groups["End_Z"].Value);
                    string Grid = match.Groups["Grid"].Value;
                    //listBox1.Items.Add(i++ + sep + ID + sep + MaterialCode + sep + SectionCode + sep + StartX + sep + StartY + sep + StartZ + sep + EndX + sep + EndY + sep + EndZ + sep + Grid);
                    listBox1.Items.Add(MatchList.ToString());
                }
                var rgxMDL = new Regex(patternMDLData);
                label2.Text = "Number of matches(MDL Data) : " + rgxMDL.Matches(content).Count.ToString();


                listBox2.Items.Clear();
                int j = 1;
                foreach (Match match in matchcontentPhyMembData)
                {
                    string compID = match.Groups["compID"].Value; //比對ID使用
                    string NodeS = match.Groups["Node_Start"].Value; //重複暫不使用
                    string NodeE = match.Groups["Node_End"].Value; //重複暫不使用
                    string Type = match.Groups["TP"].Value;
                    string SP = match.Groups["SP"].Value; 
                    double IT = double.Parse(match.Groups["IT"].Value); //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
                    string MT = match.Groups["MT"].Value; //重複暫不使用
                    string CP = match.Groups["CP"].Value; // 1~10
                    string Reflect = match.Groups["Reflect"].Value; // Y/N
                    double OvX = double.Parse(match.Groups["OvX"].Value);
                    double OvY = double.Parse(match.Groups["OvY"].Value);
                    double OvZ = double.Parse(match.Groups["OvZ"].Value);
                    string ReleaseS = match.Groups["Release_Start"].Value;
                    string ReleaseSNo = match.Groups["Release_Start_NO"].Value;
                    string ReleaseE = match.Groups["Release_End"].Value;
                    string ReleaseENo = match.Groups["Release_End_NO"].Value;
                    double SR = double.Parse(match.Groups["SR"].Value); //stress ratio, no use for PDMS
                    string Section = match.Groups["Section"].Value;

                    listBox2.Items.Add(j++ + sep + compID + sep + Type + sep + SP + sep
                        + IT + sep + CP + sep + Reflect + sep + OvX + sep + OvY + sep + OvZ + sep
                        + ReleaseS + sep + ReleaseSNo + sep + ReleaseE + sep + ReleaseENo + sep + Section);
                }
                var rgxPhy = new Regex(patternPhyMembData);
                label3.Text = "Number of matches(PhyMemb Data) : " + rgxPhy.Matches(content).Count.ToString();


                var rgxMat = new Regex(patternMatData);
                label4.Text = "Number of matches(Material Data) : " + rgxMat.Matches(content).Count.ToString();
                listBox3.Items.Clear();
                int k = 1;
                foreach (Match match in matchcontentMatData)
                {
                    string MatItemNo = match.Groups["MatItemNo"].Value;
                    string MatCode = match.Groups["MatCode"].Value;
                    string MatGrade = match.Groups["MatGrade"].Value;

                    string[,] ArrMat = new string[,] { { MatItemNo, MatCode, MatGrade } };

                    listBox3.Items.Add(k++ + sep + ArrMat[0, 0] + sep + ArrMat[0, 1] + sep + ArrMat[0, 2]);
                    //listBox3.Items.Add(k++ + "  " + match.Value);
                    //MessageBox.Show("ArrMat Length : " + ArrMat.Length.ToString());
                }
                

                listBox4.Items.Clear();
                int l = 1;
                foreach (Match match in matchcontentMatCodeList)
                {
                    string MatCodeNo = match.Groups["MatCodeNo"].Value;
                    string Material = match.Groups["Material"].Value;

                    string[,] ArrMatType = new string[,] { { MatCodeNo, Material } };

                    listBox4.Items.Add(l++ + sep + ArrMatType[0, 0] + sep + ArrMatType[0, 1]);
                    //MessageBox.Show("ArrMatType Length : " + ArrMatType.Length.ToString());
                }
                var rgxMatCode = new Regex(patternMatCodeList);
                label5.Text = "Number of matches(Material Code List) : " + rgxMatCode.Matches(content).Count.ToString();


                listBox5.Items.Clear();
                int m = 1;
                foreach (Match match in matchcontentSectionData)
                {
                    string SectionItemNo = match.Groups["SectionItemNo"].Value; //重複暫不使用
                    string compSection = match.Groups["compSection"].Value; //重複暫不使用

                    string[,] ArrSecList = new string[,] { { SectionItemNo, compSection } };

                    listBox5.Items.Add(m++ + sep + ArrSecList[0, 0] + sep + ArrSecList[0, 1]);
                    //MessageBox.Show("ArrSecList Length : " + ArrSecList.Length.ToString());
                }
                var rgxSec = new Regex(patternSectionData);
                label6.Text = "Number of matches(Section Data) : " + rgxSec.Matches(content).Count.ToString();


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
