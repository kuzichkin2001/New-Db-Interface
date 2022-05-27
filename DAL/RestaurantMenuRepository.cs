using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public static class RestaurantMenuRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant2;Integrated Security=true";

        public static IEnumerable<RestaurantMenuView> GetMenu()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM dbo.Restaurant_Menu_View";

                return db.Query<RestaurantMenuView>(query);
            }
        }
    }
}
