using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public static class DiscountRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

        public static DiscountView GetDiscount(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Discount WHERE discount_id = @ID";

                var param = new DynamicParameters();

                param.Add("ID", id);

                return db.Query<DiscountView>(query, param).First();
            }
        }

        public static IEnumerable<ClientView> GetClientsByDiscountId(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Client WHERE discount_id = @Discount_Id";

                var param = new DynamicParameters();

                param.Add("Discount_Id", id);

                return db.Query<ClientView>(query, param);
            }
        }

        public static IEnumerable<DiscountView> GetDiscounts()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Discount";

                return db.Query<DiscountView>(query);
            }
        }

        public static int CreateDiscount(DiscountView discountView)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Discount (start_date, end_date) VALUES " +
                    "(@Start_Date, @End_Date); SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, discountView).First();
            }
        }

        public static void EditDiscount(DiscountView discountView)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Discount SET start_date = @Start_Date, end_date = @End_Date " +
                    "WHERE discount_id = @Discount_Id;";

                db.Query(query, discountView);
            }
        }

        public static void DeleteDiscount(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Dish_List WHERE offer_id = @ID;" +
                    "DELETE FROM Offer WHERE client_id = @ID;" +
                    "DELETE FROM Client WHERE discount_id = @ID;" +
                    "DELETE FROM Discount WHERE discount_id = @ID;";

                var param = new DynamicParameters();

                param.Add("ID", id);

                db.Query(query, param);
            }
        }
    }
}
