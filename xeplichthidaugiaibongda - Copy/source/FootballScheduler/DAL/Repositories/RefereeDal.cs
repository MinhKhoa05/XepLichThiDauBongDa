using System;
using System.Collections.Generic;
using DAL.Helpers;
using DTO;

namespace DAL.Repositories
{
    public class RefereeDal
    {
        private const string Table = "Referee";

        public List<RefereeDTO> GetAll()
        {
            string sql = $"SELECT * FROM {Table} WHERE IsDeleted = 0";
            return DbConnector.QueryList<RefereeDTO>(sql);
        }

        public RefereeDTO GetById(string id)
        {
            string sql = $"SELECT * FROM {Table} WHERE RefereeID = @Id";
            return DbConnector.QuerySingle<RefereeDTO>(sql, new { Id = id });
        }

        public string MaxID()
        {
            string sql = $"SELECT TOP 1 RefereeID FROM {Table} ORDER BY RefereeID DESC";
            return DbConnector.QueryValue(sql)?.ToString() ?? string.Empty;
        }

        public string Insert(RefereeDTO referee)
        {
            string sql = $@"
                INSERT INTO {Table} (RefereeID, RefereeName, BirthDate, Email, PhoneNumber)
                VALUES (@RefereeID, @RefereeName, @BirthDate, @Email, @PhoneNumber)";
            
            DbConnector.Execute(sql, referee);
            return referee.RefereeID;
        }

        public void Update(RefereeDTO referee)
        {
            string sql = $@"
                UPDATE {Table}
                SET RefereeName = @RefereeName,
                    BirthDate = @BirthDate,
                    Email = @Email,
                    Phoneumber = @PhoneNumber,
                WHERE RefereeID = @RefereeID";

            DbConnector.Execute(sql, referee);
        }

        public void Delete(string id)
        {
            string sql = $"DELETE FROM {Table} WHERE RefereeID = @Id";
            DbConnector.Execute(sql, new { Id = id });
        }

        public void SoftDelete(string id)
        {
            string sql = $"UPDATE {Table} SET IsDeleted = 1 WHERE RefereeID = @Id";
            DbConnector.Execute(sql, new { Id = id });
        }

        public void Restore(string id)
        {
            string sql = $"UPDATE {Table} SET IsDeleted = 0 WHERE RefereeID = @Id";
            DbConnector.Execute(sql, new { Id = id });
        }

        /// <summary>
        /// Lấy danh sách trọng tài chưa bận trong khoảng thời gian mới.
        /// </summary>
        public List<RefereeDTO> GetAvailableReferees(DateTime newStartTime)
        {
            DateTime newEndTime = newStartTime.AddHours(2);

            string sql = $@"
                SELECT * FROM {Table}
                WHERE IsDeleted = 0 AND RefereeID NOT IN (
                    SELECT RefereeID
                    FROM Match
                    WHERE KickOffDateTime < @NewEndTime 
                        AND DATEADD(HOUR, 2, KickOffDateTime) > @NewStartTime
                )";

            return DbConnector.QueryList<RefereeDTO>(sql, new { NewStartTime = newStartTime, NewEndTime = newEndTime });
        }
    }
}
