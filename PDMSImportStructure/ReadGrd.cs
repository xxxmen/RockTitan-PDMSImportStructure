using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;

namespace PDMSImportStructure
{
    public class ReadGrd
    {
        public static string GrdLengthUnit = string.Empty;
        public static List<GridXProperties> GridXPropertiesList = new List<GridXProperties>();
        public static List<GridYProperties> GridYPropertiesList = new List<GridYProperties>();
        public static List<GridZProperties> GridZPropertiesList = new List<GridZProperties>();

        public static void ReadGrdfile(string Grdfile, out string Message)
        {
            Message = string.Empty;
            string Grdcontent = string.Empty;
            using (StreamReader sr = new StreamReader(Grdfile))
            {
                Grdcontent = sr.ReadToEnd();
                sr.Close();
            }

            var patternGrdLengthUnit = @"[UNITunit]+\s+\:\s+(?<GrdLengthUnit>[A-Za-z]+)";
            var GrdLengthUnitData = Regex.Match(Grdcontent, patternGrdLengthUnit);

            var patternGridX = @"(?:[\r\n])(?<XGridName>[\w\s.]*)\s*[Xx]\s+\=\s+(?<XGridPosition>-?[0-9.]+)";
            var GridXData = Regex.Matches(Grdcontent, patternGridX);

            var patternGridY = @"(?:[\r\n])(?<YGridName>[\w\s.]*)\s*[Yy]\s+\=\s+(?<YGridPosition>-?[0-9.]+)";
            var GridYData = Regex.Matches(Grdcontent, patternGridY);

            var patternGridZ = @"(?:[\r\n])(?<ZGridName>[\w\s.]*)\s*[Zz]\s+\=\s+(?<ZGridElevation>-?[0-9.]+)";
            var GridZData = Regex.Matches(Grdcontent, patternGridZ);

            //check data
            if (GrdLengthUnitData.Success)
            {
                GrdLengthUnit = GrdLengthUnitData.Groups["GrdLengthUnit"].Value.ToLower();
            }
            else
            {
                Message = string.Format("ERROR! Grd file length unit is missing, please check your data.");
                return;
            }


            GridXPropertiesList.Clear();
            for (int i = 0; i < GridXData.Count; i++)
            {
                string XGridName = GridXData[i].Groups["XGridName"].Value.Trim(); //去掉名稱中所有空白
                double XGridPosition = Convert.ToDouble(GridXData[i].Groups["XGridPosition"].Value);

                //check data
                if (XGridName == string.Empty)
                {
                    XGridName = (i + 1).ToString();
                }

                GridXPropertiesList.Add(new GridXProperties { XGridName = XGridName, XGridPosition = XGridPosition });
            }

            GridYPropertiesList.Clear();
            for (int j = 0; j < GridYData.Count; j++)
            {
                string YGridName = GridYData[j].Groups["YGridName"].Value.Trim(); //去掉名稱中所有空白
                double YGridPosition = Convert.ToDouble(GridYData[j].Groups["YGridPosition"].Value);

                //check data
                if (YGridName == string.Empty)
                {
                    YGridName = (j + 1).ToString();
                }

                GridYPropertiesList.Add(new GridYProperties { YGridName = YGridName, YGridPosition = YGridPosition });
            }

            GridZPropertiesList.Clear();
            for (int k = 0; k < GridZData.Count; k++)
            {
                string ZGridName = GridZData[k].Groups["ZGridName"].Value.Trim(); //去掉名稱中所有空白
                double ZGridElevation = Convert.ToDouble(GridZData[k].Groups["ZGridElevation"].Value);

                //check data
                if (ZGridName == string.Empty)
                {
                    ZGridName = (k + 1).ToString();
                }

                GridZPropertiesList.Add(new GridZProperties { ZGridName = ZGridName, ZGridElevation = ZGridElevation });
            }
        }

        public static void AutoGenGrd(double StartX, double StartY, double StartZ, double EndX, double EndY, double EndZ, string MembType)
        {
            string XGridName = string.Empty;
            double XGridPosition;
            string YGridName = string.Empty;
            double YGridPosition;
            string ZGridName = string.Empty;
            double ZGridElevation;

            if (MembType == "C") //主column需建立X柱線, Y柱線, 底層Grid
            {
                ZGridElevation = Math.Min(StartZ, EndZ);
                ZGridName = "EL" + ZGridElevation.ToString("f2");
                GridZPropertiesList.Add(new GridZProperties { ZGridName = ZGridName, ZGridElevation = ZGridElevation });

                XGridPosition = Math.Min(StartX, EndX);
                XGridName = "X" + XGridPosition.ToString("f2");
                GridXPropertiesList.Add(new GridXProperties { XGridName = XGridName, XGridPosition = XGridPosition });

                YGridPosition = Math.Min(StartY, EndY);
                YGridName = "Y" + YGridPosition.ToString("f2");
                GridYPropertiesList.Add(new GridYProperties { YGridName = YGridName, YGridPosition = YGridPosition });
            }
            else if (MembType == "S" || MembType == "VB" || MembType == "GD" || MembType == "JS" || MembType == "B" || MembType == "HB") //Post, Vertical Bracing, Girder, Joist, Beam, Horizontal Bracing 只需建立高程Grid
            {
                ZGridElevation = Math.Min(StartZ, EndZ);
                ZGridName = "EL" + ZGridElevation.ToString("f2");
                GridZPropertiesList.Add(new GridZProperties { ZGridName = ZGridName, ZGridElevation = ZGridElevation });
            }
            //Purlin及其他皆不需建立Grid
        }

        public static void RemoveDuplicatesSortList()
        {
            //依Grid值由小到大排序
            GridXPropertiesList.Sort((i, j) => { return i.XGridPosition.CompareTo(j.XGridPosition); });
            GridYPropertiesList.Sort((i, j) => { return i.YGridPosition.CompareTo(j.YGridPosition); });
            GridZPropertiesList.Sort((i, j) => { return i.ZGridElevation.CompareTo(j.ZGridElevation); });

            //使用Distinct移除重複項目, 也可用lambda
            GridXPropertiesList = GridXPropertiesList.Distinct().ToList();
            GridYPropertiesList = GridYPropertiesList.Distinct().ToList();
            GridZPropertiesList = GridZPropertiesList.Distinct().ToList();
        }
    }
}
