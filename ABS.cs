using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Calculate_Project
{
    internal class simplipy
    {

        internal class ABS // 절대값
        {
            public static double getvalue(double x)
            {
                return Math.Abs(x);
            }
        }


        internal class Round
        {
            public static double getvalue(double x)
            {
                return Math.Round(x);
            }
        }

    }
}

