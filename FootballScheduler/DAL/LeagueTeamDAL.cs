using System.Collections.Generic;

namespace DAL
{
    public class LeagueTeamDAL
    {
        public List<string> GetTeamsByLeagueID(string leagueID)
        {
            const string sql = "SELECT TeamID FROM League_Team WHERE LeagueID = @LeagueID";
            return DbConnector.QueryList<string>(sql, new { LeagueID = leagueID });
        }

        public void AddTeamToLeague(string leagueID, string teamID)
        {
            const string sql = "INSERT INTO League_Team (LeagueID, TeamID) VALUES (@LeagueID, @TeamID)";
            DbConnector.Execute(sql, new { LeagueID = leagueID, TeamID = teamID });
        }
        
        public void RemoveTeamsFromLeague(string leagueID)
        {
            const string sql = "DELETE FROM League_Team WHERE LeagueID = @LeagueID";
            DbConnector.Execute(sql, new { LeagueID = leagueID });
        }
    }
}