using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public class ClientRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

        public static ClientView GetClient(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Client WHERE client_id = @ID";

                var param = new DynamicParameters();

                param.Add("ID", id);

                return db.Query<ClientView>(query, param).First();
            }
        }

        public static IEnumerable<ClientView> GetClients()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Client";

                return db.Query<ClientView>(query);
            }
        }

        public static int CreateClient(ClientView view)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Client (name, birthdate, phone_number, discount_id) VALUES " +
                    "(@Name, @Birthdate, @Phone_Number, @Discount_Id); SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, view).First();
            }
        }

        public static void EditClient(ClientView view)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Client SET name = @Name, birthdate = @Birthdate, " +
                    "phone_number = @Phone_Number, discount_id = @Discount_Id WHERE client_id = @Client_Id;";

                db.Query(query, view);
            }
        }

        public static void DeleteClient(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Offer SET client_id = @ID + 1 WHERE client_id = @ID;" +
                    "DELETE FROM Client WHERE client_id = @ID";

                var param = new DynamicParameters();

                param.Add("ID", id);

                db.Query(query, param);
            }
        }
    }
}
