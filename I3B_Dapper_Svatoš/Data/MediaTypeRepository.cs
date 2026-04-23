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

        public void InsertIntoTable(string tableName, string column, string data)
        {
            // kontrola názvů (kvůli injection)
            if (!System.Text.RegularExpressions.Regex.IsMatch(tableName, @"^[a-zA-Z0-9_]+$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(column, @"^[a-zA-Z0-9_]+$"))
            {
                throw new Exception("Neplatný název tabulky nebo sloupce.");
            }

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
            Name NVARCHAR(67) NOT NULL
        );";

            using SqlConnection conn = _connectionFactory.CreateConnection();
            conn.Open();
            conn.Execute(sql);
        }
    }   
}
