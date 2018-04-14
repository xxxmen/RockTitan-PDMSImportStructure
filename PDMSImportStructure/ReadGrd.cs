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

        public static void ReadGrdfile(string Grdfile, out string Message)
        {
            Message = string.Empty;
            string Grdcontent = string.Empty;
            using (StreamReader sr = new StreamReader(Grdfile))
            {
                Grdcontent = sr.ReadToEnd();
                sr.Close();
            }

            var patternGrdLengthUnit = @"Unit\s+\:\s+(?<MDTLengthUnit>[A-Za-z]+)";
            var GrdLengthUnitData = Regex.Match(Grdcontent, patternGrdLengthUnit);
        }
    }
}
