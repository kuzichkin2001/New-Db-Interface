using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public class DishListRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

        public static IEnumerable<DishListView> GetDishLists()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Dish_List";

                return db.Query<DishListView>(query);
            }
        }
    }
}
