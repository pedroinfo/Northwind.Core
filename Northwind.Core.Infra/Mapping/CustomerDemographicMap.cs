﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Infra.Mapping
{
    public class CustomerDemographicMap : IEntityTypeConfiguration<CustomerDemographics>
    {
        public void Configure(EntityTypeBuilder<CustomerDemographics> builder)
        {

            builder.ToTable("CustomerDemographics");

            builder.HasKey(e => e.CustomerTypeId)
                   .ForSqlServerIsClustered(false);

            builder.Property(e => e.CustomerTypeId)
                .HasColumnName("CustomerTypeID")
                .HasMaxLength(10)
                .ValueGeneratedNever();

            builder.Property(e => e.CustomerDescription).HasColumnType("ntext");
        }
    }
}
