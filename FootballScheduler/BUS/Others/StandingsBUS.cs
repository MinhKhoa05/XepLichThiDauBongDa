using System.Collections.Generic;
using DAL.Others;
using DTO;

namespace BUS.Others
{
    public class StandingsBUS
    {
        private readonly StandingsDAL _standingsDAL = new StandingsDAL();

        public List<StandingsDTO> GetAll(string leagueId)
        {
            return _standingsDAL.GetAll(leagueId);
        }

        public void Insert(string league, string teamIds)
        {
            _standingsDAL.Insert(league, teamIds);
        }
    }
}
