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
        public static List<string> MatCodeList = new List<string>();
        public static List<string> MaterialList = new List<string>();
        public static List<string> MaterialGradeList = new List<string>();
        //public static List<SectionList> SectionList = new List<SectionList>();
        public static List<string> SectionList = new List<string>();
        public static List<MajorProperties> PropertiesList = new List<MajorProperties>();
        

        public static void ReadMDTfile(string content, out string Message)
        {
            var patternMDLData = @"(?<ID>\d*)\s+:\s+(?<MT>\d+)\s+(?<SEC>\d+)\s+(?<Start_X>-?\d+.\d*)\s+(?<Start_Y>-?\d+.\d*)\s+(?<Start_Z>-?\d+.\d*)\s+(?<End_X>-?\d+.\d*)\s+(?<End_Y>-?\d+.\d*)\s+(?<End_Z>-?\d+.\d*)\s+(?<Grid>[\w\s.]*-[\w\s.]*\n)?";
            var MDLData = Regex.Matches(content, patternMDLData);

            var patternPhyMembData = @"(?<compID>\d*)\s+:\s+(?<Node_Start>\d*),?\s+(?<Node_End>\d*)\s+(?<TP>[A-Z]+)\s+(?<SP>[A-Z]+)\s+(?<IT>\d+.\d+)\s+(?<MAT>[A-Z]+)+\s+(?<CP>\d+)\s+(?<Reflect>[YN])\s+\[\s*(?<OvX>-?\d.\d+)\s+(?<OvY>-?\d.\d+)\s+(?<OvZ>-?\d.\d+)\s*\]\s+\[(?<Release_Start>[-R]+)\s+(?<Release_Start_NO>\d+)\s*\]\s+\[(?<Release_End>[-R]+)\s+(?<Release_End_NO>\d+)\s*\]\s(?<SR>\d+.\d+)\s+(?<Section>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*)";
            var PhyMembData = Regex.Matches(content, patternPhyMembData);

            var patternMatData = @"(?<MatItemNo>\d+)\s+:\s+(?<MatCode>\d+)\s+(?<MatGrade>[A-Z]+[0-9A-Z]*)";
            var MatData = Regex.Matches(content, patternMatData);

            var patternMatCodeList = @"\s(?<MatCodeNo>\d+):(?<Material>[A-Za-z]+)[,)]";
            var MatCodeData = Regex.Matches(content, patternMatCodeList);

            var patternSectionData = @"(?<SectionItemNo>\d+)\s:\s(?<compSection>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*)";
            var SectionData = Regex.Matches(content, patternSectionData);

            Message = "";

            foreach (Match match in MatCodeData)
            {
                string MatCodeNo = match.Groups["MatCodeNo"].Value;
                string Material = match.Groups["Material"].Value;

                MatCodeList.Add(Material);
            }

            foreach (Match match in MatData)
            {
                string MatItemNo = match.Groups["MatItemNo"].Value;
                string MatCode = match.Groups["MatCode"].Value;
                string MatGrade = match.Groups["MatGrade"].Value;

                MaterialList.Add(MatCode);
                MaterialGradeList.Add(MatGrade);

                //string[,] ArrMat = new string[,] { { MatItemNo, MatCode, MatGrade } };
                //string listBox3Text = (ArrMat[0, 0] + "  " + ArrMat[0, 1] + "  " + ArrMat[0, 2]);
            }
            
            foreach (Match match in SectionData)
            {
                //SectionList.Add(new SectionList
                //{
                //    SectionItemNo = match.Groups["SectionItemNo"].Value, //重複暫不使用
                //    CompSection = match.Groups["compSection"].Value //重複暫不使用
                //});

                string SectionItemNo = match.Groups["SectionItemNo"].Value; //重複暫不使用
                string CompSection = match.Groups["compSection"].Value; //重複暫不使用

                SectionList.Add(CompSection);

                //string[,] ArrSecList = new string[,] { { SectionItemNo, CompSection } };
                //string listBox5Text = (ArrSecList[0, 0] + "  " + ArrSecList[0, 1]);
            }

            if (MDLData.Count != PhyMembData.Count || MDLData.Count == 0 || PhyMembData.Count == 0)
            {
                Message = "Data count ERROR! Please check member quantity.";
                return;
            }

            for (int i = 0; i < MDLData.Count; i++)
            {
                if (MDLData[i].Groups["ID"].Value != PhyMembData[i].Groups["compID"].Value)
                {
                    Message = string.Format("ERROR! Member ID ({1} - {2}) doesn't match, please check member data and quantity. (count : {0})", (i + 1).ToString(), MDLData[i].Groups["ID"].Value, PhyMembData[i].Groups["compID"].Value);
                    break;
                }

                PropertiesList.Add(new MajorProperties
                {
                    ID = MDLData[i].Groups["ID"].Value,
                    MaterialCode = MDLData[i].Groups["MT"].Value,
                    SectionCode = MDLData[i].Groups["SEC"].Value,
                    StartX = Convert.ToDouble(MDLData[i].Groups["Start_X"].Value),
                    StartY = Convert.ToDouble(MDLData[i].Groups["Start_Y"].Value),
                    StartZ = Convert.ToDouble(MDLData[i].Groups["Start_Z"].Value),
                    EndX = Convert.ToDouble(MDLData[i].Groups["End_X"].Value),
                    EndY = Convert.ToDouble(MDLData[i].Groups["End_Y"].Value),
                    EndZ = Convert.ToDouble(MDLData[i].Groups["End_Z"].Value),
                    Grid = MDLData[i].Groups["Grid"].Value,
                    //
                    CompID = PhyMembData[i].Groups["compID"].Value, //比對ID使用
                    NodeS = PhyMembData[i].Groups["Node_Start"].Value, //重複暫不使用
                    NodeE = PhyMembData[i].Groups["Node_End"].Value, //重複暫不使用
                    Type = PhyMembData[i].Groups["TP"].Value,
                    SP = PhyMembData[i].Groups["SP"].Value,
                    IT = Convert.ToDouble(PhyMembData[i].Groups["IT"].Value), //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
                    MAT = PhyMembData[i].Groups["MAT"].Value, //重複暫不使用
                    CP = PhyMembData[i].Groups["CP"].Value, // 1~10
                    Reflect = PhyMembData[i].Groups["Reflect"].Value, // Y/N
                    OvX = Convert.ToDouble(PhyMembData[i].Groups["OvX"].Value),
                    OvY = Convert.ToDouble(PhyMembData[i].Groups["OvY"].Value),
                    OvZ = Convert.ToDouble(PhyMembData[i].Groups["OvZ"].Value),
                    ReleaseS = PhyMembData[i].Groups["Release_Start"].Value,
                    ReleaseSNo = PhyMembData[i].Groups["Release_Start_NO"].Value,
                    ReleaseE = PhyMembData[i].Groups["Release_End"].Value,
                    ReleaseENo = PhyMembData[i].Groups["Release_End_NO"].Value,
                    SR = Convert.ToDouble(PhyMembData[i].Groups["SR"].Value), //stress ratio, no use for PDMS
                    Section = PhyMembData[i].Groups["Section"].Value,
                    //
                    CompSection = SectionList[Convert.ToInt32(MDLData[i].Groups["SEC"].Value) - 1],
                    //Material = MaterialList[Convert.ToInt32(MDLData[i].Groups["MatCodeNo"].Value) - 1], //TODO
                    MaterialGrade = MaterialGradeList[Convert.ToInt32(MDLData[i].Groups["MT"].Value) - 1],
                });
            }
        }

    }

    public class ReadMDTs : ObservableCollection<ReadMDT>
    {

    }
}
