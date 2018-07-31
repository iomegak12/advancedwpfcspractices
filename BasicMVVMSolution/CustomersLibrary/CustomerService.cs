using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace CustomersLibrary
{
    public class CustomerService : ICustomerService
    {
        public IEnumerable<Customer> GetCustomers()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MVVMTrainingDB"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
                throw new ApplicationException("Invalid Connection String Configured!");

            var photosFolder = ConfigurationManager.AppSettings["PhotosFolder"];
            var customersList = new List<Customer>();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlStatement = @"SELECT * FROM Customers";

                var command = new SqlCommand(sqlStatement, sqlConnection);

                sqlConnection.Open();

                var sqlResultReader = command.ExecuteReader();

                while (sqlResultReader.Read())
                {
                    var customerId = sqlResultReader.GetInt32(0);
                    var customer = new Customer
                    {
                        Id = customerId,
                        Name = sqlResultReader.GetString(1),
                        Address = sqlResultReader.GetString(2),
                        Credit = sqlResultReader.GetInt32(3),
                        Status = sqlResultReader.GetBoolean(4),
                        PhotoUrl = string.Format(@"{0}\Customer{1}.jpg",
                            photosFolder, customerId)
                    };

                    customersList.Add(customer);
                }
            }

            return customersList;
        }
    }
}
