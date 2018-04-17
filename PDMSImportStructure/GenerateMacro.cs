using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace PDMSImportStructure
{
    public class GenerateMacro
    {
        public static void GenerateMacrofile()
        {
            ReadMDT.CountGrid();
            //TODO
            string mainframePrefix = PDMSImportStrForm.MDTfileNameWOExt; //node.name.Split('/').LastOrDefault();
            if (mainframePrefix == null)
                return;
            string targetName = string.Format("/{0}/MAINFRAME", mainframePrefix);
            string sitename = string.Empty; //node.name;
            string partNo = "01";

            // fix the delete string for safe deletion
            string[] deleteStringArray = {
                      "!cename = !!CE.Name",
                      "  var !list COLL ALL(FITT) for $!!CE",
                      "!size = !list.size()",
                      "do !index from 1 to !size",
                        "!ele = !list[!index]",
                        "$!ele",
                        "delete FITT",
                      "enddo",
                      "!list.clear()",
                      "savework",
                      "$!cename",
                      "var !list COLL ALL(SCTN) for $!!CE",
                      "!size = !list.size()",
                      "do !index from 1 to !size",
                        "!ele = !list[!index]",
                        "$!ele",
                        "delete SCTN",
                      "enddo",
                      "!list.clear()",
                      "savework",
                      "$!cename",
                      "var !list COLL ALL(SBFR) for $!!CE",
                      "!size = !list.size()",
                      "do !index from 1 to !size",
                        "!ele = !list[!index]",
                        "$!ele",
                        "delete SBFR",
                      "enddo",
                      "!list.clear()",
                      "savework",
                      "$!cename",
                      "var !list COLL ALL(FRMW) for $!!CE",
                      "!size = !list.size()",
                      "do !index from 1 to !size",
                        "!ele = !list[!index]",
                        "$!ele",
                        "delete FRMW",
                      "enddo",
                      "!list.clear()",
                      "savework",
                      "$!cename",
                      "var !list COLL ALL(STRU) for $!!CE",
                      "!size = !list.size()",
                      "do !index from 1 to !size",
                        "!ele = !list[!index]",
                        "$!ele",
                        "delete STRU",
                      "enddo",
                      "!list.clear()",
                      "savework",
                      "$!cename",
                      "delete ZONE",
                      "savework"
            };

            string prependString = string.Format("\n{0} dist\n" +
                "var !list COLL ALL  with ( NAME EQ \'{1}\' ) for $!!CE\n" +
                "!size = !list.size()\n" +
                "if(!size eq 1) then\n" +
                "{1}\n" +
                "{2}\n" +
                "endif\n",
                ReadMDT.MDTLengthUnit, targetName, string.Join("\n", deleteStringArray));
            // 加入appendString: 將結構位置於PDMS內截尾至整數(by NINT)
            string[] roundArray = {
                                    string.Format("\n{0}", targetName),
                                    "var !list COLL ALL(SCTN) for $!!CE",
                                    "!size = !list.size()",
                                    "do !index from 1 to !size",
                                    "  !ele = !list[!index]",
                                    "  $!ele",
                                    "  !pos = !!CE.pos",
                                    "  !pos.east = NINT(!pos.east)",
                                    "  !pos.north = NINT(!pos.north)",
                                    "  !!CE.pos = !pos",
                                    "enddo\n"
                                  };
            // 加入appendString: 修正結構的drnstart / drnend的問題
            string[] drnfixArray = {
                                       string.Format("\n{0}", targetName),
                                       "var !list COLL ALL(SCTN) with (func eq 'BEAM' or func eq 'BRACE') for $!!CE",
                                       "!size = !list.size()",
                                       "do !index from 1 to !size",
                                       "  !ele = !list[!index]",
                                       "  $!ele",
                                       "  !gamma = !!CE.ori.gamma",
                                       "  -- less than 45 degree wrt n-axis",
                                       "  if(ABS(SIN(!gamma)) lt 0.7) then",
                                       "    drnstart n",
                                       "    drnend n",
                                       "  endif",
                                       "enddo\n"
                                   };
            string appendString = string.Join("\n", roundArray);
            appendString += string.Join("\n", drnfixArray);


            // TODO: set project base info
            //context.UpdateProjectBase();
            //string ori = string.Format("\nori Y is N{0}W wrt world\n", context.ProjectBase.Item4);
            //string pos = string.Format("Position E {0}mm N {1}mm U {2}mm wrt world\n", context.ProjectBase.Item1, context.ProjectBase.Item2, context.ProjectBase.Item3);
            //string projectBaseInfo = ori + pos;
            //string signature = string.Format("\ndesc \'REVIT_UID:{0}_STR-{2} OWNER:{1}\'\n", mainframePrefix, this.context.client.user.ID, partNo);


            foreach (var item in ReadGrd.GridZPropertiesList)
            {
                string[] STRU = {
                    string.Format("      NEW STRU  /{0}/STL_FRAME/{1}", mainframePrefix, item.ZGridName),
                    string.Format("                 PURP CSTL"),
                };
            }


            string MACcontentRCMemb = string.Empty;
            foreach (var item in ReadMDT.MainPropertiesList)
            {
                if (item.SectionHeader == "RC")
                {
                    string[] strArrayMACcontentRCMemb = MacRCMemb(mainframePrefix, item.ID, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.SectionWidth, item.SectionDepth, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                    MACcontentRCMemb += string.Join("\n", strArrayMACcontentRCMemb);
                }
            }

            string[] MACcontentCOLArray = {
                "$*    steel_col_el                  300.000  :   18",
                "      NEW STRU  /PR-11/STL_FRAME/EL300.000",
                "                 PURP CSTL",
                "      NEW FRMW  /PR-11/S_EL300.000/ELEVIEW",
                "                 PURP SELE",
                "      NEW SBFR  /PR-11/S_EL300.000/COLUMN",
                "                 PURP COLN",
                MACcontentRCMemb + "      END",
                "     END",
                "    END\n"
            };
            string MACcontentCOL = string.Join("\n", MACcontentCOLArray);


            string[] MACcontentArray = {
                string.Format("NEW ZONE  /{0}/MAINFRAME", mainframePrefix),
                //sprojectBaseInfo + signature,
                "    PURP STL",
                MACcontentCOL
            };
            string MACcontent = string.Join("\n", MACcontentArray);

            using (StreamWriter sw = new StreamWriter(PDMSImportStrForm.MDTfilePathWNameWOExt + PDMSImportStrForm.OutputMacroFileExt))
            {
                sw.WriteLine(prependString + MACcontent + appendString);
                sw.Close();
            }
        }



        static string[] MacRCMemb(string mainframePrefix, string ID, string Grid, string DRNStart, string DRNEnd, double StartX, double StartY, double StartZ, double EndX, double EndY, double EndZ, string SectionWidth, string SectionDepth, string JUSLINE, double Bangle, string Function, string ConnTypeS, string ConnTypeE)
        {
            string[] strArrayMACcontentRC = {
                        string.Format("        NEW SCTN  /{0}/STL_COL_{2}/#{1}", mainframePrefix, ID, Grid.Trim()), //不可包含空白字元, 總字元數不能超過50
                        string.Format("          DRNSTART {0}  DRNEND {1} ", DRNStart, DRNEnd),
                        string.Format("          POSS  E{0}      N{1}      U{2}         POSE  E{3}      N{4}      U{5}", StartX.ToString("f2"), StartY.ToString("f2"), StartZ.ToString("f2"), EndX.ToString("f2"), EndY.ToString("f2"), EndZ.ToString("f2")),
                        string.Format("          SPRE /CONCRETE-BEAMS-SPEC/Rectangular_Profile DESP {0}   {1}", SectionDepth, SectionWidth),
                        string.Format("            JUSL  {0}    BANG   {1}  FUNC  '{2}'  DESC  '{3}'", JUSLINE, Bangle.ToString("f2"), Function, Grid),
                        string.Format("          CTYS {0}    CTYE {1}", ConnTypeS, ConnTypeE),
                        "        END\n"
            };
            return strArrayMACcontentRC;
        }

        static string[] MacSteelMemb(string mainframePrefix, string ID, string Grid, string DRNStart, string DRNEnd, double StartX, double StartY, double StartZ, double EndX, double EndY, double EndZ, string Section, string JUSLINE, double Bangle, string Function, string ConnTypeS, string ConnTypeE)
        {
            string[] strArrayMACcontentSteel = {
                        string.Format("        NEW SCTN  /{0}/STL_COL_{2}/#{1}", mainframePrefix, ID, Grid.Trim()), //不可包含空白字元, 總字元數不能超過50
                        string.Format("          DRNSTART {0}  DRNEND {1} ", DRNStart, DRNEnd),
                        string.Format("          POSS  E{0}      N{1}      U{2}         POSE  E{3}      N{4}      U{5}", StartX.ToString("f2"), StartY.ToString("f2"), StartZ.ToString("f2"), EndX.ToString("f2"), EndY.ToString("f2"), EndZ.ToString("f2")),
                        string.Format("          SPRE  SPCO  /CTCV-SPEC/{0}         JUSL  {1}    BANG   {2}  FUNC  '{3}'  DESC  '{4}'", Section, JUSLINE, Bangle.ToString("f2"), Function, Grid),
                        string.Format("          CTYS {0}    CTYE {1}", ConnTypeS, ConnTypeE),
                        "        END\n"
            };
            return strArrayMACcontentSteel;
        }
    }
}
