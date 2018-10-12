using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Infra.Mapping
{
    public class CustomerCustomerDemoMap : IEntityTypeConfiguration<CustomerCustomerDemo>
    {
        public void Configure(EntityTypeBuilder<CustomerCustomerDemo> builder)
        {
            
                builder.HasKey(e => new { e.CustomerId, e.CustomerTypeId })
                    .ForSqlServerIsClustered(false);

                builder.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(5);

                builder.Property(e => e.CustomerTypeId)
                    .HasColumnName("CustomerTypeID")
                    .HasMaxLength(10);

                builder.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCustomerDemo)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerCustomerDemo_Customers");

                builder.HasOne(d => d.CustomerType)
                    .WithMany(p => p.CustomerCustomerDemo)
                    .HasForeignKey(d => d.CustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerCustomerDemo");
            
        }
    }
}
