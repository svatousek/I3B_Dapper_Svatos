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

        public List<MediaType> GetAll()
        {
            string sql = @"
                Select *
                From MediaType
                Order By MediaTypeId ASC; ";

            using SqlConnection conn = _connectionFactory.CreateConnection();

            conn.Open();

            List<MediaType> mediaTypes = conn.Query<MediaType>(sql).ToList();

            return mediaTypes;
        }

        public void Insert(MediaType mediaType)
        {
            string sql = @"
                Insert Into MediaType (MediaTypeName)
                Values (@MediaTypeName);";
            using SqlConnection conn = _connectionFactory.CreateConnection();
            conn.Execute(sql, mediaType);
        }

        public void CreateTable(string tableName)
        {
            string sql = $@"
        CREATE TABLE {tableName}
        (
            Id INT PRIMARY KEY IDENTITY(1,1),
            Name NVARCHAR(67) NOT NULL
        );";

            using SqlConnection conn = _connectionFactory.CreateConnection();
            conn.Open();
            conn.Execute(sql);
        }
    }
}
