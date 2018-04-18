using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace PDMSImportStructure
{
    public class GenerateMacro : ReadMDT
    {
        static List<List<GridMembListProp>> GridMembList = new List<List<GridMembListProp>>();
        static List<List<string>> PlanViewElevationViewList = new List<List<string>>();

        public static void GenerateMacrofile()
        {
            PrepareGridZList();
            //TODO
            string mainframePrefix = PDMSImportStrForm.MDTfileNameWOExt; //node.name.Split('/').LastOrDefault();
            mainframePrefix = mainframePrefix.Trim(); //不可含空白
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



            string STRU = string.Empty;
            foreach (var subitem in ReadGrd.GridZPropertiesList)
            {
                string FRMW = string.Empty;
                foreach (var outlistitem in PlanViewElevationViewList)
                {
                    foreach (var inlistitem in outlistitem)
                    {
                        if (outlistitem.Count != 0)
                        {
                            if ((inlistitem == subitem.ZGridName + "C") || (inlistitem == subitem.ZGridName + "S"))
                            {
                                string MACcontentRCMemb = string.Empty;
                                string MACcontentSteelMemb = string.Empty;
                                foreach (var item in ReadMDT.MainPropertiesList)
                                {
                                    if ((inlistitem == item.ZcorGridName + item.MembType))
                                    {
                                        if (item.SectionHeader == "RC")
                                        {
                                            string[] strArrayMACcontentRCMemb = MacRCMemb(mainframePrefix, item.ID, item.strCompHashCode, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.SectionWidth, item.SectionDepth, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                                            MACcontentRCMemb += string.Join("\n", strArrayMACcontentRCMemb);
                                        }
                                        else
                                        {
                                            string[] strArrayMACcontentSteelMemb = MacSteelMemb(mainframePrefix, item.ID, item.strCompHashCode, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.Section, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                                            MACcontentSteelMemb += string.Join("\n", strArrayMACcontentSteelMemb);
                                        }
                                    }
                                }

                                string[] strArrayFRMW = {
                                        string.Format("    NEW FRMW  /{0}/S_{1}/ELEVIEW", mainframePrefix, subitem.ZGridName),
                                        string.Format("        PURP SELE"),
                                        string.Format("      NEW SBFR  /{0}/S_{1}/COLUMN", mainframePrefix, subitem.ZGridName),
                                        string.Format("          PURP COLN"),
                                        MACcontentRCMemb + MACcontentSteelMemb + string.Format("      END"),
                                        string.Format("    END"),
                                    };
                                FRMW += string.Join("\n", strArrayFRMW);
                            }
                            else if (inlistitem == subitem.ZGridName + "VB")
                            {
                                string MACcontentRCMemb = string.Empty;
                                string MACcontentSteelMemb = string.Empty;
                                foreach (var item in ReadMDT.MainPropertiesList)
                                {
                                    if ((inlistitem == item.ZcorGridName + item.MembType))
                                    {
                                        if (item.SectionHeader == "RC")
                                        {
                                            string[] strArrayMACcontentRCMemb = MacRCMemb(mainframePrefix, item.ID, item.strCompHashCode, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.SectionWidth, item.SectionDepth, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                                            MACcontentRCMemb += string.Join("\n", strArrayMACcontentRCMemb);
                                        }
                                        else
                                        {
                                            string[] strArrayMACcontentSteelMemb = MacSteelMemb(mainframePrefix, item.ID, item.strCompHashCode, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.Section, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                                            MACcontentSteelMemb += string.Join("\n", strArrayMACcontentSteelMemb);
                                        }
                                    }
                                }

                                string[] strArrayFRMW = {
                                        string.Format("    NEW FRMW  /{0}/S_{1}/ELEVIEW", mainframePrefix, subitem.ZGridName),
                                        string.Format("        PURP SELE"),
                                        string.Format("      NEW SBFR  /{0}/S_{1}/VBRACE", mainframePrefix, subitem.ZGridName),
                                        string.Format("          PURP BRAC"),
                                        MACcontentRCMemb + MACcontentSteelMemb + string.Format("      END"),
                                        string.Format("    END"),
                                    };
                                FRMW += string.Join("\n", strArrayFRMW);
                            }
                            else if ((inlistitem == subitem.ZGridName + "GD") || (inlistitem == subitem.ZGridName + "JS") || (inlistitem == subitem.ZGridName + "B") || (inlistitem == subitem.ZGridName + "PL"))
                            {
                                string MACcontentRCMemb = string.Empty;
                                string MACcontentSteelMemb = string.Empty;
                                foreach (var item in ReadMDT.MainPropertiesList)
                                {
                                    if ((inlistitem == item.ZcorGridName + item.MembType))
                                    {
                                        if (item.SectionHeader == "RC")
                                        {
                                            string[] strArrayMACcontentRCMemb = MacRCMemb(mainframePrefix, item.ID, item.strCompHashCode, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.SectionWidth, item.SectionDepth, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                                            MACcontentRCMemb += string.Join("\n", strArrayMACcontentRCMemb);
                                        }
                                        else
                                        {
                                            string[] strArrayMACcontentSteelMemb = MacSteelMemb(mainframePrefix, item.ID, item.strCompHashCode, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.Section, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                                            MACcontentSteelMemb += string.Join("\n", strArrayMACcontentSteelMemb);
                                        }
                                    }
                                }

                                string[] strArrayFRMW = {
                                        string.Format("    NEW FRMW  /{0}/S_{1}/PLANVIEW", mainframePrefix, subitem.ZGridName),
                                        string.Format("        PURP SELE"),
                                        string.Format("      NEW SBFR  /{0}/S_{1}/BEAM", mainframePrefix, subitem.ZGridName),
                                        string.Format("          PURP BEAM"),
                                        MACcontentRCMemb + MACcontentSteelMemb + string.Format("      END"),
                                        string.Format("    END"),
                                    };
                                FRMW += string.Join("\n", strArrayFRMW);
                            }
                            else if (inlistitem == subitem.ZGridName + "HB")
                            {
                                string MACcontentRCMemb = string.Empty;
                                string MACcontentSteelMemb = string.Empty;
                                foreach (var item in ReadMDT.MainPropertiesList)
                                {
                                    if ((inlistitem == item.ZcorGridName + item.MembType))
                                    {
                                        if (item.SectionHeader == "RC")
                                        {
                                            string[] strArrayMACcontentRCMemb = MacRCMemb(mainframePrefix, item.ID, item.strCompHashCode, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.SectionWidth, item.SectionDepth, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                                            MACcontentRCMemb += string.Join("\n", strArrayMACcontentRCMemb);
                                        }
                                        else
                                        {
                                            string[] strArrayMACcontentSteelMemb = MacSteelMemb(mainframePrefix, item.ID, item.strCompHashCode, item.Grid, item.DRNStart, item.DRNEnd, item.StartX, item.StartY, item.StartZ, item.EndX, item.EndY, item.EndZ, item.Section, item.JUSLINE, item.Bangle, item.Function, item.ConnTypeS, item.ConnTypeE);
                                            MACcontentSteelMemb += string.Join("\n", strArrayMACcontentSteelMemb);
                                        }
                                    }
                                }

                                string[] strArrayFRMW = {
                                        string.Format("    NEW FRMW  /{0}/S_{1}/PLANVIEW", mainframePrefix, subitem.ZGridName),
                                        string.Format("        PURP SELE"),
                                        string.Format("      NEW SBFR  /{0}/S_{1}/HBRACE", mainframePrefix, subitem.ZGridName),
                                        string.Format("          PURP BRAC"),
                                        MACcontentRCMemb + MACcontentSteelMemb + string.Format("      END"),
                                        string.Format("    END"),
                                    };
                                FRMW += string.Join("\n", strArrayFRMW);
                            }
                        }
                    }
                }

                string[] strArraySTRU = {
                        string.Format("  NEW STRU  /{0}/STL_FRAME/{1}", mainframePrefix, subitem.ZGridName),
                        string.Format("      PURP CSTL"),
                        FRMW,
                        "  END\n"
                    };
                STRU += string.Join("\n", strArraySTRU);
            }

            string[] MACcontentArray = {
                string.Format("NEW ZONE  /{0}/MAINFRAME", mainframePrefix),
                //sprojectBaseInfo + signature,
                "    PURP STL",
                STRU
            };
            string MACcontent = string.Join("\n", MACcontentArray);

            string OutputMAC = prependString + MACcontent + appendString;

            using (StreamWriter sw = new StreamWriter(PDMSImportStrForm.MDTfilePathWNameWOExt + PDMSImportStrForm.OutputMacroFileExt))
            {
                sw.WriteLine(OutputMAC);
                sw.Close();
            }
        }

        static void PrepareGridZList()
        {
            GridMembList.Clear();
            //GridZPropertiesList已先做排序, 將從elevation最底層開始做
            foreach (var j in GridZPropertiesList)
            {
                List<GridMembListProp> GridCountList = new List<GridMembListProp>();
                foreach (var i in MainPropertiesList)
                {
                    if (Convert.ToDouble(i.ZcorGridElevation) == j.ZGridElevation)
                    {
                        GridCountList.Add(new GridMembListProp
                        {
                            ID = i.ID,
                            GridZEL = i.ZcorGridName,
                            MembType = i.MembType
                        });
                    }
                }
                GridMembList.Add(GridCountList);
            }

            PlanViewElevationViewList.Clear();
            foreach (var outlistitem in GridMembList)
            {
                List<string> ELMembTypeList = new List<string>();
                foreach (var inlistitem in outlistitem)
                {
                    ELMembTypeList.Add(inlistitem.GridZEL + inlistitem.MembType);
                }
                ELMembTypeList = ELMembTypeList.Distinct().ToList();
                PlanViewElevationViewList.Add(ELMembTypeList);
            }
        }

        static string[] MacRCMemb(string mainframePrefix, string ID, int strCompHashCode, string Grid, string DRNStart, string DRNEnd, double StartX, double StartY, double StartZ, double EndX, double EndY, double EndZ, string SectionWidth, string SectionDepth, string JUSLINE, double Bangle, string Function, string ConnTypeS, string ConnTypeE)
        {
            string strNewSCTN = string.Format("/{0}/RC_{1}/#{2}_({3})", mainframePrefix, Grid.Trim(), ID, strCompHashCode); //不可包含空白字元, 總字元數不能超過50
            if (strNewSCTN.Length >= 50) 
            {
                strNewSCTN = string.Format("/{0}/RC/#{1}_({2})", mainframePrefix, ID, strCompHashCode);
            }

            string[] strArrayMACcontentRC = {
                        string.Format("        NEW SCTN  {0}", strNewSCTN), 
                        string.Format("          DRNSTART {0}  DRNEND {1}", DRNStart, DRNEnd),
                        string.Format("          POSS  E{0}      N{1}      U{2}         POSE  E{3}      N{4}      U{5}", StartX.ToString("f2"), StartY.ToString("f2"), StartZ.ToString("f2"), EndX.ToString("f2"), EndY.ToString("f2"), EndZ.ToString("f2")),
                        string.Format("          SPRE /CONCRETE-BEAMS-SPEC/Rectangular_Profile DESP {0}   {1}", SectionDepth, SectionWidth),
                        string.Format("          JUSL  {0}    BANG   {1}  FUNC  '{2}'  DESC  '{3}'", JUSLINE, Bangle.ToString("f2"), Function, Grid),
                        string.Format("          CTYS {0}    CTYE {1}", ConnTypeS, ConnTypeE),
                        "        END\n"
            };
            return strArrayMACcontentRC;
        }

        static string[] MacSteelMemb(string mainframePrefix, string ID, int strCompHashCode, string Grid, string DRNStart, string DRNEnd, double StartX, double StartY, double StartZ, double EndX, double EndY, double EndZ, string Section, string JUSLINE, double Bangle, string Function, string ConnTypeS, string ConnTypeE)
        {
            string strNewSCTN = string.Format("/{0}/STL_{1}/#{2}_({3})", mainframePrefix, Grid.Trim(), ID, strCompHashCode); //不可包含空白字元, 總字元數不能超過50
            if (strNewSCTN.Length >= 50)
            {
                strNewSCTN = string.Format("/{0}/STL/#{1}_({2})", mainframePrefix, ID, strCompHashCode);
            }

            string[] strArrayMACcontentSteel = {
                        string.Format("        NEW SCTN  {0}", strNewSCTN),
                        string.Format("          DRNSTART {0}  DRNEND {1}", DRNStart, DRNEnd),
                        string.Format("          POSS  E{0}      N{1}      U{2}         POSE  E{3}      N{4}      U{5}", StartX.ToString("f2"), StartY.ToString("f2"), StartZ.ToString("f2"), EndX.ToString("f2"), EndY.ToString("f2"), EndZ.ToString("f2")),
                        string.Format("          SPRE  SPCO  /CTCV-SPEC/{0}         JUSL  {1}    BANG   {2}  FUNC  '{3}'  DESC  '{4}'", Section, JUSLINE, Bangle.ToString("f2"), Function, Grid),
                        string.Format("          CTYS {0}    CTYE {1}", ConnTypeS, ConnTypeE),
                        "        END\n"
            };
            return strArrayMACcontentSteel;
        }

        static string[] CENameCheck(string mainframePrefix, string ID, int strCompHashCode, string Grid)
        {
            string[] strArrayCENameCheck = {
                string.Format("if(!!ce.name eq '/{0}/STL_COL__{1}/#{2}_({3})') then", mainframePrefix, Grid.Trim(), ID, strCompHashCode),
                "",
                "else",
                "delete SCTN",
                "endif"
            };
            return strArrayCENameCheck;
        }
    }

    public partial struct GridMembListProp
    {
        public string ID { get; set; }
        public string GridZEL { get; set; }
        public string MembType { get; set; }
    }
}
