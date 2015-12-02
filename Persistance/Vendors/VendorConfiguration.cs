using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Vendors;

namespace CleanArchitecture.Persistance.Vendors
{
    public class VendorConfiguration
           : EntityTypeConfiguration<Vendor>
    {
        public VendorConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
