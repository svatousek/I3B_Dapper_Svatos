using Dapper;
using I3B_Dapper_Svatoš.Data;

internal class GenericRepository
{
    private DatabaseConnectionFactory _connectionFactory;

    public GenericRepository(DatabaseConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public List<T> GetAll<T>(string tableName)
    {
        string sql = $"SELECT * FROM {tableName}";

        using var conn = _connectionFactory.CreateConnection();
        return conn.Query<T>(sql).ToList();
    }
}