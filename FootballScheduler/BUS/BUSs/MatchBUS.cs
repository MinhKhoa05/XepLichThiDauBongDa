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
            _matchDal.Update(match);
        }

        public void DeleteByLeagueID(string leagueID)
        {
            _matchDal.DeleteByLeagueID(leagueID);
            (new LeagueTeamDAL()).RemoveTeamsFromLeague(leagueID);
        }

        public List<MatchView> Filter(string kw)
        {
            return _matchDal.Filter(kw);
        }
    }
}
