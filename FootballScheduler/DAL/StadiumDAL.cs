﻿using System.Collections.Generic;
using DTO;

namespace DAL
{
    public class StadiumDAL
    {
        private const string Table = "Stadium";

        public List<StadiumDTO> GetAll()
        {
            string sql = $"SELECT * FROM {Table}";
            return DbConnector.QueryList<StadiumDTO>(sql);
        }

        public StadiumDTO GetById(string id)
        {
            string sql = $"SELECT * FROM {Table} WHERE StadiumID = @Id";
            return DbConnector.QuerySingle<StadiumDTO>(sql, new { Id = id });
        }

        public string MaxID()
        {
            string sql = $"SELECT TOP 1 StadiumID FROM {Table} ORDER BY StadiumID DESC";
            return DbConnector.QueryValue(sql)?.ToString() ?? string.Empty;
        }

        public void Insert(StadiumDTO stadium)
        {
            string sql = $@"
                INSERT INTO {Table} (StadiumID, StadiumName, Address)
                VALUES (@StadiumID, @StadiumName, @Address)";

            DbConnector.Execute(sql, stadium);
        }

        public void Update(StadiumDTO stadium)
        {
            string sql = $@"
                UPDATE {Table}
                SET StadiumName = @StadiumName,
                    Address = @Address
                WHERE StadiumID = @StadiumID";

            DbConnector.Execute(sql, stadium);
        }

        public void Delete(string id)
        {
            string sql = $"DELETE FROM {Table} WHERE StadiumID = @Id";
            DbConnector.Execute(sql, new { Id = id });
        }
    }
}
