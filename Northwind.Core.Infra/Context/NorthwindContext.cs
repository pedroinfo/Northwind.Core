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
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Territories> Territories { get; set; }
        
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
