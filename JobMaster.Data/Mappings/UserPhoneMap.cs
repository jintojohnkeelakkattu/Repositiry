using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Data
{
    public class UserPhoneMap : IEntityTypeConfiguration<UserPhone>
    {
        public void Configure(EntityTypeBuilder<UserPhone> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.PhoneNumber).IsRequired().HasMaxLength(20).HasColumnType("varchar(20)");
            builder.Property(t => t.PhoneType).IsRequired();
        }
    }
}

