using Dapper;
using I3B_Dapper_Svatoš.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3B_Dapper_Svatoš.Data
{
    internal class MediaTypeRepository
    {
        private DatabaseConnectionFactory _connectionFactory;

        public MediaTypeRepository(DatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public  List<MediaType> GetAll()
        {
            string sql =@"
                Select *
                From MediaType
                Order By MediaTypeId; ";

            using SqlConnection conn = _connectionFactory.CreateConnection();

            List<MediaType> mediaTypes = conn.Query<MediaType>(sql).ToList();

            return mediaTypes;
        }
    }
}
