using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Northwind.Core.Domain;
using Northwind.Core.Domain.Entities;
using Northwind.Core.Infra.Mapping;

namespace Northwind.Core.Infra.Context
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
 
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoriesMap());
            builder.ApplyConfiguration(new CustomerCustomerDemoMap());
            builder.ApplyConfiguration(new CustomerDemographicsMap());
            builder.ApplyConfiguration(new CustomersMap());
            builder.ApplyConfiguration(new EmployeesMap());
            builder.ApplyConfiguration(new EmployeeTerritoriesMap());
            builder.ApplyConfiguration(new OrderDetailsMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new ProductsMap());
            builder.ApplyConfiguration(new RegionMap());
            builder.ApplyConfiguration(new ShippersMap());
            builder.ApplyConfiguration(new SuppliersMap());
            builder.ApplyConfiguration(new TerritoriesMap());
        }
    }
}
