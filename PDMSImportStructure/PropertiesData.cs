﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMSImportStructure
{
    public struct MajorProperties
    {
        public string ID { get; set; }
        public string MaterialCode { get; set; }
        public string SectionCode { get; set; }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double StartZ { get; set; }
        public double EndX { get; set; }
        public double EndY { get; set; }
        public double EndZ { get; set; }
        public string Grid { get; set; }

        public string CompID { get; set; } //比對ID使用
        public string NodeS { get; set; } //重複暫不使用
        public string NodeE { get; set; } //重複暫不使用
        public string Type { get; set; }
        public string SP { get; set; }
        public double IT { get; set; } //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
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

        public string CompSection { get; set; } //重複暫不使用
        public string Material { get; set; }
        public string MaterialGrade { get; set; }
    }

    //public struct MinorProperties
    //{
    //    public string CompID { get; set; } //比對ID使用
    //    public string NodeS { get; set; } //重複暫不使用
    //    public string NodeE { get; set; } //重複暫不使用
    //    public string Type { get; set; }
    //    public string SP { get; set; }
    //    public double IT { get; set; } //將考慮直接填入轉角, 就不需轉換OvX, OvY, OvZ
    //    public string MAT { get; set; } //重複暫不使用
    //    public string CP { get; set; } // 1~10
    //    public string Reflect { get; set; } // Y/N
    //    public double OvX { get; set; }
    //    public double OvY { get; set; }
    //    public double OvZ { get; set; }
    //    public string ReleaseS { get; set; }
    //    public string ReleaseSNo { get; set; }
    //    public string ReleaseE { get; set; }
    //    public string ReleaseENo { get; set; }
    //    public double SR { get; set; } //stress ratio, no use for PDMS
    //    public string Section { get; set; }
    //}

    //public struct MaterialList
    //{
    //    public string MatItemNo { get; set; }
    //    public string MatCode { get; set; }
    //    public string MatGrade { get; set; }
    //}

    //public struct MaterialTypeList
    //{
    //    public string MatCodeNo { get; set; }
    //    public string Material { get; set; }
    //}

    //public struct SectionList
    //{
    //    public string SectionItemNo { get; set; } //重複暫不使用
    //    public string CompSection { get; set; } //重複暫不使用
    //}
}
