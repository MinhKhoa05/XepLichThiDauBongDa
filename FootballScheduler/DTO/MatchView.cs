using System;

namespace DTO
{
    public class MatchView
    {
        public int MatchID { get; private set; }

        public string LeagueName { get; private set; }
        public int RoundNumber { get; private set; }

        public string HomeTeam { get; private set; }
        // Kết quả trận đấu
        public string Result => Complete
            ? string.Format("{0} - {1}", HomeGoals, AwayGoals)
            : "vs";

        public string AwayTeam { get; private set; }
        
        public string StadiumName { get; private set; }
        public string RefereeName { get; private set; }

        private int HomeGoals;
        private int AwayGoals;
        public DateTime KickoffDateTime { get; private set; }
        public bool Complete;

        public MatchView() { }

    }
}
