using Alstom.Libraries.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.DAL.Impl
{
    public class CustomerEntityTypeConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityTypeConfiguration()
        {
            HasKey(model => model.CustomerId);

            Property(model => model.CustomerId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Ignore(model => model.PhotoUrl);

            ToTable("Customers");
        }
    }
}
