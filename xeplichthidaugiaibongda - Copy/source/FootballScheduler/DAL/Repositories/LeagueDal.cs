using System.Collections.Generic;
using DAL.Helpers;
using DTO;

namespace DAL.Repositories
{
    public class LeagueDal
    {
        private const string Table = "League";

        public List<LeagueDTO> GetAll()
        {
            string sql = $"SELECT * FROM {Table} WHERE IsDeleted = 0";
            return DbConnector.QueryList<LeagueDTO>(sql);
        }

        public LeagueDTO GetById(string leagueID)
        {
            string sql = $"SELECT * FROM {Table} WHERE LeagueID = @LeagueID";
            return DbConnector.QuerySingle<LeagueDTO>(sql, new { LeagueID = leagueID });
        }

        public string MaxID()
        {
            string sql = $"SELECT TOP 1 LeagueID FROM {Table} ORDER BY LeagueID DESC";
            return DbConnector.QueryValue(sql)?.ToString() ?? string.Empty;
        }

        public void SoftDelete(string leagueID)
        {
            string sql = $"UPDATE {Table} SET IsDeleted = 1 WHERE LeagueID = @LeagueID";
            DbConnector.Execute(sql, new { LeagueID = leagueID});
        }

        public void Restore(string leagueID)
        {
            string sql = $"UPDATE {Table} SET IsDeleted = 0 WHERE LeagueID = @LeagueID";
            DbConnector.Execute(sql, new { LeagueID = leagueID });
        }

        public string Insert(LeagueDTO league)
        {
            string sql = $@"
                INSERT INTO {Table} (LeagueID, LeagueName, LogoURL, MaxTeams, StartDate, EndDate)
                VALUES (@LeagueID, @LeagueName, @LogoURL, @MaxTeams, @StartDate, @EndDate)";

            DbConnector.Execute(sql, league);
            return league.LeagueID;
        }

        public void Update(LeagueDTO league)
        {
            string sql = $@"
                UPDATE {Table} SET 
                    LeagueName = @LeagueName,
                    LogoURL = @LogoURL,
                    MaxTeams = @MaxTeams,
                    StartDate = @StartDate,
                    EndDate = @EndDate
                WHERE LeagueID = @LeagueID";

            DbConnector.Execute(sql, league);
        }

        public void Delete(string leagueID)
        {
            string sql = $"DELETE FROM {Table} WHERE LeagueID = @LeagueID";
            DbConnector.Execute(sql, new { LeagueID = leagueID });
        }
    }
}
