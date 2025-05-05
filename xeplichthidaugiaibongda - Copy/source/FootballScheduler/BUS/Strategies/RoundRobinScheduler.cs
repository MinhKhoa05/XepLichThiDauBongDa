using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace BUS.Strategy
{
    public class RoundRobinScheduler : ISchedulerStrategy
    {
        private const int MatchDayInterval = 7;  // Khoảng cách giữa các vòng đấu
        private const int DefaultStartHour = 8;  // Giờ bắt đầu mặc định (8h sáng)

        public List<MatchDTO> Generate(string leagueID, List<TeamDTO> teams)
        {
            var schedule = new List<MatchDTO>();
            var workingTeams = new List<TeamDTO>(teams); // Sao chép danh sách để không ảnh hưởng danh sách gốc

            if (workingTeams.Count % 2 != 0)
            {
                workingTeams.Add(null);  // Thêm đội rỗng nếu số lượng đội lẻ
            }

            DateTime startDate = DateTime.Now.Date.AddDays(3).AddHours(DefaultStartHour);
            byte numRounds = (byte)(workingTeams.Count - 1);

            for (byte round = 1; round <= numRounds; round++)
            {
                for (int i = 0; i < workingTeams.Count / 2; i++)
                {
                    var home = workingTeams[i];
                    var away = workingTeams[workingTeams.Count - 1 - i];

                    if (home != null && away != null)
                    {
                        DateTime firstLegDate = startDate.AddDays(round * MatchDayInterval);
                        DateTime secondLegDate = firstLegDate.AddDays(numRounds * MatchDayInterval);

                        // Lượt đi
                        schedule.Add(new MatchDTO(leagueID, round, home.TeamID, away.TeamID, firstLegDate, home.HomeStadiumID));
                        // Lượt về
                        schedule.Add(new MatchDTO(leagueID, (byte)(round + numRounds), away.TeamID, home.TeamID, secondLegDate, away.HomeStadiumID));
                    }
                }

                // Xoay vòng đội
                var lastTeam = workingTeams[workingTeams.Count - 1];
                workingTeams.RemoveAt(workingTeams.Count - 1);
                workingTeams.Insert(1, lastTeam);
            }

            return schedule.OrderBy(m => m.RoundNumber)
                           .ThenBy(m => m.KickoffDateTime)
                           .ToList();
        }
    }
}