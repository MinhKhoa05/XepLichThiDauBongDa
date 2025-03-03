using System;

namespace DTO
{
    public class DTO_SinhVien
    {
        private string _maSV, _hoTen, _queQuan;
        private DateTime _ngaySinh;
        private decimal _hocLuc;

        public string MaSV
        {
            get => _maSV;
            set => _maSV = value;
        }

        public string HoTen
        {
            get => _hoTen;
            set => _hoTen = value;
        }

        public string QueQuan
        {
            get => _queQuan;
            set => _queQuan = value;
        }

        public DateTime NgaySinh
        {
            get => _ngaySinh;
            set => _ngaySinh = value;
        }

        public decimal HocLuc
        {
            get => _hocLuc;
            set => _hocLuc = value;
        }

        public DTO_SinhVien(string maSV, string hoTen, string queQuan, DateTime ngaySinh, decimal hocLuc)
        {
            _maSV = maSV;
            _hoTen = hoTen;
            _queQuan = queQuan;
            _ngaySinh = ngaySinh;
            _hocLuc = hocLuc;
        }
    }
}
