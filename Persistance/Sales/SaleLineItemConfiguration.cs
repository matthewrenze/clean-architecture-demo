using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Persistance.Sales
{
    public class SaleLineItemConfiguration 
        : EntityTypeConfiguration<SaleLineItem>
    {
        public SaleLineItemConfiguration()
        {
            HasKey(p => p.Id);

            HasRequired(p => p.Product);

            Property(p => p.Quantity)
                .IsRequired();

            Property(p => p.Price)
                .IsRequired()
                .HasPrecision(5, 2);
        }
    }
}
