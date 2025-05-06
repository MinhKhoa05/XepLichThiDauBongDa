using System.Collections.Generic;
using DAL;

namespace BUS.BUSs
{
    public class LeagueTeamBUS
    {
        private readonly LeagueTeamDAL _leagueTeamDAL = new LeagueTeamDAL();
        private readonly StandingsDAL _standingsDAL = new StandingsDAL();
        
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
            _standingsDAL.Delete(leagueID); // Xóa bảng xếp hạng cũ trước khi thêm mới

            // Thêm tất cả đội vào giải đấu.
            foreach (var teamID in teamIDs)
            {
                _leagueTeamDAL.AddTeamToLeague(leagueID, teamID);
                _standingsDAL.Insert(leagueID, teamID); // Cập nhật bảng xếp hạng sau khi thêm đội
            }
        }
    }
}