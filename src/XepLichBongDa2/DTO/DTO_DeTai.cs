using System;

namespace DTO
{
    public class DTO_DeTai
    {
        private string _maDT, _tenDT, _chuNhiem;
        private long _kinhPhi;

        public string MaDT
        {
            get => _maDT;
            set => _maDT = value;
        }

        public string TenDT
        {
            get => _tenDT;
            set => _tenDT = value;
        }

        public string ChuNhiem
        {
            get => _chuNhiem;
            set => _chuNhiem = value;
        }

        public long KinhPhi
        {
            get => _kinhPhi;
            set => _kinhPhi = value;
        }

        public DTO_DeTai(string maDT, string tenDT, string chuNhiem, long kinhPhi)
        {
            _maDT = maDT;
            _tenDT = tenDT;
            _chuNhiem = chuNhiem;
            _kinhPhi = kinhPhi;
        }
    }
}
