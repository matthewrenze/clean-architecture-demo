using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Persistance.Sales
{
    public class SaleConfiguration
           : EntityTypeConfiguration<Sale>
    {
        public SaleConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.DateTime)
                .IsRequired();

            HasRequired(p => p.Customer);

            HasRequired(p => p.Employee);

            HasMany(p => p.LineItems);

            Property(p => p.TotalAmount)
                .IsRequired()
                .HasPrecision(5, 2);
        }
    }
}
