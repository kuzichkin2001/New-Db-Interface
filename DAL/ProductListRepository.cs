using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public class ProductListRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

        public static IEnumerable<ProductListView> GetProductLists()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Product_List";

                return db.Query<ProductListView>(query);
            }
        }
    }
}
