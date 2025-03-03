using System;

namespace DTO
{
    public class DTO_SinhVienDeTai
    {
        private string _maDT, _maSV, _noiThucTap;
        private int _quangDuong;
        private decimal _ketQua;

        public string MaDT
        {
            get => _maDT;
            set => _maDT = value;
        }

        public string MaSV
        {
            get => _maSV;
            set => _maSV = value;
        }

        public string NoiThucTap
        {
            get => _noiThucTap;
            set => _noiThucTap = value;
        }

        public int QuangDuong
        {
            get => _quangDuong;
            set => _quangDuong = value;
        }

        public decimal KetQua
        {
            get => _ketQua;
            set => _ketQua = value;
        }

        public DTO_SinhVienDeTai(string maSV, string maDT, string noiThucTap, int quangDuong, decimal ketQua)
        {
            _maSV = maSV;
            _maDT = maDT;
            _noiThucTap = noiThucTap;
            _quangDuong = quangDuong;
            _ketQua = ketQua;
        }
    }
}