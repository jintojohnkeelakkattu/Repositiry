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
            builder.Property(t => t.HashedPassword).IsRequired();
            builder.Property(t => t.Salt).IsRequired();
            builder.HasOne(t => t.UserDetail).WithOne(u => u.User).HasForeignKey<UserDetail>(x => x.Id);
        }
    }
}

