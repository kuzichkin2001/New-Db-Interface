using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public class DishRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

        public static DishView GetDish(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Dish WHERE dish_id = @ID";

                var param = new DynamicParameters();

                param.Add("ID", id);

                return db.Query<DishView>(query, param).First();
            }
        }

        public static IEnumerable<DishView> GetDishes()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Dish";

                return db.Query<DishView>(query);
            }
        }

        public static int CreateDish(DishView view)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Dish (dish_name, kitchen_id, cost) VALUES " +
                    "(@Dish_Name, @Kitchen_Id, @Cost); SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, view).First();
            }
        }

        public static void EditDish(DishView view)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Dish SET dish_name = @Dish_Name, kitchen_id = @Kitchen_Id, cost = @Cost " +
                    "WHERE dish_id = @Dish_Id;";

                db.Query<int>(query, view);
            }
        }

        public static void DeleteDish(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Product_List WHERE id_dish = @ID;" +
                    "DELETE FROM Dish_List WHERE dish_id = @ID;" +
                    "DELETE FROM Dish WHERE dish_id = @ID;";

                var param = new DynamicParameters();

                param.Add("ID", id);

                db.Query<int>(query, param);
            }
        }
    }
}
