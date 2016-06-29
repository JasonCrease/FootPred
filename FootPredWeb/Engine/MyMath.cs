using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class MyMath
    {
        public static double Poisson(double lamda, int k)
        {
            return Math.Pow(lamda, k) * Math.Exp(-lamda) / Factorial(k);
        }

        public static int Factorial(int k)
        {
            int total = 1;

            for (int i = 1; i <= k; i++)
                total *= i;

            return total;
        }
    }
}
