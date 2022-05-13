using NipamInfotechTask.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NipamInfotechTask.ProductServices
{
    public class ProductServices
    {
        private const string ConnectionString =
         @"Data Source=WL-5PFXVG3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        public List<Product> GetAllProduct()
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("select * from Products", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var Product = new Product
                            {
                               ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1)                              
                            };

                            products.Add(Product);
                        }
                    }
                }

            }
            return products;
        }
        public void Insert(Product product)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("InsertProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductId", product.ProductId);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(Product product)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("Updateproduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductId", product.ProductId);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string productId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("DeleteProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public Product Find(string productId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetProductById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            var product = new Product
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1)
                            };

                            return product;
                        }
                    }
                }
            }

            return null;
        }
    }
}

