

using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class LeagueDTO
    {
        public string LeagueID { get; set; }

        [Required(ErrorMessage = "Tên giải đấu không được để trống")]
        [StringLength(100, ErrorMessage = "Tên giải tối đa 100 ký tự")]
        public string LeagueName { get; set; }

        public string LogoURL { get; set; }

        [Range(2, 30, ErrorMessage = "Số đội tối đa phải từ 2 đến 20")]
        public int MaxTeams { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu không được để trống")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc không được để trống")]
        public DateTime EndDate { get; set; }

        private byte _status;

        public string Status
        {
            get
            {
                switch (_status)
                {
                    case 0:
                        return "Chưa tạo lịch";
                    case 1:
                        return "Đã lên lịch";
                    case 2:
                        return "Đã kết thúc";
                    default:
                        return "Không xác định";
                }
            }
        }

        public LeagueDTO() { }

        public LeagueDTO(string leagueID, string leagueName, string logoURL, int maxTeams, DateTime startDate, DateTime endDate)
        {
            LeagueID = leagueID;
            LeagueName = leagueName;
            LogoURL = logoURL;
            MaxTeams = maxTeams;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}