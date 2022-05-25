using Entities;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DAL;
public static class ProductRepository
{
    private static readonly string _connectionString = @"Server=localhost;Database=Restaurant;UserId=sa;Password=igumug16";

    public static IEnumerable<Product> GetProducts()
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Product";

            return conn.Query<Product>(query).ToList();
        }
    }
}

