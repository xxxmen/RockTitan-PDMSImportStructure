using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.RegularExpressions;

namespace PDMSImportStructure
{
    public class ReadGrd : ReadMDT
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

            var patternGridX = @"(?:[\r\n])(?<XGridName>[\w\s.]*)\s*[Xx]\s+\=\s+(?<Xposition>-?[0-9.]+)";
            var GridXData = Regex.Matches(Grdcontent, patternGridX);

            var patternGridY = @"(?:[\r\n])(?<YGridName>[\w\s.]*)\s*[Yy]\s+\=\s+(?<Yposition>-?[0-9.]+)";
            var GridYData = Regex.Matches(Grdcontent, patternGridY);

            var patternGridZ = @"(?:[\r\n])(?<ZGridName>[\w\s.]*)\s*[Zz]\s+\=\s+(?<Zelevation>-?[0-9.]+)";
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

            if (GrdLengthUnit != MDTLengthUnit)
            {
                Message = string.Format("ERROR! The length unit is different between MDT file and Grd file, please check your data.");
                return;
            }


            GridXPropertiesList.Clear();
            for (int i = 0; i < GridXData.Count; i++)
            {
                string XGridName = GridXData[i].Groups["XGridName"].Value.Trim(); //去掉名稱中所有空白
                double Xposition = Convert.ToDouble(GridXData[i].Groups["Xposition"].Value);

                //check data
                if (XGridName == string.Empty)
                {
                    XGridName = (i + 1).ToString();
                }

                GridXPropertiesList.Add(new GridXProperties { XGridName = XGridName, Xposition = Xposition });
            }

            GridYPropertiesList.Clear();
            for (int j = 0; j < GridYData.Count; j++)
            {
                string YGridName = GridYData[j].Groups["YGridName"].Value.Trim(); //去掉名稱中所有空白
                double Yposition = Convert.ToDouble(GridYData[j].Groups["Yposition"].Value);

                //check data
                if (YGridName == string.Empty)
                {
                    YGridName = (j + 1).ToString();
                }

                GridYPropertiesList.Add(new GridYProperties { YGridName = YGridName, Yposition = Yposition });
            }

            GridZPropertiesList.Clear();
            for (int k = 0; k < GridZData.Count; k++)
            {
                string ZGridName = GridZData[k].Groups["ZGridName"].Value.Trim(); //去掉名稱中所有空白
                double Zelevation = Convert.ToDouble(GridZData[k].Groups["Zelevation"].Value);

                //check data
                if (ZGridName == string.Empty)
                {
                    ZGridName = (k + 1).ToString();
                }

                GridZPropertiesList.Add(new GridZProperties { ZGridName = ZGridName, Zelevation = Zelevation });
            }

        }
    }
}
