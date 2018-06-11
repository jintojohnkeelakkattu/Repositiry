using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Data
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(t => t.HashedPassword).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(t => t.Salt).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(t => t.CreatedUtc).IsRequired().HasDefaultValueSql("getutcdate()");
            builder.HasOne(t => t.UserDetail).WithOne(u => u.User).HasForeignKey<UserDetail>(x => x.Id);
            builder.HasMany(t => t.UserPhones).WithOne(u => u.User).HasForeignKey(x=>x.UserId);
        }
    }
}

