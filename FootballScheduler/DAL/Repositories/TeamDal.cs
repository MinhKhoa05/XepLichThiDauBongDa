using System.Collections.Generic;
using DAL.Helpers;
using DTO;

namespace DAL.Repositories
{
    public class TeamDal
    {
        private const string Table = "Team";

        public List<TeamDTO> GetAll()
        {
            string sql = $"SELECT * FROM {Table}";
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
    }
}
