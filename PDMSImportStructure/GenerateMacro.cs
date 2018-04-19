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
        static List<List<string>> ColVBBeamHBList = new List<List<string>>();
        static List<List<string>> PlanElevationMembTypeList = new List<List<string>>();
        public static string OutputMAC = string.Empty;

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
            foreach (var gridZitem in ReadGrd.GridZPropertiesList)
            {
                string FRMW = string.Empty;
                foreach (var PEVoutlistitem in PlanViewElevationViewList)
                {
                    foreach (var PEVinlistitem in PEVoutlistitem)
                    {
                        if (PEVoutlistitem.Count != 0)
                        {
                            if (PEVinlistitem == gridZitem.ZGridName + "ELEVIEW")
                            {
                                string SBFR = string.Empty;
                                foreach (var CVBHoutlistitem in ColVBBeamHBList)
                                {
                                    foreach (var CVBHinlistitem in CVBHoutlistitem)
                                    {
                                        if (CVBHoutlistitem.Count != 0)
                                        {
                                            if (CVBHinlistitem == gridZitem.ZGridName + "COLUMN")
                                            {
                                                string MACMemb = string.Empty;
                                                foreach (var mainitem in ReadMDT.MainPropertiesList)
                                                {
                                                    if ((gridZitem.ZGridName == mainitem.ZcorGridName) && (mainitem.MembType == "C" || mainitem.MembType == "S"))
                                                    {
                                                        MACMemb += MACmembersMethod(mainframePrefix, mainitem.ID, mainitem.strCompHashCode, mainitem.Grid,
                                                            mainitem.DRNStart, mainitem.DRNEnd, mainitem.StartX, mainitem.StartY, mainitem.StartZ, mainitem.EndX, mainitem.EndY, mainitem.EndZ,
                                                            mainitem.SectionHeader, mainitem.Section, mainitem.SectionWidth, mainitem.SectionDepth,
                                                            mainitem.JUSLINE, mainitem.Bangle, mainitem.Function, mainitem.ConnTypeS, mainitem.ConnTypeE);
                                                    }
                                                }

                                                string[] strArraySBFR = {
                                                    string.Format("      NEW SBFR  /{0}/S_{1}/COLUMN", mainframePrefix, gridZitem.ZGridName),
                                                    string.Format("          PURP COLN"),
                                                    MACMemb + string.Format("      END\n")
                                                };
                                                SBFR += string.Join("\n", strArraySBFR);
                                            }
                                            else if (CVBHinlistitem == gridZitem.ZGridName + "VBRACE")
                                            {
                                                string MACMemb = string.Empty;
                                                foreach (var mainitem in ReadMDT.MainPropertiesList)
                                                {
                                                    if ((gridZitem.ZGridName == mainitem.ZcorGridName) && (mainitem.MembType == "VB"))
                                                    {
                                                        MACMemb += MACmembersMethod(mainframePrefix, mainitem.ID, mainitem.strCompHashCode, mainitem.Grid,
                                                            mainitem.DRNStart, mainitem.DRNEnd, mainitem.StartX, mainitem.StartY, mainitem.StartZ, mainitem.EndX, mainitem.EndY, mainitem.EndZ,
                                                            mainitem.SectionHeader, mainitem.Section, mainitem.SectionWidth, mainitem.SectionDepth,
                                                            mainitem.JUSLINE, mainitem.Bangle, mainitem.Function, mainitem.ConnTypeS, mainitem.ConnTypeE);
                                                    }
                                                }

                                                string[] strArraySBFR = {
                                                string.Format("      NEW SBFR  /{0}/S_{1}/VBRACE", mainframePrefix, gridZitem.ZGridName),
                                                string.Format("          PURP BRAC"),
                                                MACMemb + string.Format("      END\n")
                                                };
                                                SBFR += string.Join("\n", strArraySBFR);
                                            }
                                        }
                                    }
                                }

                                string[] strArrayFRMW = {
                                                string.Format("    NEW FRMW  /{0}/S_{1}/ELEVIEW", mainframePrefix, gridZitem.ZGridName),
                                                string.Format("        PURP SELE"),
                                                SBFR + string.Format("    END"),
                                            };
                                FRMW += string.Join("\n", strArrayFRMW);
                            }
                            else if (PEVinlistitem == gridZitem.ZGridName + "PLANVIEW")
                            {
                                string SBFR = string.Empty;
                                foreach (var CVBHoutlistitem in ColVBBeamHBList)
                                {
                                    foreach (var CVBHinlistitem in CVBHoutlistitem)
                                    {
                                        if (CVBHoutlistitem.Count != 0)
                                        {
                                            if (CVBHinlistitem == gridZitem.ZGridName + "BEAM")
                                            {
                                                string MACMemb = string.Empty;
                                                foreach (var mainitem in ReadMDT.MainPropertiesList)
                                                {
                                                    if ((gridZitem.ZGridName == mainitem.ZcorGridName) && (mainitem.MembType == "GD" || mainitem.MembType == "JS" || mainitem.MembType == "B" || mainitem.MembType == "PL"))
                                                    {
                                                        MACMemb += MACmembersMethod(mainframePrefix, mainitem.ID, mainitem.strCompHashCode, mainitem.Grid,
                                                            mainitem.DRNStart, mainitem.DRNEnd, mainitem.StartX, mainitem.StartY, mainitem.StartZ, mainitem.EndX, mainitem.EndY, mainitem.EndZ,
                                                            mainitem.SectionHeader, mainitem.Section, mainitem.SectionWidth, mainitem.SectionDepth,
                                                            mainitem.JUSLINE, mainitem.Bangle, mainitem.Function, mainitem.ConnTypeS, mainitem.ConnTypeE);
                                                    }
                                                }

                                                string[] strArraySBFR = {
                                                    string.Format("      NEW SBFR  /{0}/S_{1}/BEAM", mainframePrefix, gridZitem.ZGridName),
                                                    string.Format("          PURP BEAM"),
                                                    MACMemb + string.Format("      END\n")
                                                };
                                                SBFR += string.Join("\n", strArraySBFR);
                                            }
                                            else if (CVBHinlistitem == gridZitem.ZGridName + "HBRACE")
                                            {
                                                string MACMemb = string.Empty;
                                                foreach (var mainitem in ReadMDT.MainPropertiesList)
                                                {
                                                    if ((gridZitem.ZGridName == mainitem.ZcorGridName) && (mainitem.MembType == "HB"))
                                                    {
                                                        MACMemb += MACmembersMethod(mainframePrefix, mainitem.ID, mainitem.strCompHashCode, mainitem.Grid,
                                                            mainitem.DRNStart, mainitem.DRNEnd, mainitem.StartX, mainitem.StartY, mainitem.StartZ, mainitem.EndX, mainitem.EndY, mainitem.EndZ,
                                                            mainitem.SectionHeader, mainitem.Section, mainitem.SectionWidth, mainitem.SectionDepth,
                                                            mainitem.JUSLINE, mainitem.Bangle, mainitem.Function, mainitem.ConnTypeS, mainitem.ConnTypeE);
                                                    }
                                                }

                                                string[] strArraySBFR = {
                                                    string.Format("      NEW SBFR  /{0}/S_{1}/HBRACE", mainframePrefix, gridZitem.ZGridName),
                                                    string.Format("          PURP BRAC"),
                                                    MACMemb + string.Format("      END\n"),
                                                };
                                                SBFR += string.Join("\n", strArraySBFR);
                                            }
                                        }
                                    }
                                }

                                string[] strArrayFRMW = {
                                    string.Format("    NEW FRMW  /{0}/S_{1}/PLANVIEW", mainframePrefix, gridZitem.ZGridName),
                                    string.Format("        PURP SELE"),
                                    SBFR + string.Format("    END"),
                                };
                                FRMW += string.Join("\n", strArrayFRMW);
                            }
                        }
                    }
                }

                string[] strArraySTRU = {
                    string.Format("  NEW STRU  /{0}/STL_FRAME/{1}", mainframePrefix, gridZitem.ZGridName),
                    string.Format("      PURP CSTL"),
                    FRMW,
                    "  END\n"
                };
                STRU += string.Join("\n", strArraySTRU);
            }

            string[] strArrayMACcontentMembers = {
                string.Format("NEW ZONE  /{0}/MAINFRAME", mainframePrefix),
                //sprojectBaseInfo + signature,
                "    PURP STL",
                STRU + "END\n"
            };
            string MACcontentMembers = string.Join("\n", strArrayMACcontentMembers);

            OutputMAC = string.Empty;
            OutputMAC = prependString + MACcontentMembers + appendString;

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

            PlanElevationMembTypeList.Clear();
            foreach (var outlistitem in GridMembList)
            {
                List<string> ELMembTypeList = new List<string>();
                foreach (var inlistitem in outlistitem)
                {
                    ELMembTypeList.Add(inlistitem.GridZEL + inlistitem.MembType);
                }
                ELMembTypeList = ELMembTypeList.Distinct().ToList();
                PlanElevationMembTypeList.Add(ELMembTypeList);
            }

            PlanViewElevationViewList.Clear();
            foreach (var outlistitem in GridMembList)
            {
                List<string> ELPlanElevList = new List<string>();
                foreach (var inlistitem in outlistitem)
                {
                    string PlanViewElevView = string.Empty;
                    if ((inlistitem.MembType == "C") || (inlistitem.MembType == "S") || (inlistitem.MembType == "VB"))
                    {
                        PlanViewElevView = "ELEVIEW";
                    }
                    else if ((inlistitem.MembType == "GD") || (inlistitem.MembType == "JS") || (inlistitem.MembType == "B") || (inlistitem.MembType == "PL") || (inlistitem.MembType == "HB"))
                    {
                        PlanViewElevView = "PLANVIEW";
                    }
                    ELPlanElevList.Add(inlistitem.GridZEL + PlanViewElevView);
                }
                ELPlanElevList = ELPlanElevList.Distinct().ToList();
                PlanViewElevationViewList.Add(ELPlanElevList);
            }

            ColVBBeamHBList.Clear();
            foreach (var outlistitem in GridMembList)
            {
                List<string> innerList = new List<string>();
                foreach (var inlistitem in outlistitem)
                {
                    string ColVBBeamHB = string.Empty;
                    if ((inlistitem.MembType == "C") || (inlistitem.MembType == "S"))
                    {
                        ColVBBeamHB = "COLUMN";
                    }
                    else if (inlistitem.MembType == "VB")
                    {
                        ColVBBeamHB = "VBRACE";
                    }
                    else if ((inlistitem.MembType == "GD") || (inlistitem.MembType == "JS") || (inlistitem.MembType == "B") || (inlistitem.MembType == "PL"))
                    {
                        ColVBBeamHB = "BEAM";
                    }
                    else if (inlistitem.MembType == "HB")
                    {
                        ColVBBeamHB = "HBRACE";
                    }

                    innerList.Add(inlistitem.GridZEL + ColVBBeamHB);
                }
                innerList = innerList.Distinct().ToList();
                ColVBBeamHBList.Add(innerList);
            }
        }

        static string MACmembersMethod(string mainframePrefix, string ID, int strCompHashCode, string Grid, string DRNStart, string DRNEnd, double StartX, double StartY, double StartZ, double EndX, double EndY, double EndZ, string SectionHeader, string Section, string SectionWidth, string SectionDepth, string JUSLINE, double Bangle, string Function, string ConnTypeS, string ConnTypeE)
        {
            string strNewSCTN = string.Format("/{0}/{1}_{2}/#{3}_({4})", mainframePrefix, (SectionHeader == "RC" ? "RC" : "ST"), Grid.Trim(), ID, strCompHashCode); //不可包含空白字元, 總字元數不能超過50
            if (strNewSCTN.Length >= 50)
            {
                strNewSCTN = string.Format("/{0}/{1}/#{2}_({3})", mainframePrefix, (SectionHeader == "RC" ? "RC" : "ST"), ID, strCompHashCode);
            }

            string[] strArrayMACMemb = {
                        string.Format("        NEW SCTN  {0}", strNewSCTN),
                        string.Format("          DRNSTART {0}  DRNEND {1}", DRNStart, DRNEnd),
                        string.Format("          POSS  E{0}      N{1}      U{2}         POSE  E{3}      N{4}      U{5}", StartX.ToString("f2"), StartY.ToString("f2"), StartZ.ToString("f2"), EndX.ToString("f2"), EndY.ToString("f2"), EndZ.ToString("f2")),
                        string.Format("          SPRE  SPCO  /{0}/{1} {2}  {3}", (SectionHeader == "RC" ? "CONCRETE-BEAMS-SPEC" : "CTCV-SPEC"), (SectionHeader == "RC" ? "Rectangular_Profile DESP" : Section), (SectionHeader == "RC" ? SectionDepth : string.Empty), (SectionHeader == "RC" ? SectionWidth : string.Empty)),
                        string.Format("          JUSL  {0}    BANG   {1}  FUNC  '{2}'  DESC  '{3}'", JUSLINE, Bangle.ToString("f2"), Function, Grid),
                        string.Format("          CTYS {0}    CTYE {1}", ConnTypeS, ConnTypeE),
                        "        END\n"
            };
            string MACMemb = string.Join("\n", strArrayMACMemb);
            return MACMemb;
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
