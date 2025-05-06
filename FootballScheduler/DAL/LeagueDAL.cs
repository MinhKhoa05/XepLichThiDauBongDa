using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class LeagueDAL
    {
        private const string Table = "League";

        public List<LeagueDTO> GetAll()
        {
            string sql = $"SELECT * FROM {Table}";
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

        public void Insert(LeagueDTO league)
        {
            string sql = $@"
                INSERT INTO {Table} (LeagueID, LeagueName, LogoURL, MaxTeams, StartDate, EndDate)
                VALUES (@LeagueID, @LeagueName, @LogoURL, @MaxTeams, @StartDate, @EndDate)";

            DbConnector.Execute(sql, league);
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

        public List<LeagueDTO> Search(string keyword)
        {
            string sql = $@"
                SELECT * FROM {Table}
                WHERE 
                    LeagueID LIKE @kw OR
                    LeagueName LIKE @kw OR
                    CONVERT(VARCHAR, StartDate, 103) LIKE @kw OR
                    CONVERT(VARCHAR, EndDate, 103) LIKE @kw OR
                    CONVERT(VARCHAR, MaxTeams) LIKE @kw";

            return DbConnector.QueryList<LeagueDTO>(sql, new { kw = $"%{keyword}%" });
        }

    }
}
