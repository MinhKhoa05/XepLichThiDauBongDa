using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class StandingsDAL
    {
        public List<StandingsDTO> GetAll(string leagueId)
        {
            const string query = @"
                SELECT 
                    s.*, 
                    t.TeamName 
                FROM
                    Standings s
                    INNER JOIN Team t ON t.TeamID = s.TeamID
                WHERE
                    s.LeagueID = @LeagueID
                ORDER BY 
                    s.Points DESC,
                    (s.GoalsScored - s.GoalsConceded) DESC,
                    s.GoalsScored DESC;";

            return DbConnector.QueryList<StandingsDTO>(query, new { LeagueID = leagueId });
        }

        public void Delete(string leagueId)
        {
            const string query = "DELETE FROM Standings WHERE LeagueID = @LeagueID";
            DbConnector.Execute(query, new { LeagueID = leagueId });
        }

        public void Insert(string league, string teamIds)
        {
            string sql = @"
                INSERT INTO Standings (LeagueID, TeamID)
                VALUES (@LeagueID, @TeamID)";

            DbConnector.Execute(sql, new { LeagueID = league, TeamID = teamIds });
        }
    }
}
