using System.Collections.Generic;
using BUS.Helpers;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class TeamBUS
    {
        private readonly TeamDal _teamDal;

        public TeamBUS()
        {
            _teamDal = new TeamDal(); // Tạo đối tượng DAL để thực hiện các thao tác với cơ sở dữ liệu
        }

        // Lấy tất cả các đội bóng
        public List<TeamDTO> GetAll()
        {
            return _teamDal.GetAll();
        }

        // Lấy đội bóng theo ID
        public TeamDTO GetById(string id)
        {
            return _teamDal.GetById(id);
        }

        // Thêm mới đội bóng
        public string Insert(TeamDTO team)
        {
            team.TeamID = IDGenerator.GenerateID("T", 6, _teamDal.MaxID());
            return _teamDal.Insert(team);
        }


        // Cập nhật đội bóng
        public void Update(TeamDTO team)
        {
            _teamDal.Update(team);
        }

        // Xóa đội bóng
        public void Delete(string id)
        {
            _teamDal.Delete(id);
        }
    }
}
