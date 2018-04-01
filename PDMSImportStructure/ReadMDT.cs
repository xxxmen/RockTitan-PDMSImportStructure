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
        public static List<MajorProperties> MajorPropertiesList = new List<MajorProperties>();
        //public static List<MinorProperties> MinorPropertiesList = new List<MinorProperties>();
        public static List<string> IDs = new List<string>();

        public static void ReadMDTfile(string content, out string label2Text)
        {
            var patternMDLData = @"((?<ID>\d*)\s+:\s+(?<MT>\d+)\s+(?<SEC>\d+)\s+(?<Start_X>-?\d+.\d*)\s+(?<Start_Y>-?\d+.\d*)\s+(?<Start_Z>-?\d+.\d*)\s+(?<End_X>-?\d+.\d*)\s+(?<End_Y>-?\d+.\d*)\s+(?<End_Z>-?\d+.\d*)\s+(?<Grid>[\w\s.]*-[\w\s.]*\n)?)" +
                @"|" +
                @"((?<compID>\d*)\s+:\s+(?<Node_Start>\d*),?\s+(?<Node_End>\d*)\s+(?<TP>[A-Z]+)\s+(?<SP>[A-Z]+)\s+(?<IT>\d+.\d+)\s+(?<MAT>[A-Z]+)+\s+(?<CP>\d+)\s+(?<Reflect>[YN])\s+\[\s*(?<OvX>-?\d.\d+)\s+(?<OvY>-?\d.\d+)\s+(?<OvZ>-?\d.\d+)\s*\]\s+\[(?<Release_Start>[-R]+)\s+(?<Release_Start_NO>\d+)\s*\]\s+\[(?<Release_End>[-R]+)\s+(?<Release_End_NO>\d+)\s*\]\s(?<SR>\d+.\d+)\s+(?<Section>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*))";

            //var patternMDLData = @"(?<ID>\d*)\s+:\s+(?<MT>\d+)\s+(?<SEC>\d+)\s+(?<Start_X>-?\d+.\d*)\s+(?<Start_Y>-?\d+.\d*)\s+(?<Start_Z>-?\d+.\d*)\s+(?<End_X>-?\d+.\d*)\s+(?<End_Y>-?\d+.\d*)\s+(?<End_Z>-?\d+.\d*)\s+(?<Grid>[\w\s.]*-[\w\s.]*\n)?";
            var matchcontentMDLData = Regex.Matches(content, patternMDLData);

            var patternPhyMembData = @"(?<compID>\d*)\s+:\s+(?<Node_Start>\d*),?\s+(?<Node_End>\d*)\s+(?<TP>[A-Z]+)\s+(?<SP>[A-Z]+)\s+(?<IT>\d+.\d+)\s+(?<MAT>[A-Z]+)+\s+(?<CP>\d+)\s+(?<Reflect>[YN])\s+\[\s*(?<OvX>-?\d.\d+)\s+(?<OvY>-?\d.\d+)\s+(?<OvZ>-?\d.\d+)\s*\]\s+\[(?<Release_Start>[-R]+)\s+(?<Release_Start_NO>\d+)\s*\]\s+\[(?<Release_End>[-R]+)\s+(?<Release_End_NO>\d+)\s*\]\s(?<SR>\d+.\d+)\s+(?<Section>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*)";
            var matchcontentPhyMembData = Regex.Matches(content, patternPhyMembData);

            var patternMatData = @"(?<MatItemNo>\d+)\s+:\s+(?<MatCode>\d+)\s+(?<MatGrade>[A-Z]+[0-9A-Z]*)";
            var matchcontentMatData = Regex.Matches(content, patternMatData);

            var patternMatCodeList = @"\s(?<MatCodeNo>\d+):(?<Material>[A-Za-z]+)[,)]";
            var matchcontentMatCodeList = Regex.Matches(content, patternMatCodeList);

            var patternSectionData = @"(?<SectionItemNo>\d+)\s:\s(?<compSection>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*)";
            var matchcontentSectionData = Regex.Matches(content, patternSectionData);

            string sep = "  ";

            var t1 = matchcontentPhyMembData.GetEnumerator();

            int i = 1;
            foreach (Match match in matchcontentMDLData)
            {
                IDs.Add(match.Groups["ID"].Value);

                MajorPropertiesList.Add(new MajorProperties
                {
                    ID = match.Groups["ID"].Value,
                    MaterialCode = match.Groups["MT"].Value,
                    SectionCode = match.Groups["SEC"].Value,
                    StartX = match.Groups["Start_X"].Value,
                    StartY = match.Groups["Start_Y"].Value,
                    StartZ = match.Groups["Start_Z"].Value,
                    EndX = match.Groups["End_X"].Value,
                    EndY = match.Groups["End_Y"].Value,
                    EndZ = match.Groups["End_Z"].Value,
                    Grid = match.Groups["Grid"].Value,

                    CompID = match.Groups["compID"].Value, //比對ID使用
                    NodeS = match.Groups["Node_Start"].Value, //重複暫不使用
                    NodeE = match.Groups["Node_End"].Value, //重複暫不使用
                    Type = match.Groups["TP"].Value,
                    SP = match.Groups["SP"].Value,
                    IT = match.Groups["IT"].Value, //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
                    MAT = match.Groups["MAT"].Value, //重複暫不使用
                    CP = match.Groups["CP"].Value, // 1~10
                    Reflect = match.Groups["Reflect"].Value, // Y/N
                    OvX = match.Groups["OvX"].Value,
                    OvY = match.Groups["OvY"].Value,
                    OvZ = match.Groups["OvZ"].Value,
                    ReleaseS = match.Groups["Release_Start"].Value,
                    ReleaseSNo = match.Groups["Release_Start_NO"].Value,
                    ReleaseE = match.Groups["Release_End"].Value,
                    ReleaseENo = match.Groups["Release_End_NO"].Value,
                    SR = match.Groups["SR"].Value, //stress ratio, no use for PDMS
                    Section = match.Groups["Section"].Value
                    
                    //ID = match.Groups["ID"].Value,
                    //MaterialCode = match.Groups["MT"].Value,
                    //SectionCode = match.Groups["SEC"].Value,
                    //StartX = Convert.ToDouble(match.Groups["Start_X"].Value),
                    //StartY = Convert.ToDouble(match.Groups["Start_Y"].Value),
                    //StartZ = Convert.ToDouble(match.Groups["Start_Z"].Value),
                    //EndX = Convert.ToDouble(match.Groups["End_X"].Value),
                    //EndY = Convert.ToDouble(match.Groups["End_Y"].Value),
                    //EndZ = Convert.ToDouble(match.Groups["End_Z"].Value),
                    //Grid = match.Groups["Grid"].Value,

                    //CompID = match.Groups["compID"].Value, //比對ID使用
                    //NodeS = match.Groups["Node_Start"].Value, //重複暫不使用
                    //NodeE = match.Groups["Node_End"].Value, //重複暫不使用
                    //Type = match.Groups["TP"].Value,
                    //SP = match.Groups["SP"].Value,
                    //IT = Convert.ToDouble(match.Groups["IT"].Value), //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
                    //MAT = match.Groups["MAT"].Value, //重複暫不使用
                    //CP = match.Groups["CP"].Value, // 1~10
                    //Reflect = match.Groups["Reflect"].Value, // Y/N
                    //OvX = Convert.ToDouble(match.Groups["OvX"].Value),
                    //OvY = Convert.ToDouble(match.Groups["OvY"].Value),
                    //OvZ = Convert.ToDouble(match.Groups["OvZ"].Value),
                    //ReleaseS = match.Groups["Release_Start"].Value,
                    //ReleaseSNo = match.Groups["Release_Start_NO"].Value,
                    //ReleaseE = match.Groups["Release_End"].Value,
                    //ReleaseENo = match.Groups["Release_End_NO"].Value,
                    //SR = Convert.ToDouble(match.Groups["SR"].Value), //stress ratio, no use for PDMS
                    //Section = match.Groups["Section"].Value
                });

                //string MaterialCode = match.Groups["MT"].Value;
                //string SectionCode = match.Groups["SEC"].Value;
                //double StartX = double.Parse(match.Groups["Start_X"].Value);
                //double StartY = double.Parse(match.Groups["Start_Y"].Value);
                //double StartZ = double.Parse(match.Groups["Start_Z"].Value);
                //double EndX = double.Parse(match.Groups["End_X"].Value);
                //double EndY = double.Parse(match.Groups["End_Y"].Value);
                //double EndZ = double.Parse(match.Groups["End_Z"].Value);
                //string Grid = match.Groups["Grid"].Value;

                //string listBox1Text = (i++ + sep + ID + sep + MaterialCode + sep + SectionCode + sep + StartX + sep + StartY + sep + StartZ + sep + EndX + sep + EndY + sep + EndZ + sep + Grid);
            }
            var rgxMDL = new Regex(patternMDLData);
            label2Text = "Number of matches(MDL Data) : " + rgxMDL.Matches(content).Count.ToString();


            int j = 1;
            foreach (Match match in matchcontentPhyMembData)
            {
                //MinorPropertiesList.Add(new MinorProperties
                //{
                //    CompID = match.Groups["compID"].Value, //比對ID使用
                //    NodeS = match.Groups["Node_Start"].Value, //重複暫不使用
                //    NodeE = match.Groups["Node_End"].Value, //重複暫不使用
                //    Type = match.Groups["TP"].Value,
                //    SP = match.Groups["SP"].Value,
                //    IT = double.Parse(match.Groups["IT"].Value), //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
                //    MAT = match.Groups["MAT"].Value, //重複暫不使用
                //    CP = match.Groups["CP"].Value, // 1~10
                //    Reflect = match.Groups["Reflect"].Value, // Y/N
                //    OvX = double.Parse(match.Groups["OvX"].Value),
                //    OvY = double.Parse(match.Groups["OvY"].Value),
                //    OvZ = double.Parse(match.Groups["OvZ"].Value),
                //    ReleaseS = match.Groups["Release_Start"].Value,
                //    ReleaseSNo = match.Groups["Release_Start_NO"].Value,
                //    ReleaseE = match.Groups["Release_End"].Value,
                //    ReleaseENo = match.Groups["Release_End_NO"].Value,
                //    SR = double.Parse(match.Groups["SR"].Value), //stress ratio, no use for PDMS
                //    Section = match.Groups["Section"].Value
                //});


                //string CompID = match.Groups["compID"].Value; //比對ID使用
                //string NodeS = match.Groups["Node_Start"].Value; //重複暫不使用
                //string NodeE = match.Groups["Node_End"].Value; //重複暫不使用
                //string Type = match.Groups["TP"].Value;
                //string SP = match.Groups["SP"].Value;
                //double IT = double.Parse(match.Groups["IT"].Value); //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
                //string MAT = match.Groups["MT"].Value; //重複暫不使用
                //string CP = match.Groups["CP"].Value; // 1~10
                //string Reflect = match.Groups["Reflect"].Value; // Y/N
                //double OvX = double.Parse(match.Groups["OvX"].Value);
                //double OvY = double.Parse(match.Groups["OvY"].Value);
                //double OvZ = double.Parse(match.Groups["OvZ"].Value);
                //string ReleaseS = match.Groups["Release_Start"].Value;
                //string ReleaseSNo = match.Groups["Release_Start_NO"].Value;
                //string ReleaseE = match.Groups["Release_End"].Value;
                //string ReleaseENo = match.Groups["Release_End_NO"].Value;
                //double SR = double.Parse(match.Groups["SR"].Value); //stress ratio, no use for PDMS
                //string Section = match.Groups["Section"].Value;

                //string listBox2Text = (j++ + sep + compID + sep + Type + sep + SP + sep
                //    + IT + sep + CP + sep + Reflect + sep + OvX + sep + OvY + sep + OvZ + sep
                //    + ReleaseS + sep + ReleaseSNo + sep + ReleaseE + sep + ReleaseENo + sep + Section);
            }
            var rgxPhy = new Regex(patternPhyMembData);
            string label3Text = "Number of matches(PhyMemb Data) : " + rgxPhy.Matches(content).Count.ToString();


            int k = 1;
            foreach (Match match in matchcontentMatData)
            {
                string MatItemNo = match.Groups["MatItemNo"].Value;
                string MatCode = match.Groups["MatCode"].Value;
                string MatGrade = match.Groups["MatGrade"].Value;

                string[,] ArrMat = new string[,] { { MatItemNo, MatCode, MatGrade } };

                string listBox3Text = (k++ + sep + ArrMat[0, 0] + sep + ArrMat[0, 1] + sep + ArrMat[0, 2]);
            }
            var rgxMat = new Regex(patternMatData);
            string label4Text = "Number of matches(Material Data) : " + rgxMat.Matches(content).Count.ToString();


            int l = 1;
            foreach (Match match in matchcontentMatCodeList)
            {
                string MatCodeNo = match.Groups["MatCodeNo"].Value;
                string Material = match.Groups["Material"].Value;

                string[,] ArrMatType = new string[,] { { MatCodeNo, Material } };

                string listBox4Text = (l++ + sep + ArrMatType[0, 0] + sep + ArrMatType[0, 1]);
            }
            var rgxMatCode = new Regex(patternMatCodeList);
            string label5Text = "Number of matches(Material Code List) : " + rgxMatCode.Matches(content).Count.ToString();


            int m = 1;
            foreach (Match match in matchcontentSectionData)
            {
                string SectionItemNo = match.Groups["SectionItemNo"].Value; //重複暫不使用
                string CompSection = match.Groups["compSection"].Value; //重複暫不使用

                string[,] ArrSecList = new string[,] { { SectionItemNo, CompSection } };

                string listBox5Text = (m++ + sep + ArrSecList[0, 0] + sep + ArrSecList[0, 1]);
            }
            var rgxSec = new Regex(patternSectionData);
            string label6Text = "Number of matches(Section Data) : " + rgxSec.Matches(content).Count.ToString();
        }

    }

    public class ReadMDTs : ObservableCollection<ReadMDT>
    {

    }
}
