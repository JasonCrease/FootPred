using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Engine engine = new Engine.Engine();

            Team team1 = engine.TeamFromName("Belgium");
            Team team2 = engine.TeamFromName("Germany");

            var probs = engine.GetMatchProbs(team1, team2);
            var scoreGrid = engine.GetScoreGrid(team1, team2);
        }
    }
}
