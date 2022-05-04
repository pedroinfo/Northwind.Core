using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Domain.Entities;

namespace Northwind.Core.Domain.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);

            builder.Property(a => a.CategoryName);
            builder.Property(a => a.Description);
            builder.Property(a => a.Picture);

            builder.ToTable("Categories");
        }
    }
}
