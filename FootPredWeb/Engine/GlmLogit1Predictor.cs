using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class GlmLogit1Predictor
    {
        public static Tuple<double, double, double> GetMatchProbs(Team team1, Team team2)
        {
            double team1Home = Logit(team1.FifaPoints[0], team2.FifaPoints[0], 1);
            double team1Away = Logit(team1.FifaPoints[0], team2.FifaPoints[0], 0);
            double team2Home = Logit(team2.FifaPoints[0], team1.FifaPoints[0], 1);
            double team2Away = Logit(team2.FifaPoints[0], team1.FifaPoints[0], 0);
            double drawHome  = LogitDraw(team1.FifaPoints[0], team2.FifaPoints[0], 1);
            double drawAway  = LogitDraw(team1.FifaPoints[0], team2.FifaPoints[0], 0);

            double team1Avg = (team1Home + team1Away) / 2;
            double team2Avg = (team2Home + team2Away) / 2;
            double drawAvg  = (drawHome + drawAway) / 2;

            double normalFactor = team1Avg + team2Avg + drawAvg;

            team1Avg /= normalFactor;
            team2Avg /= normalFactor;
            drawAvg  /= normalFactor;

            return new Tuple<double, double, double>(team1Avg, team2Avg, drawAvg);
        }

        private static double Logit(double fifaPoints1, double fifaPoints2, double atHome)
        {
            double intercept = -0.773421;
            double p1c = 0.002586;
            double p2c = -0.002172;
            double homec = 0.315931;

            return 1 / (1 + Math.Exp(-(intercept + (p1c * fifaPoints1) + (p2c * fifaPoints2) + (homec * atHome))));
        }

        private static double LogitDrawOld(double fifaPoints1, double fifaPoints2, double atHome)
        {
            double intercept = -1.1180;
            double p1c = -0.0001359;
            double p2c = 0.00002147;
            double homec = -0.03053;

            return 1 / (1 + Math.Exp(-(intercept + (p1c * fifaPoints1) + (p2c * fifaPoints2) + (homec * atHome))));
        }

        private static double LogitDraw(double fifaPoints1, double fifaPoints2, double atHome)
        {
            double intercept = -0.7936953;
            double p1Diffc   = -0.0012000;
            double pDiff = Math.Abs(fifaPoints1 - fifaPoints2);

            return 1 / (1 + Math.Exp(-(intercept + (p1Diffc * pDiff))));
        }

        internal static double[][] GetScoreGrid(Team team1, Team team2)
        {
            double team1Win = GetMatchProbs(team1, team2).Item1;
            double team2Win = GetMatchProbs(team1, team2).Item2;

            var poissonParams = ParamFinder.FindParams(team1Win, team2Win);

            double poiss1 = poissonParams.Item1;
            double poiss2 = poissonParams.Item2;

            double[][] retGrid = new double[5][];

            for (int i =0; i< 5; i++)
            {
                retGrid[i] = new double[5];

                for (int j = 0; j < 5; j++)
                    retGrid[i][j] = 1 / (MyMath.Poisson(poiss1, i) * MyMath.Poisson(poiss2, j));
            }

            return retGrid;
        }
    }
}
