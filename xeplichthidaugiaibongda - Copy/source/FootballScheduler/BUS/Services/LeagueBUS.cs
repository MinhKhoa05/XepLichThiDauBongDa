using System;
using System.Collections.Generic;
using BUS.Helpers;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class LeagueBUS
    {
        private readonly LeagueDal _leagueDal;

        public LeagueBUS()
        {
            _leagueDal = new LeagueDal();
        }

        public List<LeagueDTO> GetAll()
        {
            return _leagueDal.GetAll();
        }

        public LeagueDTO GetById(string id)
        {
            return _leagueDal.GetById(id);
        }

        public string Insert(LeagueDTO entity)
        {
           entity.LeagueID = IDGenerator.GenerateID("L", 6, _leagueDal.MaxID());
           return _leagueDal.Insert(entity);
        }
      
        public void Update(LeagueDTO entity)
        {
            _leagueDal.Update(entity);
        }

        public void Delete(string id)
        {
            _leagueDal.Delete(id);
        }

        public void SoftDelete(string id)
        {
            _leagueDal.SoftDelete(id);
        }

        public void Restore(string id)
        {
            _leagueDal.Restore(id);
        }
    }
}
