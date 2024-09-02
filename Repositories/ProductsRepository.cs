using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using ProductManager.Models;

namespace ProductManager.Repositories;

public class ProductsRepository
{
	private static List<Product> _products = new ();

	private readonly string _connectionString = "Data Source=ACER_ASPIRE_5;" +
	"Initial Catalog=ProductsDB;" +
	"Integrated Security=True;" +
	"Connect Timeout=30;" +
	"Encrypt=True;" +
	"TrustServerCertificate=True;" +
	"ApplicationIntent=ReadWrite;" +
	"MultiSubnetFailover=False";

	public void AddProduct(Product product)
	{
		using (SqlConnection connection = new(_connectionString))
		{
			connection.Open();
			string sql = "INSERT INTO Products (Name, Description, Price)" +
			             " VALUES (@Name, @Description, @Price)";
			using (SqlCommand command = new(sql, connection))
			{
				command.Parameters.AddWithValue("@Name", product.Name);
				command.Parameters.AddWithValue("@Description", product.Description);
				command.Parameters.AddWithValue("@Price", product.Price);
				command.ExecuteNonQuery();
			}
		}
	}
	
	public List<Product> GetProducts()
	{
		_products.Clear();
		using SqlConnection connection = new(_connectionString);
		connection.Open();
		SqlCommand command = new("SELECT * FROM Products", connection);
		DataAdapter adapter = new SqlDataAdapter(command);
		DataSet dataSet = new();
		DataTable dataTable = new();
		adapter.Fill(dataSet);
		dataTable = dataSet.Tables[0];
		connection.Close();
		foreach (DataRow row in dataTable.Rows)
		{
			_products.Add(new Product
			{
				Name = row["Name"].ToString(),
				Description = row["Description"].ToString(),
				Price = Convert.ToInt32(row["Price"])
			});
		}
		
		return _products;
	}

	public void RemoveProduct(string name)
	{
		using SqlConnection connection = new(_connectionString);
		connection.Open();
		String sql = "DELETE FROM Products WHERE Name = @Name";
		SqlCommand command = new(sql, connection);
		command.Parameters.AddWithValue("@Name", name);
		command.ExecuteNonQuery();
	}
}