using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Project
{
    internal class combi
    {
        public int n, r;
        public double result;

        public static long Factorial(int X)
        {
            if (X <= 1)
            {
                return 1;
            }
            return X * Factorial(X - 1);
        }


        public static long Combination(int n, int r) // 조합
        {
            if (r < 0 || r > n)
            {
                return -1;
            }
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }


        public static long Perm(int N, int R)
        {
            if (R < 0 || R > N)
            {
                return -1;
            }
            return Factorial(N) / Factorial(R);
        }
    }
}    

