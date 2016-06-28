using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Engine
    {
        IList<Team> teams;

        public Engine()
        {
            BuildTeams();
        }

        private void BuildTeams()
        {
            teams = new List<Team>();

            using (StreamReader reader = new StreamReader(File.OpenRead(@".\\..\\..\\..\\Files\\rankings.csv")))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
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

                        teams.Add(new Team(values[0], rankings, points));
                    }
                    catch(System.FormatException)
                    {
                        // just continue if we can't read it
                    }
                }
            }
        }

        public Tuple<double, double, double> GetMatchOdds(Team team1, Team team2)
        {
            return GlmLogit1Predictor.GetMatchOdds(team1, team2);
        }

        public double[,] GetScoreGrid(Team team1, Team team2)
        {
            return GlmLogit1Predictor.GetScoreGrid(team1, team2);
        }

        public Team TeamFromName(string name)
        {
            return teams.First(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());            
        }
    }
}
