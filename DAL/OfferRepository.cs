using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public class OfferRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

        public static IEnumerable<OfferView> GetOffers()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Offer";

                return db.Query<OfferView>(query);
            }
        }

        public static int CreateOffer(OfferView view)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Offer (offer_time, price, officiant_id, client_id) VALUES " +
                    "(@Offer_Time, @Price, @Officiant_Id, @Client_Id); SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, view).First();
            }
        }

        public static int EditOffer(OfferView view)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Offer SET offer_time = @Offer_Time, price = @Price, officiant_id = @Officiant_Id, " +
                    "client_id = @Client_Id WHERE offer_id = @Offer_Id; SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, view).First();
            }
        }

        public static int DeleteOffer(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Offer WHERE offer_id = @Offer_Id; SELECT SCOPE_IDENTITY();";

                var param = new DynamicParameters();

                param.Add("Offer_Id", id);

                return db.Query<int>(query, param).First();
            }
        }
    }
}
