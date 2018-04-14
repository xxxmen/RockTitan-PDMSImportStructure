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
        //TODO: MDT version, shift, rotate
        public static string MDTLengthUnit = string.Empty;
        public static List<string> MatCodeList = new List<string>();
        public static List<string> MaterialList = new List<string>();
        public static List<string> MaterialGradeList = new List<string>();
        //public static List<SectionList> SectionList = new List<SectionList>();
        public static List<string> SectionList = new List<string>();
        public static List<MajorProperties> PropertiesList = new List<MajorProperties>(); //Main Data: All member data

        public static void ReadMDTfile(string MDTfile, out string Message)
        {
            string content = string.Empty;
            using (StreamReader sr = new StreamReader(MDTfile))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }

            var patternMDTLengthUnit = @"Unit\s+\:\s+(?<MDTLengthUnit>[A-Za-z]+)";
            var MDTLengthUnitData = Regex.Match(content, patternMDTLengthUnit);

            var patternMDLData = @"(?<ID>\d*)\s+:\s+(?<MT>\d+)\s+(?<SEC>\d+)\s+(?<Start_X>-?\d+.\d*)\s+(?<Start_Y>-?\d+.\d*)\s+(?<Start_Z>-?\d+.\d*)\s+(?<End_X>-?\d+.\d*)\s+(?<End_Y>-?\d+.\d*)\s+(?<End_Z>-?\d+.\d*)\s+(?<Grid>[\w\s.]*-[\w\s.]*\n)?";
            var MDLData = Regex.Matches(content, patternMDLData);

            var patternPhyMembData = @"(?<compID>\d*)\s+:\s+(?<Node_Start>\d*),?\s+(?<Node_End>\d*)\s+(?<TP>[A-Z]+)\s+(?<SP>[A-Z]+)\s+(?<IT>\d+.\d+)\s+(?<MAT>[A-Z]+)+\s+(?<CP>\d+)\s+(?<Reflect>[YN])\s+\[\s*(?<OvX>-?\d.\d+)\s+(?<OvY>-?\d.\d+)\s+(?<OvZ>-?\d.\d+)\s*\]\s+\[(?<Release_Start>[-R]+)\s+(?<Release_Start_NO>\d+)\s*\]\s+\[(?<Release_End>[-R]+)\s+(?<Release_End_NO>\d+)\s*\]\s(?<SR>\d+.\d+)\s+(?<Section>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*)?";
            var PhyMembData = Regex.Matches(content, patternPhyMembData);

            var patternMatData = @"(?<MatItemNo>\d+)\s+\:\s+(?<MatCode>\d+)\s(?<MatGrade>[A-Za-z]*[0-9A-Za-z]*)[\r\n]"; //注意最後[\r\n]C#跳行符號
            var MatData = Regex.Matches(content, patternMatData);

            var patternMatCodeList = @"\s(?<MatCodeNo>\d+):(?<Material>[A-Za-z]+)[,)]";
            var MatCodeData = Regex.Matches(content, patternMatCodeList);

            var patternSectionData = @"(?<SectionItemNo>\d+)\s:\s(?<compSection>[A-Z]*_*\d*[A-Z]+\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*[Xx*]?\d*[.\/]?\d*)";
            var SectionData = Regex.Matches(content, patternSectionData);

            Message = string.Empty;

            //check data
            if (MDTLengthUnitData.Success)
            {
                MDTLengthUnit = MDTLengthUnitData.Groups["MDTLengthUnit"].Value.ToLower();
            }
            else
            {
                Message = string.Format("ERROR! MDT file length unit is missing, please check your data.");
                return;
            }

            if (MDLData.Count == 0)
            {
                Message = string.Format("ERROR! MDLData is empty, please check all data and quantity.");
                return;
            }
            else if (PhyMembData.Count == 0)
            {
                Message = string.Format("ERROR! PhyMembData is empty, please check all data and quantity.");
                return;
            }
            else if (MDLData.Count != PhyMembData.Count)
            {
                Message = "ERROR! MDLData and PhyMembData count are not equal, please check member quantity.";
                return;
            }
            else if (MatData.Count == 0)
            {
                Message = string.Format("ERROR! MatData is empty, please check all data and quantity.");
                return;
            }
            else if (MatCodeData.Count == 0)
            {
                Message = string.Format("ERROR! MatCodeData is empty, please check all data and quantity.");
                return;
            }
            else if (SectionData.Count == 0)
            {
                Message = string.Format("ERROR! SectionData is empty, please check all data and quantity.");
                return;
            }


            MatCodeList.Clear();
            foreach (Match match in MatCodeData)
            {
                string MatCodeNo = match.Groups["MatCodeNo"].Value; //未使用, 目前用索引子查找, 非對照
                string Material = match.Groups["Material"].Value;
                MatCodeList.Add(Material);
            }

            MaterialList.Clear();
            MaterialGradeList.Clear();
            foreach (Match match in MatData)
            {
                string MatItemNo = match.Groups["MatItemNo"].Value; //未使用, 目前用索引子查找, 非對照
                string MatCode = match.Groups["MatCode"].Value;
                string MatGrade = match.Groups["MatGrade"].Value;
                MaterialList.Add(MatCodeList[Convert.ToInt32(MatCode)].ToString());
                MaterialGradeList.Add(MatGrade);
            }

            SectionList.Clear();
            foreach (Match match in SectionData)
            {
                string SectionItemNo = match.Groups["SectionItemNo"].Value; //重複暫不使用, 未使用, 目前用索引子查找, 非對照
                string CompSection = match.Groups["compSection"].Value; //比對Section使用
                SectionList.Add(CompSection);
            }

            PropertiesList.Clear();
            for (int i = 0; i < MDLData.Count; i++)
            {
                int countNo = i + 1;
                //MDL Data properties
                string ID = MDLData[i].Groups["ID"].Value;
                string MaterialCode = MDLData[i].Groups["MT"].Value;
                string SectionCode = MDLData[i].Groups["SEC"].Value;
                double StartX = Convert.ToDouble(MDLData[i].Groups["Start_X"].Value);
                double StartY = Convert.ToDouble(MDLData[i].Groups["Start_Y"].Value);
                double StartZ = Convert.ToDouble(MDLData[i].Groups["Start_Z"].Value);
                double EndX = Convert.ToDouble(MDLData[i].Groups["End_X"].Value);
                double EndY = Convert.ToDouble(MDLData[i].Groups["End_Y"].Value);
                double EndZ = Convert.ToDouble(MDLData[i].Groups["End_Z"].Value);
                string Grid = MDLData[i].Groups["Grid"].Value.Replace("\r\n", string.Empty); //Replace去掉換行符號
                //Phy Memb Data properties
                string CompID = PhyMembData[i].Groups["compID"].Value; //比對ID使用
                string NodeS = PhyMembData[i].Groups["Node_Start"].Value; //重複暫不使用
                string NodeE = PhyMembData[i].Groups["Node_End"].Value; //重複暫不使用
                string MembType = PhyMembData[i].Groups["TP"].Value;
                string SP = PhyMembData[i].Groups["SP"].Value;
                double IT = Convert.ToDouble(PhyMembData[i].Groups["IT"].Value); //將考慮直接填入轉角; 就不需轉換OvX; OvY; OvZ
                string MAT = PhyMembData[i].Groups["MAT"].Value; //重複暫不使用
                string CP = PhyMembData[i].Groups["CP"].Value; // 1~10
                string Reflect = PhyMembData[i].Groups["Reflect"].Value; // Y/N
                double OvX = Convert.ToDouble(PhyMembData[i].Groups["OvX"].Value);
                double OvY = Convert.ToDouble(PhyMembData[i].Groups["OvY"].Value);
                double OvZ = Convert.ToDouble(PhyMembData[i].Groups["OvZ"].Value);
                string ReleaseS = PhyMembData[i].Groups["Release_Start"].Value;
                string ReleaseSNo = PhyMembData[i].Groups["Release_Start_NO"].Value;
                string ReleaseE = PhyMembData[i].Groups["Release_End"].Value;
                string ReleaseENo = PhyMembData[i].Groups["Release_End_NO"].Value;
                double SR = Convert.ToDouble(PhyMembData[i].Groups["SR"].Value); //stress ratio; no use for PDMS
                string Section = PhyMembData[i].Groups["Section"].Value;
                //additional properties
                string CompSection = SectionList[Convert.ToInt32(MDLData[i].Groups["SEC"].Value) - 1]; //比對Section使用
                string Material = MaterialList[Convert.ToInt32(MDLData[i].Groups["MT"].Value) - 1];
                string MaterialGrade = MaterialGradeList[Convert.ToInt32(MDLData[i].Groups["MT"].Value) - 1];
                double MemberLength = Math.Round(Math.Sqrt(Math.Pow(EndX - StartX, 2) + Math.Pow(EndY - StartY, 2) + Math.Pow(EndZ - StartZ, 2)), 2);
                string ConnTypeS = "HING";
                if (ReleaseS == "------") { ConnTypeS = "FIX"; } else if (ReleaseS == "RRRRRR") { ConnTypeS = "FREE"; }
                string ConnTypeE = "HING";
                if (ReleaseE == "------") { ConnTypeE = "FIX"; } else if (ReleaseE == "RRRRRR") { ConnTypeE = "FREE"; }
                
                //取得斷面名稱頭
                //var patternSectionHeader = @"(?<SecHead>[A-Z]*[2]*[A-Z]+)(?<T1>[0-9\.\/\-]+[ABCDEM]?)(?<D1>[Xx\*])?(?<T2>[0-9\.\/\-]+[ABCDEM]?)?(?<D2>[Xx\*])?(?<T3>[0-9\.\/\-]+[ABCDEM]?)?(?<D3>[Xx\*])?(?<T4>[0-9\.\/\-]+[ABCM]?)?(?<T5>[DPTW]+[0-9]*)?";
                var patternSectionHeader = @"(?<SecHead>[OXBHDCUPNISTWMLJEFR]*[2]?[WFMCLTRSAHNUBRPDIEOX]+)(?<T1>[0-9\.\/\-]+[ABCDEM]?)(?<D1>[Xx\*])?(?<T2>[0-9\.\/\-]+[ABCDEM]?)?(?<D2>[Xx\*])?(?<T3>[0-9\.\/\-]+[ABCDEM]?)?(?<D3>[Xx\*])?(?<T4>[0-9\.\/\-]+[ABCM]?)?(?<T5>[DPTW]+[0-9]*)?";
                var MatSection = Regex.Match(Section, patternSectionHeader);
                string SectionHeader = MatSection.Groups["SecHead"].Value;
                //修正RegularExpressions Pattern讀取斷面名稱頭資料限制
                if (SectionHeader == "L2X") { SectionHeader = "L"; }
                else if (SectionHeader == "WT2X") { SectionHeader = "WT"; }
                //JUSLINE / JUSL - Justification Line
                string JUSLINE = CompareCardinalPoint.GetJustificationLine(SectionHeader, CP, out string SectionType);
                
                //Function (Type)
                string Function = string.Empty;
                if (MembType == "C") { Function = "Column"; }
                else if (MembType == "S") { Function = "Slanted Column(Post)"; }
                else if (MembType == "GD") { Function = "Girder"; }
                else if (MembType == "JS") { Function = "Joist"; }
                else if (MembType == "B") { Function = "Beam"; }
                else if (MembType == "PL") { Function = "Purlin"; }
                else if (MembType == "HB") { Function = "Horizontal Bracing"; }
                else if (MembType == "VB") { Function = "Vertical Bracing"; }
                else { Function = "Other"; }

                //Beta Angle (Cross-Section Rotation)
                double Bangle = ConvertOrientationVector.OvtoBangle(StartX, StartY, StartZ, EndX, EndY, EndZ, OvX, OvY, OvZ);
                //Reflect
                //TODO: reflect為繞中心線翻轉, 非繞JUSLINE轉180
                if (Reflect == "Y")
                {
                    if (Bangle >= 180) { Bangle = Bangle - 180; }
                    else if (Bangle < -180) { Bangle = Bangle + 180; }
                }
                //PDMS Bangel range +180 ~ -180
                if (Bangle > 180)
                {
                    Bangle = Bangle - 360;
                }
                else if (Bangle < -180)
                {
                    Bangle = Bangle + 360;
                }
                //Bangle四捨五入至小數兩位
                Bangle = Math.Round(Bangle, 2);

                //TODO:未確認完整
                //將所有PDMS桿件屬性轉為字串並組合後轉為HashCode, 用於比對是否需更新
                int strCompHashCode = (ID + StartX.ToString() + StartY.ToString() + StartZ.ToString() 
                    + EndX.ToString() + EndY.ToString() + EndZ.ToString() + Grid 
                    + Reflect + OvX.ToString() + OvY.ToString() + OvZ.ToString() 
                    + Section + Material + MaterialGrade + ConnTypeS + ConnTypeE 
                    + JUSLINE + Function + Bangle.ToString()).GetHashCode();

                //check data
                if (ID != CompID)
                {
                    Message = string.Format("ERROR! Member ID ({1} - {2}) doesn't match, please check member data and quantity. (count : {0})", countNo.ToString(), ID, CompID);
                    break;
                }
                else if (CompSection != Section)
                {
                    Message = string.Format("ERROR! Member section ({1} - {2}) doesn't match, please check member data. (count : {0})", countNo.ToString(), CompSection, Section);
                    break;
                }
                else if (Section == null || Section == string.Empty)
                {
                    Message = string.Format("ERROR! Member section ({1} - {2}) string is empty, please check member data. (count : {0})", countNo.ToString(), CompSection, Section);
                    break;
                }

                //將資料寫入List
                PropertiesList.Add(new MajorProperties
                {
                    countNo = countNo,
                    //
                    ID = ID,
                    MaterialCode = MaterialCode,
                    SectionCode = SectionCode,
                    StartX = StartX,
                    StartY = StartY,
                    StartZ = StartZ,
                    EndX = EndX,
                    EndY = EndY,
                    EndZ = EndZ,
                    Grid = Grid,
                    //
                    CompID = CompID,
                    NodeS = NodeS,
                    NodeE = NodeE,
                    MembType = MembType,
                    SP = SP,
                    IT = IT,
                    MAT = MAT,
                    CP = CP,
                    Reflect = Reflect,
                    OvX = OvX,
                    OvY = OvY,
                    OvZ = OvZ,
                    ReleaseS = ReleaseS,
                    ReleaseSNo = ReleaseSNo,
                    ReleaseE = ReleaseE,
                    ReleaseENo = ReleaseENo,
                    SR = SR,
                    Section = Section,
                    //
                    CompSection = CompSection,
                    Material = Material,
                    MaterialGrade = MaterialGrade,
                    MemberLength = MemberLength,
                    ConnTypeS = ConnTypeS,
                    ConnTypeE = ConnTypeE,
                    SectionType = SectionType,
                    JUSLINE = JUSLINE,
                    Function = Function,
                    Bangle = Bangle,
                    strCompHashCode = strCompHashCode
                });
            }
        }
    }
}
