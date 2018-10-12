using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Infra.Mapping
{
    public class TerritoriesMap : IEntityTypeConfiguration<Territories>
    {
        public void Configure(EntityTypeBuilder<Territories> builder)
        {
            throw new NotImplementedException();
        }
    }
}
