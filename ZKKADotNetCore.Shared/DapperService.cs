using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ZKKADotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService (string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Z> Query<Z>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var lst = db.Query<Z>(query, param).ToList();
            return lst;
        }

        public Z QueryFirstOrDefault<Z>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.Query<Z>(query, param).FirstOrDefault();
            return item!;
        }

        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, param);
            return result;
        }
    }
}
