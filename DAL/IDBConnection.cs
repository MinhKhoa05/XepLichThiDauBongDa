using System;
using System.Data;

namespace DAL
{
    public interface IDBConnection
    {
        void ActionQuery(string sql, IDataParameter[] parameters = null);
        DataTable SelectQuery(string sql, IDataParameter[] parameters = null);
        IDataParameter CreateParameter(string name, object value);
        Exception HandleException(Exception ex);
    }
}
