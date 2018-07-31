using Alstom.Libraries.DAL.Interfaces;
using Alstom.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.DAL.Impl
{
    public class CustomersContext : DbContext, ICustomersContext
    {
        private static string CONNECTION_STRING =
            ConfigurationManager.ConnectionStrings["MVVMTrainingDB"].ConnectionString;

        public CustomersContext() : base(CONNECTION_STRING) { }

        public IDbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add<Customer>(
                new CustomerEntityTypeConfiguration());
        }
    }
}
