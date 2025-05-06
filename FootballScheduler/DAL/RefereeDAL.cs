using System;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class RefereeDAL
    {
        private const string Table = "Referee";

        public List<RefereeDTO> GetAll()
        {
            string sql = $"SELECT * FROM {Table}";
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
                    PhoneNumber = @PhoneNumber
                WHERE RefereeID = @RefereeID";

            DbConnector.Execute(sql, referee);
        }

        public void Delete(string id)
        {
            string sql = $"DELETE FROM {Table} WHERE RefereeID = @Id";
            DbConnector.Execute(sql, new { Id = id });
        }

        public List<RefereeDTO> GetAvailableReferees(DateTime newStartTime)
        {
            DateTime newEndTime = newStartTime.AddHours(2);

            string sql = $@"
                SELECT * FROM {Table}
                WHERE RefereeID NOT IN (
                    SELECT RefereeID
                    FROM Match
                    WHERE KickOffDateTime < @NewEndTime 
                        AND DATEADD(HOUR, 2, KickOffDateTime) > @NewStartTime
                )";

            return DbConnector.QueryList<RefereeDTO>(sql, new { NewStartTime = newStartTime, NewEndTime = newEndTime });
        }

        public List<RefereeDTO> Search(string keyword)
        {
            string sql = $@"
                SELECT * FROM {Table}
                WHERE 
                    RefereeID LIKE @kw OR
                    RefereeName LIKE @kw OR
                    Email LIKE @kw OR
                    PhoneNumber LIKE @kw";

            return DbConnector.QueryList<RefereeDTO>(sql, new { kw = $"%{keyword}%" });
        }

    }
}
