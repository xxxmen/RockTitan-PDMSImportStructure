using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDMSImportStructure
{
    public class CompareCardinalPoint
    {
        public static string GetJustificationLine(string SectionHeader, string CP, out string SectionType)
        {
            //依照斷面名稱頭判斷Type
            SectionType = string.Empty;
            if (SectionHeader == "H" || SectionHeader == "HE" || SectionHeader == "HEA"
                || SectionHeader == "HEB" || SectionHeader == "HM" || SectionHeader == "HN"
                || SectionHeader == "HP" || SectionHeader == "HSA" || SectionHeader == "HSH"
                || SectionHeader == "HW" || SectionHeader == "I" || SectionHeader == "IPE"
                || SectionHeader == "IPN" || SectionHeader == "ISHB" || SectionHeader == "ISJB"
                || SectionHeader == "ISLB" || SectionHeader == "ISMB" || SectionHeader == "ISWB"
                || SectionHeader == "M" || SectionHeader == "S" || SectionHeader == "UB"
                || SectionHeader == "UBP" || SectionHeader == "UC" || SectionHeader == "UI"
                || SectionHeader == "W" || SectionHeader == "WF")
            {
                SectionType = "H";
            }
            else if (SectionHeader == "BDC" || SectionHeader == "BH")
            {
                SectionType = "BH";
            }
            else if (SectionHeader == "BOX" || SectionHeader == "FB" || SectionHeader == "SB" || SectionHeader == "RC")
            {
                SectionType = "RC-BOX-FB-SB";
            }
            else if (SectionHeader == "C" || SectionHeader == "ISJC" || SectionHeader == "ISLC"
                || SectionHeader == "ISMC" || SectionHeader == "LC" || SectionHeader == "LPC"
                || SectionHeader == "MC" || SectionHeader == "PFC" || SectionHeader == "RSC"
                || SectionHeader == "U" || SectionHeader == "UPN")
            {
                SectionType = "C";
            }
            else if (SectionHeader == "2C" || SectionHeader == "2MC" || SectionHeader == "2UPN" || SectionHeader == "ISM2C")
            {
                SectionType = "2C";
            }
            else if (SectionHeader == "ISHT" || SectionHeader == "ISJT" || SectionHeader == "ISLT"
                || SectionHeader == "ISMBT" || SectionHeader == "ISNT" || SectionHeader == "ISST"
                || SectionHeader == "T" || SectionHeader == "TM" || SectionHeader == "TN" || SectionHeader == "TW"
                || SectionHeader == "UBT" || SectionHeader == "UCT" || SectionHeader == "WT")
            {
                SectionType = "T";
            }
            else if (SectionHeader == "2T")
            {
                SectionType = "2T";
            }
            else if (SectionHeader == "ISA" || SectionHeader == "L" || SectionHeader == "RSA")
            {
                SectionType = "L";
            }
            else if (SectionHeader == "2L" || SectionHeader == "2LC" || SectionHeader == "2RSA" || SectionHeader == "LL" || SectionHeader == "SL")
            {
                SectionType = "2L";
            }
            else if (SectionHeader == "XH")
            {
                SectionType = "XH";
            }
            else if (SectionHeader == "O" || SectionHeader == "PIP" || SectionHeader == "PIPE" || SectionHeader == "RCP")
            {
                SectionType = "PIPE";
            }
            else if (SectionHeader == "TTUB" || SectionHeader == "TUB" || SectionHeader == "TUBE")
            {
                SectionType = "TUBE";
            }
            else if (SectionHeader == "RB")
            {
                SectionType = "RB";
            }
            else if (SectionHeader == "RCD")
            {
                SectionType = "RCD";
            }


            //JUSLINE / JUSL - Justification Line
            string JUSLINE = string.Empty;
            if (SectionType == "H" || SectionType == "BH" || SectionType == "T") //Generic Type: BEAM, TEE
            {
                if (CP == "1") { JUSLINE = "LBOS"; }
                else if (CP == "2") { JUSLINE = "BOS"; }
                else if (CP == "3") { JUSLINE = "RBOS"; }
                else if (CP == "4") { JUSLINE = "NALO"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "NARO"; }
                else if (CP == "7") { JUSLINE = "LTOS"; }
                else if (CP == "8") { JUSLINE = "TOS"; }
                else if (CP == "9") { JUSLINE = "RTOS"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }
            }
            else if (SectionType == "XH") //Generic Type: BEAM, TEE
            {
                if (CP == "1") { JUSLINE = "LBOS"; }
                else if (CP == "2") { JUSLINE = "BOS"; }
                else if (CP == "3") { JUSLINE = "RBOS"; }
                else if (CP == "4") { JUSLINE = "NALO"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "NARO"; }
                else if (CP == "7") { JUSLINE = "LTOS"; }
                else if (CP == "8") { JUSLINE = "TOS"; }
                else if (CP == "9") { JUSLINE = "RTOS"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }
            }
            else if (SectionType == "2T") //Generic Type: BEAM, TEE
            {
                if (CP == "1") { JUSLINE = "LBOS"; }
                else if (CP == "2") { JUSLINE = "BOS"; }
                else if (CP == "3") { JUSLINE = "RBOS"; }
                else if (CP == "4") { JUSLINE = "NALO"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "NARO"; }
                else if (CP == "7") { JUSLINE = "LTOS"; }
                else if (CP == "8") { JUSLINE = "TOS"; }
                else if (CP == "9") { JUSLINE = "RTOS"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }
            }
            else if (SectionType == "RC-BOX-FB-SB") //Generic Type: BOX
            {
                if (CP == "1") { JUSLINE = "LBOS"; }
                else if (CP == "2") { JUSLINE = "BOS"; }
                else if (CP == "3") { JUSLINE = "RBOS"; }
                else if (CP == "4") { JUSLINE = "LEFT"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "RIGH"; }
                else if (CP == "7") { JUSLINE = "LTOS"; }
                else if (CP == "8") { JUSLINE = "TOS"; }
                else if (CP == "9") { JUSLINE = "RTOS"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }
            }
            else if (SectionType == "C") //Generic Type: BSC, DINU //TODO:很亂待確認
            {
                if (CP == "1") { JUSLINE = "LBOC"; }
                else if (CP == "2") { JUSLINE = "BOC"; }
                else if (CP == "3") { JUSLINE = "RBOC"; }
                else if (CP == "4") { JUSLINE = "FOC"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "ROC"; }
                else if (CP == "7") { JUSLINE = "LTOC"; }
                else if (CP == "8") { JUSLINE = "TOC"; }
                else if (CP == "9") { JUSLINE = "RTOC"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }

                //check C orientation
                //if (CP == "1") { JUSLINE = "LTOC"; }
                //else if (CP == "2") { JUSLINE = "TOC"; }
                //else if (CP == "3") { JUSLINE = "RTOC"; }
                //else if (CP == "4") { JUSLINE = "FOC"; }
                //else if (CP == "5") { JUSLINE = "NA"; }
                //else if (CP == "6") { JUSLINE = "ROC"; }
                //else if (CP == "7") { JUSLINE = "LBOC"; }
                //else if (CP == "8") { JUSLINE = "BOC"; }
                //else if (CP == "9") { JUSLINE = "RBOC"; }
                //else if (CP == "10") { JUSLINE = "NA"; }
                //else { JUSLINE = "NA"; }
            }
            else if (SectionType == "L") //Generic Type: ANG //TODO:很亂待確認
            {
                if (CP == "1") { JUSLINE = "TOAX"; }
                else if (CP == "2") { JUSLINE = "NAT"; }
                else if (CP == "3") { JUSLINE = "RTTA"; }
                else if (CP == "4") { JUSLINE = "NAL"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "NA"; }
                else if (CP == "7") { JUSLINE = "LBOA"; }
                else if (CP == "8") { JUSLINE = "NA"; }
                else if (CP == "9") { JUSLINE = "NA"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }

                //check L orientation
                //if (CP == "1") { JUSLINE = "LBOA"; }
                //else if (CP == "2") { JUSLINE = "NAB"; }
                //else if (CP == "3") { JUSLINE = "RBOA"; }
                //else if (CP == "4") { JUSLINE = "NAL"; }
                //else if (CP == "5") { JUSLINE = "NA"; }
                //else if (CP == "6") { JUSLINE = "NAR"; }
                //else if (CP == "7") { JUSLINE = "TOAX"; }
                //else if (CP == "8") { JUSLINE = "NAT"; }
                //else if (CP == "9") { JUSLINE = "RTTA"; }
                //else if (CP == "10") { JUSLINE = "NA"; }
                //else { JUSLINE = "NA"; }
            }
            else if (SectionType == "PIPE" || SectionType == "TUBE" || SectionType == "RB" || SectionType == "RCD") //Generic Type: TUBE
            {
                if (CP == "1") { JUSLINE = "PP"; }
                else if (CP == "2") { JUSLINE = "SS"; }
                else if (CP == "3") { JUSLINE = "VV"; }
                else if (CP == "4") { JUSLINE = "MM"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "AA"; }
                else if (CP == "7") { JUSLINE = "JJ"; }
                else if (CP == "8") { JUSLINE = "GG"; }
                else if (CP == "9") { JUSLINE = "DD"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }
            }
            else if (SectionType == "2C") //Generic Type: BSC, DINU (4, 5, 6對NA) //TODO:很亂待確認
            {
                if (CP == "1") { JUSLINE = "LBOC"; }
                else if (CP == "2") { JUSLINE = "BOC"; }
                else if (CP == "3") { JUSLINE = "RBOC"; }
                else if (CP == "4") { JUSLINE = "NA"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "NA"; }
                else if (CP == "7") { JUSLINE = "LTOC"; }
                else if (CP == "8") { JUSLINE = "TOC"; }
                else if (CP == "9") { JUSLINE = "RTOC"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }
            }
            else if (SectionType == "2L") //Generic Type: ANG //TODO:很亂待確認
            {
                if (CP == "1") { JUSLINE = "RTTA"; }
                else if (CP == "2") { JUSLINE = "NAT"; }
                else if (CP == "3") { JUSLINE = "TOAY"; }
                else if (CP == "4") { JUSLINE = "NA"; }
                else if (CP == "5") { JUSLINE = "NA"; }
                else if (CP == "6") { JUSLINE = "NA"; }
                else if (CP == "7") { JUSLINE = "LBOA"; }
                else if (CP == "8") { JUSLINE = "NA"; }
                else if (CP == "9") { JUSLINE = "NA"; }
                else if (CP == "10") { JUSLINE = "NA"; }
                else { JUSLINE = "NA"; }

                //check L orientation
                //if (CP == "1") { JUSLINE = "LBOA"; }
                //else if (CP == "2") { JUSLINE = "NAB"; }
                //else if (CP == "3") { JUSLINE = "RBOA"; }
                //else if (CP == "4") { JUSLINE = "NAL"; }
                //else if (CP == "5") { JUSLINE = "NA"; }
                //else if (CP == "6") { JUSLINE = "NAR"; }
                //else if (CP == "7") { JUSLINE = "TOAX"; }
                //else if (CP == "8") { JUSLINE = "NAT"; }
                //else if (CP == "9") { JUSLINE = "RTTA"; }
                //else if (CP == "10") { JUSLINE = "NA"; }
                //else { JUSLINE = "NA"; }
            }

            return JUSLINE;
        }
    }
}
