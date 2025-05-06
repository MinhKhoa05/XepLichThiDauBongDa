using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS.BUSs
{
    public class MatchBUS
    {
        private readonly MatchDAL _matchDal;

        public MatchBUS()
        {
            _matchDal = new MatchDAL();
        }

        public List<MatchView> GetAll(string leagueID = null)
        {
            return _matchDal.GetAll(leagueID);
        }

        public MatchDTO GetById(string id)
        {
            return _matchDal.GetById(id);
        }

        public void InsertRange(List<MatchDTO> matches)
        {
            _matchDal.InsertRange(matches);
        }

        public void Update(MatchDTO match)
        {
            string conflictMatchId = _matchDal.CheckForScheduleConflict(
                match.KickoffDateTime,
                match.LeagueID,
                match.MatchID,
                match.HomeTeamID,
                match.AwayTeamID,
                match.StadiumID,
                match.RefereeID
            );

            if (string.IsNullOrEmpty(conflictMatchId))
            {
                throw new Exception($"Lịch thi đấu bị trùng với trận đấu khác");
            }

            match.Complete = true; // Đặt trạng thái là đã hoàn thành
            _matchDal.Update(match);
        }

        public void DeleteByLeagueID(string leagueID)
        {
            _matchDal.DeleteByLeagueID(leagueID);
        }
    }
}
