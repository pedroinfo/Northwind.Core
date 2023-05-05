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
        public DbSet<Category> Category { get; set; }
        public DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeTerritories> EmployeeTerritory { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Territory> Territory { get; set; }
        
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
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CustomerCustomerDemoMap());
            builder.ApplyConfiguration(new CustomerDemographicMap());
            builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new EmployeeTerritoryMap());
            builder.ApplyConfiguration(new OrderDetailMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new RegionMap());
            builder.ApplyConfiguration(new ShippersMap());
            builder.ApplyConfiguration(new SupplierMap());
            builder.ApplyConfiguration(new TerritoryMap());
        }
    }
}
