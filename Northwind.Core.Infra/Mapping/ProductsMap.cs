using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Infra.Mapping
{
    public class ProductsMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            throw new NotImplementedException();
        }
    }
}
