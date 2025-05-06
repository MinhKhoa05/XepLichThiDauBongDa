using System;
using System.Collections.Generic;
using BUS.Helpers;
using DAL;
using DTO;

namespace BUS.BUSs
{
    public class RefereeBUS
    {
        private readonly RefereeDAL _refereeDal;

        public RefereeBUS()
        {
            _refereeDal = new RefereeDAL(); // Tạo đối tượng DAL để truy vấn cơ sở dữ liệu
        }

        // Lấy tất cả trọng tài chưa bị xóa
        public List<RefereeDTO> GetAll()
        {
            return _refereeDal.GetAll();
        }

        // Lấy trọng tài theo ID
        public RefereeDTO GetById(string id)
        {
            return _refereeDal.GetById(id);
        }

        // Thêm mới trọng tài
        public string Insert(RefereeDTO referee)
        {
            referee.RefereeID = IDGenerator.GenerateID("R", 6, _refereeDal.MaxID());
            return _refereeDal.Insert(referee);
        }

        // Cập nhật thông tin trọng tài
        public void Update(RefereeDTO referee)
        {
            _refereeDal.Update(referee);
        }

        // Xóa trọng tài
        public void Delete(string id)
        {
            _refereeDal.Delete(id);
        }

        // Lấy danh sách trọng tài có thể tham gia trong khoảng thời gian mới
        public List<RefereeDTO> GetAvailableReferees(DateTime newStartTime)
        {
            return _refereeDal.GetAvailableReferees(newStartTime);
        }
    }
}
