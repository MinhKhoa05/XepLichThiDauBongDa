using System.Collections.Generic;
using BUS.Helpers;
using DAL;
using DTO;

namespace BUS.BUSs
{
    public class LeagueBUS
    {
        private readonly LeagueDAL _leagueDal;

        public LeagueBUS()
        {
            _leagueDal = new LeagueDAL();
        }

        public List<LeagueDTO> GetAll()
        {
            return _leagueDal.GetAll();
        }

        public LeagueDTO GetById(string id)
        {
            return _leagueDal.GetById(id);
        }

        public void Insert(LeagueDTO entity)
        {
           entity.LeagueID = IDGenerator.GenerateID("L", 6, _leagueDal.MaxID());
           _leagueDal.Insert(entity);
        }
      
        public void Update(LeagueDTO entity)
        {
            _leagueDal.Update(entity);
        }

        public void Delete(string id)
        {
            _leagueDal.Delete(id);
        }
    }
}
