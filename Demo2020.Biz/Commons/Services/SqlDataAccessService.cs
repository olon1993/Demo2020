using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Commons.Services
{
    public class SqlDataAccessService : IDataAccessService
    {
        private SqlDataAccess _sqlDataAccess;

        public DataTable ExecuteDataTable(string storedProcedure, params SqlParameter[] parameters)
        {
            return _sqlDataAccess.ExecuteDataTable(storedProcedure, parameters);
        }

        public DataTable ExecuteDataTable(string storedProcedure)
        {
            return _sqlDataAccess.ExecuteDataTable(storedProcedure);
        }

        public bool ExecuteNonQuery(string storedProcedure, params SqlParameter[] parameters)
        {
            return _sqlDataAccess.ExecuteNonQuery(storedProcedure, parameters);
        }

        public bool ExecuteNonQuery(string storedProcedure)
        {
            return _sqlDataAccess.ExecuteNonQuery(storedProcedure);
        }
    }
}
