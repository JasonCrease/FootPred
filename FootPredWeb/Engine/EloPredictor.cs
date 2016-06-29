using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class EloPredictor
    {
        internal static Tuple<double, double, double> GetMatchProbs(Team team1, Team team2)
        {
            double dr = team1.EloPoints - team2.EloPoints;
            double winProb1 = 1 / (Math.Pow(10, -dr / 400) + 1);
            double winProb2 = 1 / (Math.Pow(10,  dr / 400) + 1);

            // Between evenly matched teams, approximately 25% of games end in draws. This is a rough approximation to that derived
            // by logistic regression in R
            double drawProb = 1 / (1 + Math.Exp(-(
                -3.5 +
                (4.3* Math.Sqrt(winProb1 * winProb2) + 
                (1.06 * winProb1)
             ))));

            // Rebalance
            double total = winProb1 + winProb2 + drawProb;
            winProb1 = winProb1 / total;
            winProb2 = winProb2 / total;
            drawProb = drawProb / total;

            return new Tuple<double, double, double>(winProb1, winProb2, drawProb);
        }

        internal static double[][] GetScoreGrid(Team team1, Team team2)
        {
            double team1Win = GetMatchProbs(team1, team2).Item1;
            double team2Win = GetMatchProbs(team1, team2).Item2;
            double goalsPerGame = 2.247 + 0.00085 * Math.Abs(team2.FifaPoints[0] - team1.FifaPoints[0]);

            var poissonParams = ParamFinder.FindParams(team1Win, team2Win, goalsPerGame);

            double poiss1 = poissonParams.Item1;
            double poiss2 = poissonParams.Item2;

            int gridSize = 5;

            double[][] retGrid = new double[gridSize][];

            for (int i = 0; i < gridSize; i++)
            {
                retGrid[i] = new double[gridSize];

                for (int j = 0; j < gridSize; j++)
                    retGrid[i][j] = (MyMath.Poisson(poiss1, i) * MyMath.Poisson(poiss2, j));
            }

            return retGrid;
        }

    }
}
