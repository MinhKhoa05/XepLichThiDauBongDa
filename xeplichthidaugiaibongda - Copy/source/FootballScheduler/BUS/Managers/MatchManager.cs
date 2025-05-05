    using System.Collections.Generic;
    using BUS.Others;
    using BUS.Services;
    using BUS.Strategy;
    using DTO;
    using System;

    namespace BUS.Managers
    {
        public class MatchManager
        {
            private string _leagueID;
            private readonly LeagueTeamBUS _leagueTeamBUS = new LeagueTeamBUS();
            private readonly TeamBUS _teamBUS = new TeamBUS();
            private readonly MatchBUS _matchBUS = new MatchBUS();

            public string LeagueID
            {
                get => _leagueID;
                set
                {
                    if (_leagueID != value)
                    {
                        _leagueID = value;
                        UpdateTeams();  // Cập nhật lại đội bóng khi LeagueID thay đổi
                    }
                }
            }

            public List<MatchDTO> Schedule { get; private set; }
            public List<TeamDTO> Teams { get; private set; } = new List<TeamDTO>();
            public List<RefereeDTO> Referees { get; private set; } = new List<RefereeDTO>();

            private ISchedulerStrategy _scheduleStrategy;

            public MatchManager() : this("", new RoundRobinScheduler()) { }

            public MatchManager(string leagueID, ISchedulerStrategy scheduleStrategy)
            {
                _scheduleStrategy = scheduleStrategy;
                LeagueID = leagueID;  // Khởi tạo và gọi setter để cập nhật đội bóng ngay

                // Load danh sách trọng tài
                Referees = (new RefereeBUS()).GetAll();
            }

            public void GenerateSchedule()
            {
                Schedule = _scheduleStrategy.Generate(LeagueID, Teams);
                AssignReferees(Schedule, Referees);  // Gọi trực tiếp phương thức phân công trọng tài
            }

            public void SaveSchedule()
            {
                _matchBUS.InsertRange(Schedule);
            }

            public void SetScheduleStrategy(ISchedulerStrategy newStrategy) =>
                _scheduleStrategy = newStrategy;

            public void UpdateTeams()
            {
                Teams.Clear();  // Xóa danh sách đội hiện tại

                // Lấy danh sách các teamID trong giải đấu
                List<string> teamIDs = _leagueTeamBUS.GetTeamsByLeagueID(LeagueID);

                // Lấy thông tin chi tiết của từng đội bóng và thêm vào danh sách Teams
                foreach (string teamID in teamIDs)
                {
                    TeamDTO team = _teamBUS.GetById(teamID);
                    if (team != null)
                        Teams.Add(team);
                }
            }

            private void AssignReferees(List<MatchDTO> schedule, List<RefereeDTO> referees)
            {
                int totalReferees = referees.Count;
                int refereeIndex = 0;

                // Phân công trọng tài cho từng trận đấu trong lịch thi đấu
                foreach (var match in schedule)
                {
                    // Phân công trọng tài theo kiểu chu kỳ (Round-Robin)
                    match.RefereeID = referees[refereeIndex].RefereeID;

                    // Chuyển sang trọng tài tiếp theo trong danh sách, đảm bảo không vượt quá số trọng tài
                    refereeIndex = (refereeIndex + 1) % totalReferees;
                }

                // Thay đổi lịch thi đấu nếu cần thiết (khi thiếu trọng tài)
                ShiftScheduleIfNecessary(schedule, 3); // Dời lịch 3 giờ nếu trùng lịch
            }

            private void ShiftScheduleIfNecessary(List<MatchDTO> schedule, int hoursToShift)
            {
                // Lưu trữ lịch thi đấu của các trọng tài
                Dictionary<string, DateTime> refereeSchedule = new Dictionary<string, DateTime>();

                foreach (var match in schedule)
                {
                    string refereeID = match.RefereeID;
                    DateTime matchDateTime = match.KickoffDateTime;

                    // Kiểm tra và thay đổi lịch thi đấu nếu trọng tài trùng lịch
                    while (!IsRefereeAvailable(refereeSchedule, refereeID, matchDateTime))
                    {
                        // Nếu trọng tài đã có lịch thi đấu vào ngày này, thay đổi lịch thi đấu
                        matchDateTime = matchDateTime.AddHours(hoursToShift);  // Dời thêm 3 giờ
                    }

                    // Cập nhật lịch thi đấu cho trọng tài
                    refereeSchedule[refereeID] = matchDateTime;
                    match.KickoffDateTime = matchDateTime;  // Cập nhật thời gian cho trận đấu
                }
            }

            private bool IsRefereeAvailable(Dictionary<string, DateTime> refereeSchedule, string refereeID, DateTime matchDateTime)
            {
                // Kiểm tra xem trọng tài đã có lịch thi đấu trùng với thời gian không
                if (refereeSchedule.ContainsKey(refereeID))
                {
                    DateTime existingMatchTime = refereeSchedule[refereeID];

                    // Kiểm tra khoảng cách thời gian tối thiểu giữa 2 trận đấu là 2 giờ
                    if (Math.Abs((matchDateTime - existingMatchTime).TotalMinutes) < 120)
                    {
                        return false;  // Trọng tài không khả dụng
                    }
                }

                return true;  // Trọng tài khả dụng
            }
        }
    }
