using System.Collections.Generic;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class MatchBUS
    {
        private readonly MatchDal _matchDal;

        public MatchBUS()
        {
            _matchDal = new MatchDal();
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
            match.Status = 3; // Đặt trạng thái là đã hoàn thành
            _matchDal.Update(match);
        }
    }
}
