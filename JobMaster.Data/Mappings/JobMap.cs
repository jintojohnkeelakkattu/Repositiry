using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Data
{
    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(t => t.Description).IsRequired().HasMaxLength(500).HasColumnType("varchar(500)");
            builder.Property(t => t.Experience).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(t => t.Company).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(t => t.SalaryFrom).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(t => t.SalaryTo).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(t => t.UserId);
        }
    }
}
