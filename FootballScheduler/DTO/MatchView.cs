using System;

namespace DTO
{
    public class MatchView
    {
        public string MatchID { get; private set; }

        public string LeagueName { get; private set; }  // có thể là LeagueID nếu không join
        public int RoundNumber { get; private set; }

        public string HomeTeam { get; private set; }    // có thể là HomeTeamID nếu không join
        public string AwayTeam { get; private set; }

        public string StadiumName { get; private set; } // có thể là StadiumID nếu không join
        public string RefereeName { get; private set; } // có thể là RefereeID nếu không join

        private int HomeGoals;
        private int AwayGoals;
        public DateTime KickoffDateTime { get; private set; }

        public bool Complete { get; private set; }

        // Hiển thị kết quả
        public string Result => Complete ? $"{HomeGoals} - {AwayGoals}" : "vs";

        public MatchView() { }

        // Constructor nhận MatchDTO
        public MatchView(MatchDTO dto)
        {
            MatchID = dto.MatchID;
            LeagueName = dto.LeagueID;
            RoundNumber = dto.RoundNumber;

            HomeTeam = dto.HomeTeamID;
            AwayTeam = dto.AwayTeamID;
            RefereeName = dto.RefereeID;
            StadiumName = dto.StadiumID;

            HomeGoals = dto.HomeGoals;
            AwayGoals = dto.AwayGoals;
            KickoffDateTime = dto.KickoffDateTime;
            Complete = dto.Complete;
        }
    }
}
