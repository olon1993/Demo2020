using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Data.Interfaces
{
    public interface ISQLiteDataAccess
    {
        DataSet ExecuteQuery(string query);
        DataSet ExecuteQuery(string query, params IDataParameter[] parameters);
        bool ExecuteNonQuery(string query);
        bool ExecuteNonQuery(string query, params IDataParameter[] parameters);
    }
}
