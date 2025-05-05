using System.Collections.Generic;
using BUS.Helpers;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class StadiumBUS
    {
        private readonly StadiumDal _stadiumDal;

        public StadiumBUS()
        {
            _stadiumDal = new StadiumDal(); // Tạo đối tượng DAL để truy vấn cơ sở dữ liệu
        }

        // Lấy tất cả sân vận động
        public List<StadiumDTO> GetAll()
        {
            return _stadiumDal.GetAll();
        }

        // Lấy sân vận động theo ID
        public StadiumDTO GetById(string id)
        {
            return _stadiumDal.GetById(id);
        }

        // Thêm mới sân vận động
        public string Insert(StadiumDTO stadium)
        {
            stadium.StadiumID = IDGenerator.GenerateID("S", 6, _stadiumDal.MaxID());
            _stadiumDal.Insert(stadium);
            return stadium.StadiumID; // Trả về ID mới
        }

        // Cập nhật thông tin sân vận động
        public void Update(StadiumDTO stadium)
        {
            _stadiumDal.Update(stadium);
        }

        // Xóa sân vận động
        public void Delete(string id)
        {
            _stadiumDal.Delete(id);
        }
    }
}
