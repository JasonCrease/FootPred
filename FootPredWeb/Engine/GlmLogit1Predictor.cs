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
            double team1prob = Logit(team1.FifaPoints[0], team2.FifaPoints[0], 0);
            double team2prob = Logit(team2.FifaPoints[0], team1.FifaPoints[0], 1);
            double drawprob = LogitDraw(team1.FifaPoints[0], team2.FifaPoints[0], 0);
            
            double normalFactor = team1prob + team2prob + drawprob;

            team1prob /= normalFactor;
            team2prob /= normalFactor;
            drawprob /= normalFactor;

            return new Tuple<double, double, double>(team1prob, team2prob, drawprob);
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
            double goalsPerGame = 2.247 + 0.00085 * Math.Abs(team2.FifaPoints[0] - team1.FifaPoints[0]);

            var poissonParams = ParamFinder.FindParams(team1Win, team2Win, goalsPerGame);

            double poiss1 = poissonParams.Item1;
            double poiss2 = poissonParams.Item2;

            double[][] retGrid = new double[6][];

            for (int i =0; i< 6; i++)
            {
                retGrid[i] = new double[6];

                for (int j = 0; j < 6; j++)
                    retGrid[i][j] = (MyMath.Poisson(poiss1, i) * MyMath.Poisson(poiss2, j));
            }

            return retGrid;
        }
    }
}
