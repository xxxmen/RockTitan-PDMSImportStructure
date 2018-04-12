using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace PDMSImportStructure
{
    public class ConvertOrientationVector
    {
        public static double OvtoBangle(double StartX, double StartY, double StartZ, double EndX, double EndY, double EndZ, double OvX, double OvY, double OvZ)
        {
            double OvLength = Math.Sqrt(Math.Pow(OvX, 2) + Math.Pow(OvY, 2) + Math.Pow(OvZ, 2)); //應皆為1
            double Bangle = 0;
            
            if (StartZ == EndZ) //(X-Y)-Plane
            {
                Bangle = Math.Acos(OvZ / OvLength) * 180 / Math.PI;

                if (StartY == EndY) //Beam along X-axis
                {
                    if (EndX > StartX)
                    {
                        if (OvY > 0) { Bangle = 360 - Bangle; }
                        else if (OvY < 0) { Bangle = 360 - Bangle; }
                    }
                }
                else if (StartX == EndX) //Beam along Y-axis
                {
                    if (EndY > StartY)
                    {
                        if (OvX > 0) { Bangle = 360 - Bangle; }
                        else if (OvX < 0) { Bangle = 360 - Bangle; }
                    }
                }
                else //horizontal brace, skew beam
                {
                    if (EndY > StartY)
                    {
                        if (OvX > 0) { Bangle = 360 - Bangle; }
                        else if (OvX < 0) { Bangle = 360 - Bangle; }
                    }
                }
            }
            else if (StartX == EndX) //(Y-Z)-Plane
            {
                Bangle = Math.Acos(OvX / OvLength) * 180 / Math.PI;

                if (StartY == EndY) //Beam along Z-axis
                {
                    if (EndZ > StartZ)
                    {
                        if (OvY >= 0) { Bangle = Bangle - 90; }
                        else { Bangle = 270 - Bangle; }
                    }
                    else
                    {
                        Bangle = Math.Acos(-OvX / OvLength) * 180 / Math.PI;

                        if (OvY >= 0) { Bangle = Bangle - 90; }
                        else { Bangle = 270 - Bangle; }
                    }
                }
                else //vertical bracing not check
                {
                    if (EndY > StartY)
                    {
                        if (OvZ >= 0) { Bangle = 270 + Math.Acos(-OvX / OvLength) * 180 / Math.PI; }
                        else { Bangle = 90 + Bangle; }
                    }
                    else
                    {
                        if (OvZ >= 0) { Bangle = 270 + Bangle; }
                        else { Bangle = 90 + Math.Acos(-OvX / OvLength) * 180 / Math.PI; }
                    }
                }
            }
            else if (StartY == EndY) //(X-Z)-Plane , vertical bracing not check
            {
                Bangle = Math.Acos(OvY / OvLength) * 180 / Math.PI;

                if (EndX > StartX)
                {
                    if (OvZ >= 0) { Bangle = 270 + Bangle; }
                    else { Bangle = 90 + Math.Acos(-OvY / OvLength) * 180 / Math.PI; }
                }
                else
                {
                    if (OvZ >= 0) { Bangle = 270 + Math.Acos(-OvY / OvLength) * 180 / Math.PI; }
                    else { Bangle = 90 + Bangle; }
                }
            }
            else
            {
                Bangle = 0;
            }
            return Bangle;
        }

        public static double OvtoBangleTest(double OvX, double OvY, double OvZ)
        {
            //TODO:測試方法部分不正確
            double Bangle = 0;

            if ((OvX == 0 && OvY == 0 && OvZ != 0) || (OvX == 0 && OvY != 0 && OvZ == 0) || (OvX != 0 && OvY == 0 && OvZ == 0))
            {
                Bangle = 0;
            }
            else if (OvX == 0)
            {
                Bangle = Math.Round(Math.Atan(OvY / OvZ) * 180 / Math.PI, 2);
            }
            else if (OvY == 0)
            {
                Bangle = Math.Round(Math.Atan(OvX / OvZ) * 180 / Math.PI, 2);
            }
            else if (OvZ == 0)
            {
                Bangle = Math.Round(Math.Atan(OvX / OvY) * 180 / Math.PI, 2);
            }
            return Bangle;
        }

    }
}
