using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ADO.NET_fundamentals.Models;

namespace ADO.NET_fundamentals.Repository
{
    public class ProductRepository
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OrderDB;Integrated Security=True";

        public ProductRepository()
        {
        }

        public void Create(Product product)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var query = "INSERT INTO dbo.Product " +
                            "(Name, Description, Weight, Height, Width, Length) " +
                            "values (@Name, @Description , @Weight, @Height, @Width, @Length); " +
                            "SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, sqlConnection);

                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Weight", product.Weight);
                command.Parameters.AddWithValue("@Height", product.Height);
                command.Parameters.AddWithValue("@Width", product.Width);
                command.Parameters.AddWithValue("@Length", product.Length);
                product.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Update(Product product)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE dbo.Product " +
                                            "SET Name = @Name, " +
                                            "Description = @Description, " +
                                            "Weight = @Weight, " +
                                            "Height = @Height, " +
                                            "Width = @Width, " +
                                            "Length = @Length " +
                                            "where Id = @Id";
                var command = new SqlCommand(query, sqlConnection);

                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Weight", product.Weight);
                command.Parameters.AddWithValue("@Height", product.Height);
                command.Parameters.AddWithValue("@Width", product.Width);
                command.Parameters.AddWithValue("@Length", product.Length);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM dbo.Product WHERE Id = " + id;
                var command = new SqlCommand(query, sqlConnection);
                
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }


        public Product Read(int id)
        {
            Product product = null;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM dbo.Product WHERE Id = @Id";
                var command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@Id", id);

                sqlConnection.Open();
                var executeReader = command.ExecuteReader();

                while (executeReader.Read())
                {
                    product = new Product();
                    product.Id = Convert.ToInt32(executeReader["Id"]);
                    product.Name = executeReader["Name"].ToString();
                    product.Description = executeReader["Description"].ToString();
                    product.Weight = Convert.ToInt32(executeReader["Weight"]);
                    product.Height = Convert.ToInt32(executeReader["Height"]);
                    product.Width = Convert.ToInt32(executeReader["Width"]);
                    product.Length = Convert.ToInt32(executeReader["Length"]);
                }
            }
            return product;
        }

        public IEnumerable<Product> Read()
        {
            var products = new List<Product>();
            using var sqlConnection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM dbo.Product";
            var command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            var executeReader = command.ExecuteReader();

            while (executeReader.Read())
            {
                var product = new Product();
                product.Id = Convert.ToInt32(executeReader["Id"]);
                product.Name = executeReader["Name"].ToString();
                product.Description = executeReader["Description"].ToString();
                product.Weight = Convert.ToInt32(executeReader["Weight"]);
                product.Height = Convert.ToInt32(executeReader["Height"]);
                product.Width = Convert.ToInt32(executeReader["Width"]);
                product.Length = Convert.ToInt32(executeReader["Length"]);
                products.Add(product);
            }

            return products;
        }
    }
}
