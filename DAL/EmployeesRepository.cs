using System.Data;
using System.Data.SqlClient;
using Dapper;
using Entities;

namespace DAL
{
    public static class EmployeesRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant2;Integrated Security=true";

        public static IEnumerable<EmployeesView> GetEmployees()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM dbo.Restaurant_Employees_View";

                return db.Query<EmployeesView>(query);
            }
        }
    }
}
