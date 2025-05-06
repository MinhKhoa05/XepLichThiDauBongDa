using System;

namespace DTO
{
    public class MatchDTO
    {
        public string MatchID { get; set; }

        public string LeagueID { get; set; }
        public byte RoundNumber { get; set; }
        public DateTime KickoffDateTime { get; set; }
        public bool Complete { get; set; }
        
        public string HomeTeamID { get; set; }
        public string AwayTeamID { get; set; }
        public byte HomeGoals { get; set; }
        public byte AwayGoals { get; set; }

        public string StadiumID { get; set; }
        public string RefereeID { get; set; }

        public MatchDTO() { }

        public MatchDTO(
            string leagueID,
            byte roundNumber,
            string homeTeamID,
            string awayTeamID,
            DateTime kickoffDateTime,
            string stadiumID)
        {
            LeagueID = leagueID;
            RoundNumber = roundNumber;
            HomeTeamID = homeTeamID;
            AwayTeamID = awayTeamID;
            KickoffDateTime = kickoffDateTime;
            StadiumID = stadiumID;
        }
    }
}
