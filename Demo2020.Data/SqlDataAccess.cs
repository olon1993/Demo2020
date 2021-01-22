using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Data
{
    public class SqlDataAccess
    {
        public DataTable ExecuteDataTable(string storedProcedure, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteDataTable(string storedProcedure)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteNonQuery(string storedProcedure, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteNonQuery(string storedProcedure)
        {
            throw new NotImplementedException();
        }
    }
}
