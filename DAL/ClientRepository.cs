using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public class ClientRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

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

        public static int EditClient(ClientView view)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Client SET name = @Name, birthdate = @Birthdate, " +
                    "phone_number = @Phone_Number, discount_id = @Discount_Id WHERE client_id = @Client_Id; " +
                    "SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, view).First();
            }
        }

        public static int DeleteClient(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Client WHERE client_id = @Client_Id";

                var param = new DynamicParameters();

                param.Add("Client_Id", id);

                return db.Query<int>(query, param).First();
            }
        }
    }
}
