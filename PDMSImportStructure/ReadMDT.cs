using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace PDMSImportStructure
{
    public class ReadMDT
    {
        public static string FilePath { get; set; }

        public string ID { get; set; }
        public string MaterialCode { get; set; }
        public string SectionCode { get; set; }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double StartZ { get; set; }
        public double EndX { get; set; }
        public double EndY { get; set; }
        public double EndZ { get; set; }
        public string Grid { get; set; }

        public string compID { get; set; } //比對ID使用
        public string NodeS { get; set; } //重複暫不使用
        public string NodeE { get; set; } //重複暫不使用
        public string Type { get; set; }
        public string SP { get; set; }
        public double IT { get; set; } //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
        public string MT { get; set; } //重複暫不使用
        public string CP { get; set; } // 1~10
        public string Reflect { get; set; } // Y/N
        public double OvX { get; set; }
        public double OvY { get; set; }
        public double OvZ { get; set; }
        public string ReleaseS { get; set; }
        public string ReleaseSNo { get; set; }
        public string ReleaseE { get; set; }
        public string ReleaseENo { get; set; }
        public double SR { get; set; } //stress ratio, no use for PDMS
        public string Section { get; set; }

        public string MatItemNo { get; set; }
        public string MatCode { get; set; }
        public string MatGrade { get; set; }

        public string MatCodeNo { get; set; }
        public string Material { get; set; }

        public string SectionItemNo { get; set; } //重複暫不使用
        public string compSection { get; set; } //重複暫不使用


        public static void readMDT(string MDTfile, string content)
        {
            using (StreamReader sr = new StreamReader(MDTfile))
            {
                content = sr.ReadToEnd();

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
                        MaterialCode = match.Groups["MT"].Value,
                        SectionCode = match.Groups["SEC"].Value
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
                    listBox1.Items.Add(i++ + sep + ID + sep + MaterialCode + sep + SectionCode + sep + StartX + sep + StartY + sep + StartZ + sep + EndX + sep + EndY + sep + EndZ + sep + Grid);
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
                }


                listBox4.Items.Clear();
                int l = 1;
                foreach (Match match in matchcontentMatCodeList)
                {
                    string MatCodeNo = match.Groups["MatCodeNo"].Value;
                    string Material = match.Groups["Material"].Value;

                    string[,] ArrMatType = new string[,] { { MatCodeNo, Material } };

                    listBox4.Items.Add(l++ + sep + ArrMatType[0, 0] + sep + ArrMatType[0, 1]);
                }
                var rgxMatCode = new Regex(patternMatCodeList);
                label5.Text = "Number of matches(Material Code List) : " + rgxMatCode.Matches(content).Count.ToString();


                int m = 1;
                foreach (Match match in matchcontentSectionData)
                {
                    string SectionItemNo = match.Groups["SectionItemNo"].Value; //重複暫不使用
                    string compSection = match.Groups["compSection"].Value; //重複暫不使用

                    string[,] ArrSecList = new string[,] { { SectionItemNo, compSection } };

                    listBox5.Items.Add(m++ + sep + ArrSecList[0, 0] + sep + ArrSecList[0, 1]);
                }
                var rgxSec = new Regex(patternSectionData);
                label6.Text = "Number of matches(Section Data) : " + rgxSec.Matches(content).Count.ToString();

                sr.Close();
            }
        }

        public static List<int> GetIDs()
        {
            int[] ID = new int[];
            object objNode = Node as object;
            Geometry.GetSelectedNodes(ref objNode, 0);
            Node = (int[])objNode;
            List<int> Nodes = new List<int>();
            Nodes.AddRange(Node);
            return Nodes;
        }

    }

    public class ReadMDTs : ObservableCollection<ReadMDT>
    {

    }
}
