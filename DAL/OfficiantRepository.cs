using Entities;
using Dapper;
using System.Data.SqlClient;

namespace DAL
{
    public class OfficiantRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

        public static IEnumerable<OfficiantView> GetOfficiants()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Officiant";

                return db.Query<OfficiantView>(query);
            }
        }

        public static int CreateOfficiant(OfficiantView officiantView)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Officiant (name, hiring_date, level, phone_number, birthdate) VALUES " +
                    "(@Name, @Hiring_Date, @Level, @Phone_Number, @Birthdate); SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, officiantView).First();
            }
        }

        public static OfficiantView GetOfficiant(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Officiant WHERE officiant_id = @ID";

                var param = new DynamicParameters();

                param.Add("ID", id);

                return db.Query<OfficiantView>(query, param).First();
            }
        }

        public static void EditOfficiant(OfficiantView view)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Officiant SET name = @Name, " +
                    "hiring_date = @Hiring_Date, level = @Level, phone_number = @Phone_Number, " +
                    "birthdate = @Birthdate WHERE officiant_id = @Officiant_Id;";

                db.Query(query, view);
            }
        }

        public static void DeleteOfficiant(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Dish_List WHERE offer_id = @ID;\n" +
                    "DELETE FROM Offer WHERE offer_id = @ID OR officiant_id = @ID;\n" +
                    "DELETE FROM Officiant WHERE officiant_id = @ID;\n";

                var param = new DynamicParameters();

                param.Add("ID", id);

                db.Query(query, param);
            }
        }
    }
}
