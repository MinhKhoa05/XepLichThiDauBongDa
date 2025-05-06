using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class TeamDAL
    {
        private const string Table = "Team";

        public List<TeamDTO> GetAll()
        {
            string sql = $"SELECT *, s.StadiumName FROM {Table} t JOIN Stadium s ON s.StadiumID = t.HomeStadiumID";
            return DbConnector.QueryList<TeamDTO>(sql);
        }

        public TeamDTO GetById(string id)
        {
            string sql = $"SELECT * FROM {Table} WHERE TeamID = @Id";
            return DbConnector.QuerySingle<TeamDTO>(sql, new { Id = id });
        }

        public string MaxID()
        {
            string sql = $"SELECT TOP 1 TeamID FROM {Table} ORDER BY TeamID DESC";
            return DbConnector.QueryValue(sql)?.ToString() ?? string.Empty;
        }

        public string Insert(TeamDTO team)
        {
            string sql = $@"
                INSERT INTO {Table} 
                    (TeamID, TeamName, LogoURL, CoachName, Email, Phone, HomeStadiumID)
                VALUES 
                    (@TeamID, @TeamName, @LogoURL, @CoachName, @Email, @Phone, @HomeStadiumID)";

            DbConnector.Execute(sql, team);
            return team.TeamID; // Trả về ID của đội bóng vừa thêm
        }

        public void Update(TeamDTO team)
        {
            string sql = $@"
                UPDATE {Table}
                SET 
                    TeamName = @TeamName,
                    LogoURL = @LogoURL,
                    CoachName = @CoachName,
                    Email = @Email,
                    Phone = @Phone,
                    HomeStadiumID = @HomeStadiumID
                WHERE TeamID = @TeamID";

            DbConnector.Execute(sql, team);
        }

        public void Delete(string id)
        {
            string sql = $"DELETE FROM {Table} WHERE TeamID = @Id";
            DbConnector.Execute(sql, new { Id = id });
        }

        public List<TeamDTO> Search(string keyword)
        {
            string sql = $@"
                SELECT *, s.StadiumName 
                FROM {Table} t 
                JOIN Stadium s ON s.StadiumID = t.HomeStadiumID
                WHERE 
                    t.TeamID LIKE @kw OR
                    t.TeamName LIKE @kw OR
                    t.CoachName LIKE @kw OR
                    t.Email LIKE @kw OR
                    t.Phone LIKE @kw OR
                    s.StadiumName LIKE @kw";

            return DbConnector.QueryList<TeamDTO>(sql, new { kw = $"%{keyword}%" });
        }

    }
}
