using System;
using System.Collections.Generic;
using System.Linq;
using BUS.BUSs;
using DTO;

namespace BUS.Managers
{
    public class MatchManager
    {
        private string _leagueID;
        private readonly LeagueTeamBUS _leagueTeamBUS = new LeagueTeamBUS();
        private readonly TeamBUS _teamBUS = new TeamBUS();
        private readonly MatchBUS _matchBUS = new MatchBUS();
        private readonly RefereeBUS _refereeBUS = new RefereeBUS();

        public string LeagueID
        {
            get { return _leagueID; }
            set
            {
                if (_leagueID != value)
                {
                    _leagueID = value;
                    UpdateTeams(); // Cập nhật lại danh sách đội
                }
            }
        }

        public List<MatchDTO> Schedule { get; private set; }
        public List<TeamDTO> Teams { get; private set; } = new List<TeamDTO>();
        public List<RefereeDTO> Referees { get; private set; }

        public MatchManager()
        {
            LeagueID = "";
            Referees = _refereeBUS.GetAll(); // Lấy danh sách trọng tài
        }

        public MatchManager(string leagueID)
        {
            LeagueID = leagueID;
            Referees = _refereeBUS.GetAll();
        }

        public void GenerateSchedule(int roundIntervalDays, TimeSpan startTime)
        {
            Schedule = GenerateRoundRobinSchedule(LeagueID, Teams, roundIntervalDays, startTime); // Tạo lịch đấu
            AssignReferees(Schedule, Referees);                                                   // Gán trọng tài
        }

        public void SaveSchedule()
        {
            _matchBUS.InsertRange(Schedule); // Lưu lịch vào DB
        }

        public void UpdateTeams()
        {
            Teams.Clear();
            List<string> teamIDs = _leagueTeamBUS.GetTeamsByLeagueID(LeagueID);

            foreach (string teamID in teamIDs)
            {
                TeamDTO team = _teamBUS.GetById(teamID);
                if (team != null)
                    Teams.Add(team);
            }
        }

        // Sinh lịch thi đấu Round Robin (lượt đi + về)
        private List<MatchDTO> GenerateRoundRobinSchedule(string leagueID, List<TeamDTO> teams, int roundIntervalDays, TimeSpan startTime)
        {
            List<MatchDTO> schedule = new List<MatchDTO>();
            List<TeamDTO> workingTeams = new List<TeamDTO>(teams);

            if (workingTeams.Count % 2 != 0)
                workingTeams.Add(null); // Thêm đội ảo nếu số lẻ

            DateTime leagueStartDate = (new LeagueBUS()).GetById(leagueID).StartDate;
            DateTime startDate = leagueStartDate.AddDays(3).Date + startTime; // Gộp ngày + giờ

            byte numRounds = (byte)(workingTeams.Count - 1);

            for (byte round = 1; round <= numRounds; round++)
            {
                for (int i = 0; i < workingTeams.Count / 2; i++)
                {
                    TeamDTO home = workingTeams[i];
                    TeamDTO away = workingTeams[workingTeams.Count - 1 - i];

                    if (home != null && away != null)
                    {
                        DateTime firstLeg = startDate.AddDays((round - 1) * roundIntervalDays);
                        DateTime secondLeg = firstLeg.AddDays(numRounds * roundIntervalDays);

                        schedule.Add(new MatchDTO(leagueID, round, home.TeamID, away.TeamID, firstLeg, home.HomeStadiumID));
                        schedule.Add(new MatchDTO(leagueID, (byte)(round + numRounds), away.TeamID, home.TeamID, secondLeg, away.HomeStadiumID));
                    }
                }

                // Xoay vòng đội
                TeamDTO last = workingTeams[workingTeams.Count - 1];
                workingTeams.RemoveAt(workingTeams.Count - 1);
                workingTeams.Insert(1, last);
            }

            return schedule
                .OrderBy(m => m.RoundNumber)
                .ThenBy(m => m.KickoffDateTime)
                .ToList();
        }

        // Gán trọng tài cho từng trận
        private void AssignReferees(List<MatchDTO> matches, List<RefereeDTO> referees)
        {
            int refereeCount = referees.Count;
            int index = 0;

            foreach (MatchDTO match in matches)
            {
                match.RefereeID = referees[index % refereeCount].RefereeID;
                index++;
            }

            AdjustRefereeSchedule(matches, 3); // Dời giờ nếu trùng lịch
        }

        // Dời giờ trận nếu trọng tài bị trùng lịch
        private void AdjustRefereeSchedule(List<MatchDTO> matches, int hoursToShift)
        {
            Dictionary<string, DateTime> refereeSchedule = new Dictionary<string, DateTime>();

            foreach (MatchDTO match in matches)
            {
                string refereeID = match.RefereeID;
                DateTime kickoff = match.KickoffDateTime;

                while (refereeSchedule.ContainsKey(refereeID) &&
                       Math.Abs((kickoff - refereeSchedule[refereeID]).TotalMinutes) < 120)
                {
                    kickoff = kickoff.AddHours(hoursToShift);
                }

                match.KickoffDateTime = kickoff;
                refereeSchedule[refereeID] = kickoff;
            }
        }
    }
}
