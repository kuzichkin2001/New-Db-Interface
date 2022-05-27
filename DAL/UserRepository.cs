using System.Data.SqlClient;
using Entities;
using Dapper;

namespace DAL
{
    public static class UserRepository
    {
        private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant2;Integrated Security=true";

        public static IEnumerable<UserView> GetUsers()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users";

                return db.Query<UserView>(query).ToList();
            }
        }

        public static UserView GetUser(string username)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users WHERE username = @Username";

                var param = new DynamicParameters();
                param.Add("Username", username);

                return db.Query<UserView>(query, param).First();
            }
        }

        public static int RegisterUser(UserView userView)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Users (firstname, lastname, patronymicname, username, password, role)" +
                    "VALUES (@Firstname, @Lastname, @Patronymicname, @Username, @Password, @Role); SELECT SCOPE_IDENTITY();";

                return db.Query<int>(query, userView).First();
            }
        }

        public static bool Login(LoginView loginView)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var query = "SELECT username, password FROM Users WHERE username = @Username";

                var param = new DynamicParameters();

                param.Add("Username", loginView.Username);

                IEnumerable<UserView> userViews = db.Query<UserView>(query, param);

                foreach (var userView in userViews)
                {
                    if (userView.Password.Equals(loginView.Password))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
