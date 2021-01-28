using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Commons.Interfaces
{
    public interface IDataAccessService
    {
        DataSet ExecuteDataSet(string storedProcedure, params SqlParameter[] parameters);
        DataSet ExecuteDataSet(string storedProcedure);
        bool ExecuteNonQuery(string storedProcedure, params SqlParameter[] parameters);
        bool ExecuteNonQuery(string storedProcedure);
    }
}
