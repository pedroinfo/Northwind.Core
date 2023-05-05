﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Domain.Entities;

namespace Northwind.Core.Infra.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
                builder.HasKey(e => e.OrderId);

                builder.HasIndex(e => e.CustomerId)
                    .HasName("CustomersOrders");

                builder.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeesOrders");

                builder.HasIndex(e => e.OrderDate)
                    .HasName("OrderDate");

                builder.HasIndex(e => e.ShipPostalCode)
                    .HasName("ShipPostalCode");

                builder.HasIndex(e => e.ShipVia)
                    .HasName("ShippersOrders");

                builder.HasIndex(e => e.ShippedDate)
                    .HasName("ShippedDate");

                builder.Property(e => e.OrderId).HasColumnName("OrderID");

                builder.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(5);

                builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                builder.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                builder.Property(e => e.OrderDate).HasColumnType("datetime");

                builder.Property(e => e.RequiredDate).HasColumnType("datetime");

                builder.Property(e => e.ShipAddress).HasMaxLength(60);

                builder.Property(e => e.ShipCity).HasMaxLength(15);

                builder.Property(e => e.ShipCountry).HasMaxLength(15);

                builder.Property(e => e.ShipName).HasMaxLength(40);

                builder.Property(e => e.ShipPostalCode).HasMaxLength(10);

                builder.Property(e => e.ShipRegion).HasMaxLength(15);

                builder.Property(e => e.ShippedDate).HasColumnType("datetime");

                builder.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                builder.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                builder.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers");
            }
    }
}
