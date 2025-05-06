using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS.BUSs
{
    public class StandingsBUS
    {
        private readonly StandingsDAL _standingsDAL = new StandingsDAL();

        public List<StandingsDTO> GetAll(string leagueId)
        {
            return _standingsDAL.GetAll(leagueId);
        }

        public void Delete(string leagueId)
        {
            _standingsDAL.Delete(leagueId);
        }

        public void Insert(string league, string teamId)
        {
            _standingsDAL.Insert(league, teamId);
        }
    }
}
