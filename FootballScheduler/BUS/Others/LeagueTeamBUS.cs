using System.Collections.Generic;
using DAL.Others;

namespace BUS.Others
{
    public class LeagueTeamBUS
    {
        private readonly LeagueTeamDAL _leagueTeamDAL = new LeagueTeamDAL();

        /// <summary>
        /// Lấy danh sách các đội bóng trong một giải đấu.
        /// </summary>
        public List<string> GetTeamsByLeagueID(string leagueID)
        {
            return _leagueTeamDAL.GetTeamsByLeagueID(leagueID);
        }

        /// <summary>
        /// Thêm các đội vào giải đấu, xóa các đội cũ trước khi thêm.
        /// </summary>
        public void AddTeamToLeague(string leagueID, List<string> teamIDs)
        {
            // Xóa tất cả đội cũ trong giải đấu trước khi thêm đội mới.   
            _leagueTeamDAL.RemoveTeamsFromLeague(leagueID);

            // Thêm tất cả đội vào giải đấu.
            foreach (var teamID in teamIDs)
            {
                _leagueTeamDAL.AddTeamToLeague(leagueID, teamID);
                //(new StandingsDAL()).Insert(leagueID, teamID); // Cập nhật bảng xếp hạng sau khi thêm đội
            }

        }

        /// <summary>
        /// Xóa tất cả đội khỏi một giải đấu.
        /// </summary>
        public void RemoveTeamsFromLeague(string leagueID)
        {
            _leagueTeamDAL.RemoveTeamsFromLeague(leagueID);
        }
    }
}