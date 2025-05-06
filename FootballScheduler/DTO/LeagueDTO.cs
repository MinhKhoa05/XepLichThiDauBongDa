using System;

namespace DTO
{
    public class LeagueDTO
    {
        public string LeagueID { get; set; }
        public string LeagueName { get; set; }
        public string LogoURL { get; set; }
        public int MaxTeams { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private byte _status;

        //public string Status
        //{
        //    get
        //    {
        //        switch (_status)
        //        {
        //            case 0:
        //                return "Chưa tạo lịch";
        //            case 1:
        //                return "Đã lên lịch";
        //            case 2:
        //                return "Đã kết thúc";
        //            default:
        //                return "Không xác định";
        //        }
        //    }
        //}

        public LeagueDTO() { }
    }
}