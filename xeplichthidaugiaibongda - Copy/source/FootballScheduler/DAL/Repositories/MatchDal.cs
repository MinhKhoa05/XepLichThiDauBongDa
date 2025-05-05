using System.Collections.Generic;
using DAL.Helpers;
using DTO;

namespace DAL.Repositories
{
    public class MatchDal
    {
        private const string Table = "Match";

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

        public MatchDTO GetById(string id)
        {
            string sql = $"SELECT * FROM {Table} WHERE MatchID = @Id";
            return DbConnector.QuerySingle<MatchDTO>(sql, new { Id = id });
        }

        public void InsertRange(List<MatchDTO> matches)
        {
            string sql = $@"
                INSERT INTO {Table} (HomeTeamID, AwayTeamID, RoundNumber, LeagueID, KickoffDateTime, StadiumID, RefereeID)
                VALUES (@HomeTeamID, @AwayTeamID, @RoundNumber, @LeagueID, @KickoffDateTime, @StadiumID, @RefereeID)";

            DbConnector.BulkInsert(sql, matches);
        }

        public void Update(MatchDTO match)
        {
            string sql = $@"
                UPDATE {Table}
                SET KickoffDateTime = @KickoffDateTime,
                    StadiumID = @StadiumID,
                    RefereeID = @RefereeID,
                    HomeGoals = @HomeGoals,
                    AwayGoals = @AwayGoals,
                    Status = @Status
                WHERE MatchID = @MatchID";

            DbConnector.Execute(sql, match);
        }
    }
}
