using System.Collections.Generic;
using System.Linq;

namespace CommandsLibrary
{
    public class CustomerService : ICustomerService
    {
        private static string PHOTOS_PATH = @"C:\00 WPF\Demonstrations\people";
        public IEnumerable<Customer> GetCustomers(string customerName = null)
        {
            var customersList = new List<Customer>
            {
                new Customer { Id = 1, Name = "Northwind", Address = "Bangalore", Credit = 23000, Status = true, PhotoUrl = string.Format (@"{0}\Customer{1}.jpg", PHOTOS_PATH, 1)},
                new Customer { Id = 2, Name = "Southwind", Address = "Bangalore", Credit = 23000, Status = true, PhotoUrl = string.Format (@"{0}\Customer{1}.jpg", PHOTOS_PATH, 2)},
                new Customer { Id = 3, Name = "Eastwind", Address = "Mangalore", Credit = 23000, Status = true, PhotoUrl = string.Format (@"{0}\Customer{1}.jpg", PHOTOS_PATH, 3)},
                new Customer { Id = 4, Name = "Westwind", Address = "Bangalore", Credit = 23000, Status = true, PhotoUrl = string.Format (@"{0}\Customer{1}.jpg", PHOTOS_PATH, 4)},
                new Customer { Id = 5, Name = "Adventureworks", Address = "Hassan", Credit = 23000, Status = false, PhotoUrl = string.Format (@"{0}\Customer{1}.jpg", PHOTOS_PATH, 5)},
                new Customer { Id = 6, Name = "Footmart", Address = "Bangalore", Credit = 33000, Status = true, PhotoUrl = string.Format (@"{0}\Customer{1}.jpg", PHOTOS_PATH, 6)},
                new Customer { Id = 7, Name = "ePublishers", Address = "Mysore", Credit = 23000, Status = true, PhotoUrl = string.Format (@"{0}\Customer{1}.jpg", PHOTOS_PATH, 7)}
            };

            if (string.IsNullOrEmpty(customerName))
                return customersList;

            var filteredCustomers =
                from customer in customersList
                where customer.Name.Contains(customerName)
                orderby customer.Name
                select customer;

            return filteredCustomers.ToList();
        }
    }
}
