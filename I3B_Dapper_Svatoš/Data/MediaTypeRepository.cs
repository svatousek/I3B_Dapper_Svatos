using Dapper;
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

        public async Task<List<T>> GetAllGenericAsync<T>(string tableName)
        {
            string sql = $"SELECT * FROM {tableName}";

            using var conn = _connectionFactory.CreateConnection();
            var result = await conn.QueryAsync<T>(sql);
            return result.ToList();
        }

        public void InsertIntoTable(string tableName, string column, string data)
        {
            string sql = $@"
        IF EXISTS (SELECT * FROM sys.tables WHERE name = '{tableName}')
        BEGIN
            INSERT INTO {tableName} ({column})
            VALUES (@Data)
        END
        ELSE
        BEGIN
            THROW 50000, 'Tabulka neexistuje', 1;
        END";

            using SqlConnection conn = _connectionFactory.CreateConnection();
            conn.Open();
            conn.Execute(sql, new { Data = data });
        }

        public void CreateTable(string tableName)
        {
            string sql = $@"
        CREATE TABLE {tableName}
        (
            Id INT PRIMARY KEY IDENTITY(1,1),
            Name NVARCHAR(50) NOT NULL
        );";

            using SqlConnection conn = _connectionFactory.CreateConnection();
            conn.Open();
            conn.Execute(sql);
        }
    }   
}
