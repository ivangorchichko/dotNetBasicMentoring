using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ADO.NET_fundamentals.Models;

namespace ADO.NET_fundamentals.Repository
{
    public class OrderRepository
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OrderDB;Integrated Security=True";

        public void Create(Order order)
        {
            var sql = "SELECT * FROM [dbo].[Order]";
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = commandBuilder.GetInsertCommand();

                adapter.Update(ds);
            }
        }

        public void Update(Order order)
        {
            var sql = "SELECT * FROM [dbo].[Order]";
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = commandBuilder.GetUpdateCommand();

                adapter.Update(ds);
            }
        }

        public void Delete(int? month = null,
            OrderStatus? status = null,
            int? year = null,
            int? productId = null)
        {
            var sql = "SELECT * FROM [dbo].[Order]";
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                //adapter.DeleteCommand = new SqlCommand("FetchOrders", sqlConnection);
                //adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
                //adapter.DeleteCommand.Parameters.AddWithValue("@month", month);
                //adapter.DeleteCommand.Parameters.AddWithValue("@status", (int?)status);
                //adapter.DeleteCommand.Parameters.AddWithValue("@year", year);
                //adapter.DeleteCommand.Parameters.AddWithValue("@productId", productId);

                //adapter.DeleteCommand.ExecuteNonQuery();
                //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
            }
        }

        public IEnumerable<Order> Read(int? month = null,
            OrderStatus? status = null,
            int? year = null,
            int? productId = null)
        {
            var sql = "SELECT * [dbo].[Order] Order";
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnection);

                adapter.SelectCommand = new SqlCommand("FetchOrders", sqlConnection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@month", month);
                adapter.SelectCommand.Parameters.AddWithValue("@status", (int?)status);
                adapter.SelectCommand.Parameters.AddWithValue("@year", year);
                adapter.SelectCommand.Parameters.AddWithValue("@productId", productId);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return from order in ds.Tables["Table"].AsEnumerable()
                    select new Order()
                    {
                        CreatedDate = (DateTime)order["CreatedDate"],
                        UpdatedDate = (DateTime)order["UpdatedDate"],
                        Status = (OrderStatus)order["Status"],
                        ProductId = (int)order["ProductId"],
                        Id = (int)order["Id"]
                    }; 
            }
        }
    }
}
