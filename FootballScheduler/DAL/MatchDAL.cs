using System.Collections.Generic;
using System.Linq;
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
            string sql;

            if (match.Complete)
            {
                sql = $@"
                    UPDATE {Table}
                    SET HomeGoals = @HomeGoals,
                        AwayGoals = @AwayGoals,
                        Complete = 1
                    WHERE MatchID = @MatchID";
            }
            else
            {
                sql = $@"
                    UPDATE {Table}
                    SET KickoffDateTime = @KickoffDateTime,
                        StadiumID = @StadiumID,
                        RefereeID = @RefereeID
                    WHERE MatchID = @MatchID";
            }

            DbConnector.Execute(sql, match);
        }

        // Xóa tất cả trận đấu theo giải đấu
        public void DeleteByLeagueID(string leagueId)
        {
            string sql = $"DELETE FROM {Table} WHERE LeagueID = @LeagueID";
            DbConnector.Execute(sql, new { LeagueID = leagueId });
        }

        // Lọc danh sách trận đấu theo từ khóa
        public List<MatchView> Filter(string kw)
        {
            if (string.IsNullOrEmpty(kw))
            {
                return GetAll();
            }

            string sql = $@"
                SELECT * FROM Match
                WHERE HomeTeamID LIKE @kw OR AwayTeamID LIKE @kw OR RefereeID LIKE @kw
                ORDER BY KickoffDateTime ASC";
            var matches = DbConnector.QueryList<MatchDTO>(sql, new { kw = $"%{kw}%" });

            var matchViews = new List<MatchView>();
            foreach (var match in matches)
            {
                var matchView = SelectById(match.MatchID);
                matchViews.Add(matchView);
            }

            return matchViews;
        }

        public MatchView SelectById(string matchId)
        {
            string sql = $@"
                SELECT * FROM v_MatchDetails
                WHERE MatchID = @MatchID";
            var match = DbConnector.QuerySingle<MatchView>(sql, new { MatchID = matchId });
           
            return match;
        }
    }
}
