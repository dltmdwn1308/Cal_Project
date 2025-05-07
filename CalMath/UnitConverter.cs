using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Project.CalMath
{
    public class UnitConverter
    {
        // 질량 변환
        public double LbToG(double lb)
        {
            return lb * 453.592;
        }

        public double GToLb(double g)
        {
            return g / 453.592;
        }

        public double OzToG(double oz)
        {
            return oz * 28.3495;
        }

        public double GToOz(double g)
        {
            return g / 28.3495;
        }

        // 길이 변환
        public double InchToM(double inch)
        {
            return inch / 39.3701;
        }

        public double MToInch(double m)
        {
            return m * 39.3701;
        }

        public double FtToM(double ft)
        {
            return ft / 3.28084;
        }

        public double MToFt(double m)
        {
            return m * 3.28084;
        }

    }
}


