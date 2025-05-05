using System.Collections.Generic;
using DAL.Helpers;

namespace DAL.Others
{
    public class LeagueTeamDAL
    {
        #region GET Methods

        /// <summary>
        /// Lấy danh sách ID của các đội bóng trong một giải đấu.
        /// </summary>
        public List<string> GetTeamsByLeagueID(string leagueID)
        {
            const string sql = "SELECT TeamID FROM League_Team WHERE LeagueID = @LeagueID";
            return DbConnector.QueryList<string>(sql, new { LeagueID = leagueID });
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// Thêm đội vào giải đấu
        /// </summary>
        public void AddTeamToLeague(string leagueID, string teamID)
        {
            const string sql = "INSERT INTO League_Team (LeagueID, TeamID) VALUES (@LeagueID, @TeamID)";
            DbConnector.Execute(sql, new { LeagueID = leagueID, TeamID = teamID });
        }

        /// <summary>
        /// Xóa tất cả đội khỏi một giải đấu.
        /// </summary>
        public void RemoveTeamsFromLeague(string leagueID)
        {
            const string sql = "DELETE FROM League_Team WHERE LeagueID = @LeagueID";
            DbConnector.Execute(sql, new { LeagueID = leagueID });
        }

        #endregion
    }
}