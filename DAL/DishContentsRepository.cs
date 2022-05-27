using System.Data;
using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    
    public static class DishContentsRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant2;Integrated Security=true";
        public static async Task<IEnumerable<DishContentsView>> GetDishContentsById(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("dish_id", id);

                return await db.QueryAsync<DishContentsView>(
                    "getProductsOfDish",
                    param,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
