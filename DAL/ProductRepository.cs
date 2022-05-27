using Entities;
using System.Data.SqlClient;
using Dapper;

namespace DAL;
public static class ProductRepository
{
    private static readonly string _connectionString = @"Server=DESKTOP-0URHI91\SQLEXPRESS;Database=Restaurant;Integrated Security=true";

    public static ProductView GetProduct(int id)
    {
        using (var db = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Product WHERE id_product = @ID";

            var param = new DynamicParameters();

            param.Add("ID", id);

            return db.Query<ProductView>(query, param).First();
        }
    }

    public static void EditProduct(ProductView view)
    {
        using (var db = new SqlConnection(_connectionString))
        {
            var query = "UPDATE Product SET product_name = @Product_Name, " +
                "exp_time = @Exp_Time, arrivement_date = @Arrivement_Date, cost = @Cost, " +
                "supplier = @Supplier WHERE id_product = @Id_Product;";

            db.Query(query, view);
        }
    }

    public static void DeleteProduct(int id)
    {
        using (var db = new SqlConnection(_connectionString))
        {
            var query = "DELETE FROM Product_List WHERE product_id = @ID;\n" +
                "DELETE FROM Product WHERE id_product = @ID;";

            var param = new DynamicParameters();

            param.Add("ID", id);

            db.Query(query, param);
        }
    }

    public static IEnumerable<ProductView> GetProducts()
    {
        using (var db = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Product";

            return db.Query<ProductView>(query).ToList();
        }
    }

    public static int CreateProduct(ProductView prView)
    {
        using (var db = new SqlConnection(_connectionString))
        {
            var query = $"INSERT INTO Product (product_name, exp_time, arrivement_date, cost, supplier) " +
                $"VALUES (@Product_Name, @Exp_Time, @Arrivement_Date, @Cost, @Supplier); SELECT SCOPE_IDENTITY();";

            return db.Query<int>(query, prView).First();
        }
    }
}

