using System;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class MatchDAL
    {
        private const string Table = "Match";

        // Lấy danh sách tất cả trận đấu trong giải đấu
        public List<MatchView> GetAll(string leagueID = null)
        {
            var sql = new System.Text.StringBuilder("SELECT * FROM v_MatchDetails");

            if (!string.IsNullOrEmpty(leagueID))
            {
                sql.Append(" WHERE LeagueID = @LeagueID");
            }

            sql.Append(" ORDER BY KickoffDateTime ASC");

            return DbConnector.QueryList<MatchView>(sql.ToString(), new { LeagueID = leagueID });
        }

        // Lấy thông tin trận đấu theo MatchID
        public MatchDTO GetById(string id)
        {
            string sql = $"SELECT * FROM {Table} WHERE MatchID = @Id";
            return DbConnector.QuerySingle<MatchDTO>(sql, new { Id = id });
        }

        // Thêm nhiều trận đấu vào cơ sở dữ liệu
        public void InsertRange(List<MatchDTO> matches)
        {
            string sql = $@"
                INSERT INTO {Table} (HomeTeamID, AwayTeamID, RoundNumber, LeagueID, KickoffDateTime, StadiumID, RefereeID)
                VALUES (@HomeTeamID, @AwayTeamID, @RoundNumber, @LeagueID, @KickoffDateTime, @StadiumID, @RefereeID)";

            DbConnector.BulkInsert(sql, matches);
        }

        // Cập nhật thông tin trận đấu
        public void Update(MatchDTO match)
        {
            string sql = $@"
                UPDATE {Table}
                SET KickoffDateTime = @KickoffDateTime,
                    StadiumID = @StadiumID,
                    RefereeID = @RefereeID,
                    HomeGoals = @HomeGoals,
                    AwayGoals = @AwayGoals,
                    Complete = @Complete
                WHERE MatchID = @MatchID";

            DbConnector.Execute(sql, match);
        }

        // Hàm kiểm tra trùng lịch thi đấu, trùng sân, trùng trọng tài
        public string CheckForScheduleConflict(
            DateTime matchDateTime, string leagueID, string matchID,
            string homeTeamID, string awayTeamID,
            string stadiumID, string refereeID)
        {
            string sql = @"
                SELECT TOP 1 MatchID
                FROM Match
                WHERE LeagueID = @LeagueID
                    AND MatchID != @MatchID
                    AND (
                    (
                        (HomeTeamID IN (@HomeTeamID, @AwayTeamID) OR
                        AwayTeamID IN (@HomeTeamID, @AwayTeamID))
                        AND ABS(DATEDIFF(DAY, KickoffDateTime, @MatchDateTime)) < 2
                    )
                    OR (
                        StadiumID = @StadiumID AND ABS(DATEDIFF(HOUR, KickoffDateTime, @MatchDateTime)) < 2
                    )
                    OR (
                        RefereeID = @RefereeID AND ABS(DATEDIFF(HOUR, KickoffDateTime, @MatchDateTime)) < 2
                    )
                    )";

            var result = DbConnector.QueryValue(sql, new
            {
                LeagueID = leagueID,
                MatchID = matchID,
                MatchDateTime = matchDateTime,
                HomeTeamID = homeTeamID,
                AwayTeamID = awayTeamID,
                StadiumID = stadiumID,
                RefereeID = refereeID
            });

            return result?.ToString(); // trả về MatchID nếu bị trùng
        }

        public void DeleteByLeagueID(string leagueId)
        {
            string sql = $"DELETE FROM {Table} WHERE LeagueID = @LeagueID";
            DbConnector.Execute(sql, new { LeagueID = leagueId });
        }
    }
}