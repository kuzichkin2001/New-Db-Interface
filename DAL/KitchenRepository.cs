﻿using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public static class KitchenRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";
    
        public static IEnumerable<DishView> GetDishesByKitchenId(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Dish WHERE kitchen_id = @Kitchen_Id";

                var param = new DynamicParameters();

                param.Add("Kitchen_Id", id);

                return db.Query<DishView>(query, param);
            }
        }
        
        public static IEnumerable<KitchenView> GetKitchens()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Kitchen";

                return db.Query<KitchenView>(query);
            }
        }

        public static int CreateKitchen(KitchenView kitchenView)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Kitchen (kitchen_name) VALUES (@Kitchen_Name); SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, kitchenView).First();
            }
        }

        public static int DeleteKitchen(long kitchenId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Kitchen WHERE kitchen_id = @kitchen_id; SELECT SCOPE_IDENTITY();";

                var param = new DynamicParameters();

                param.Add("kitchen_id", kitchenId);

                return db.Query<int>(query, param).First();
            }
        }

        public static int EditKitchen(KitchenView kitchenView)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Kitchen SET kitchen_name = @Kitchen_Name WHERE kitchen_id = @Kitchen_Id; " +
                    "SELECT SCOPE_IDENTITY()";

                return db.Query<int>(query, kitchenView).First();
            }
        }
    }
}
