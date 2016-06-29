namespace Engine
{
    public class Team
    {
        public string Name;

        // now is 0, 2016 is 1, 2015 is 2, etc
        int[]      m_FifaRankings;
        double     m_EloPoints;
        double[]   m_FifaPoints;

        public int[] FifaRankings
        {
            get
            {
                return m_FifaRankings;
            }
        }

        public double[] FifaPoints
        {
            get
            {
                return m_FifaPoints;
            }
        }
        public double EloPoints
        {
            get
            {
                return m_EloPoints;
            }
            set
            {
                m_EloPoints = value;
            }
        }

        public Team(string name, int[] fifaRankings, double[] fifaPoints, double eloPoints)
        {
            Name = name;
            m_FifaRankings = fifaRankings;
            m_FifaPoints = fifaPoints;
            m_EloPoints = eloPoints;
        }
    }
}