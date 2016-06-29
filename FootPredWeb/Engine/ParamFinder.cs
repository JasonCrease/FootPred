using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class ParamFinder
    {
        /// <summary>
        /// Given probabilities p1 and p2 of player 1 winning and player 2 winning respectively, find the necessary parameters of the poisson distribution
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Tuple<double, double> FindParams(double p1, double p2)
        {
            double bestParam1 = 0;
            double bestParam2 = 0;
            double bestParam1Cum = 0;
            double bestParam2Cum = 0;

            double goalsPerGame = 2.4;

            for (double tp1 = 0; tp1 < goalsPerGame; tp1 += 0.1)
                {
                    double tp2 = goalsPerGame - tp1;

                    double cum1 = 0;
                    double cum2 = 0;

                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                        {
                            if (i > j)
                                cum1 += MyMath.Poisson(tp1, i) * MyMath.Poisson(tp2, j);
                            if (i < j)
                                cum2 += MyMath.Poisson(tp1, i) * MyMath.Poisson(tp2, j);
                        }

                    if (Math.Abs(cum1 - p1) + Math.Abs(cum2 - p2) < Math.Abs(bestParam1Cum - p1) + Math.Abs(bestParam2Cum - p2))
                    {
                        bestParam1 = tp1;
                        bestParam1Cum = cum1;
                        bestParam2 = tp2;
                        bestParam2Cum = cum2;
                    }

                }
             return new Tuple<double, double>(bestParam1, bestParam2);
        }

    }
}
