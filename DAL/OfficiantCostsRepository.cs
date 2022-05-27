using System.Data.SqlClient;
using System.Data;
using Dapper;
using Entities;

namespace DAL
{
    public static class OfficiantCostsRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant2;Integrated Security=true";

        public static async Task<IEnumerable<OfficiantCostsView>> GetAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<OfficiantCostsView>("getTotalCostOfOffersForEachOfficiant", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
