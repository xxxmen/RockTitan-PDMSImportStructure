﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMSImportStructure
{
    public class MajorProperties
    {
        public int countNo { get; set; }
        //MDL Data properties
        public string ID { get; set; }
        //public string ID { get { return ID; } set { ID = value; } }
        public string PhaseCode { get; set; }
        public string MaterialCode { get; set; }
        public string SectionCode { get; set; }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double StartZ { get; set; }
        public double EndX { get; set; }
        public double EndY { get; set; }
        public double EndZ { get; set; }
        public string Grid { get; set; }
        //Phy Memb Data properties
        public string CompID { get; set; } //比對ID使用
        public string NodeS { get; set; } //重複暫不使用
        public string NodeE { get; set; } //重複暫不使用
        public string MembType { get; set; }
        public string SP { get; set; }
        public double IT { get; set; }
        public string MAT { get; set; } //重複暫不使用
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
        //additional properties
        public string CompSection { get; set; } //比對Section使用
        public string Phase { get; set; }
        public string Material { get; set; }
        public string MaterialGrade { get; set; }
        public double MemberLength { get; set; }
        public string DRNStart { get; set; }
        public string DRNEnd { get; set; }
        public string ConnTypeS { get; set; }
        public string ConnTypeE { get; set; }
        public string SectionHeader { get; set; }
        public string SectionWidth { get; set; }
        public string SectionDepth { get; set; }
        public string SectionType { get; set; }
        public string JUSLINE { get; set; }
        public string Function { get; set; }
        public double Bangle { get; set; }
        public string XcorGridName { get; set; }
        public string XcorGridPosition { get; set; }
        public string YcorGridName { get; set; }
        public string YcorGridPosition { get; set; }
        public string ZcorGridName { get; set; }
        public string ZcorGridElevation { get; set; }
        public int strCompHashCode { get; set; }
    }

    // C# class(類別)是參考型別, struct(結構)是實值型別, 此處需使用struct
    public struct GridXProperties
    {
        public string XGridName { get; set; }
        public double XGridPosition { get; set; }
    }

    public struct GridYProperties
    {
        public string YGridName { get; set; }
        public double YGridPosition { get; set; }
    }

    public struct GridZProperties
    {
        public string ZGridName { get; set; }
        public double ZGridElevation { get; set; }
    }
}
