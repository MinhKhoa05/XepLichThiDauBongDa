using System.Collections.Generic;
using DTO;
using DAL.Helpers;

namespace DAL.Others
{
    public class StandingsDAL
    {
        /// <summary>
        /// Lấy tất cả bảng xếp hạng của giải đấu theo ID giải đấu và sắp xếp theo điểm.
        /// </summary>
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

        public void Insert(string league, string teamIds)
        {
            string sql = @"
                INSERT INTO Standings (LeagueID, TeamID)
                VALUES (@LeagueID, @TeamID)";

            DbConnector.Execute(sql, new { LeagueID = league, TeamID = teamIds });
        }
    }
}
