using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Data
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(t => t.ParentId);
            builder.HasMany(t => t.Categories).WithOne(u => u.MasterCategory).HasForeignKey(x => x.ParentId);
        }
    }
}
