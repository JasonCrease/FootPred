using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Engine;

namespace FootPredWeb.Models
{
    public class PredictionsModel
    {
        private Engine.Engine m_Engine;
        public Team Team1 { get; private set; }
        public Team Team2 { get; private set; }
        public Tuple<double, double, double> MatchDigiOdds { get; private set; }
        public Tuple<string, string, string> MatchOldEnglishOdds { get; private set; }
        public Tuple<double, double, double> MatchProbs { get; private set; }
        public double[][] ScoreGrid { get; private set; }

        public PredictionsModel(string team1, string team2)
        {
            m_Engine = new Engine.Engine();

            this.Team1 = m_Engine.TeamFromName(team1);
            this.Team2 = m_Engine.TeamFromName(team2);
        }

        internal void Predict()
        {
            MatchProbs = m_Engine.GetMatchProbs(Team1, Team2);

            MatchDigiOdds = new Tuple<double, double, double>(
                1 / MatchProbs.Item1,
                1 / MatchProbs.Item2,
                1 / MatchProbs.Item3);

            MatchOldEnglishOdds = new Tuple<string, string, string>(
                MatchProbs.Item1.ToOdds(),
                MatchProbs.Item2.ToOdds(),
                MatchProbs.Item3.ToOdds());

            ScoreGrid = m_Engine.GetScoreGrid(Team1, Team2);
        }
    }
}