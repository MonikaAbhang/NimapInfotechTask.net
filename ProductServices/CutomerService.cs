using NipamInfotechTask.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NipamInfotechTask.ProductServices
{
    public class CustomerService
    {
        private const string ConnectionString =
         @"Data Source=WL-5PFXVG3\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        public List<Customer> GetAllCustomer()
        {
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("select * from Customers", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var customer = new Customer
                            {
                                CustomerId = reader.GetInt32(0),
                                CustomerName = reader.GetString(1)
                            };

                            customers.Add(customer);
                        }
                    }
                }

            }
            return customers;
        }
        public void Insert(Customer customer)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("InsertCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(Customer customer)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("UpdateCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int customerId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("DeleteCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public Customer Find(int customerId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("GetCustomerById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            var customer = new Customer
                            {
                                CustomerId = reader.GetInt32(0),
                                CustomerName = reader.GetString(1)
                            };

                            return customer;
                        }
                    }
                }
            }

            return null;
        }
    }
}

