namespace DTO
{
    public class StandingsDTO
    {
        public string TeamName { get; private set; }
        public int MatchesPlayed { get; private set; }
        public int Wins { get; private set; }
        public int Draws { get; private set; }
        public int Losses { get; private set; }

        public int GoalsScored { get; private set; }
        public int GoalsConceded { get; private set; }
        public int GoalDiff => GoalsScored - GoalsConceded;
        public int Points { get; private set; }

        public StandingsDTO() { }
    }
}
