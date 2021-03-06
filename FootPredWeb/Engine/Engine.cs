﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Engine
    {
        IList<Team> m_Teams;

        public Engine()
        {
            BuildTeams();
        }

        private void BuildTeams()
        {
            var teams = new List<Team>();

            foreach (string line in Rankings.AllRankings.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var values = line.Split(',');

                try
                {
                    int[] rankings = new int[]
                    {
                        int.Parse(values[1]), int.Parse(values[3]), int.Parse(values[5]), int.Parse(values[7])
                    };

                    double[] points = new double[]
                    {
                        double.Parse(values[2]), double.Parse(values[4]), double.Parse(values[6]), double.Parse(values[8])
                    };

                    teams.Add(new Team(values[0], rankings, points, 1325));
                }
                catch (System.FormatException)
                {
                    // just continue if we can't read it
                }
            }


            foreach (string line in Elos.AllElos.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] values = line.Split(',');
                double elo = double.Parse(values[1]);

                Team teamToEdit = teams.FirstOrDefault(x => x.Name == values[0]);
                if(teamToEdit != null)
                {
                    teamToEdit.EloPoints = elo;
                }
                else
                {
                    Console.WriteLine(values[0]);
                }
            }

            m_Teams = teams;
        }

        public Tuple<double, double, double> GetMatchProbs(Team team1, Team team2)
        {
            return EloPredictor.GetMatchProbs(team1, team2);
            return GlmLogit1Predictor.GetMatchProbs(team1, team2);
        }

        public double[][] GetScoreGrid(Team team1, Team team2)
        {
            return EloPredictor.GetScoreGrid(team1, team2);
            return GlmLogit1Predictor.GetScoreGrid(team1, team2);
        }

        public Team TeamFromName(string name)
        {
            return m_Teams.FirstOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());
        }
    }
}
