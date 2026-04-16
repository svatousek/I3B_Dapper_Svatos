using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3B_Dapper_Svatoš.Data
{
    internal class DatabaseConnectionFactory
    {
        private readonly string _connectionString;

        public DatabaseConnectionFactory (string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection( _connectionString );
        }
    }
}
