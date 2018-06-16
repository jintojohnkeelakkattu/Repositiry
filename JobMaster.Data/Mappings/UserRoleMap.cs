using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Data
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(t => new {  t.UserId, t.RoleId }).ForSqlServerIsClustered();
            builder.HasOne(t => t.Role).WithOne(u => u.UserRole).HasForeignKey<UserRole>(x => x.RoleId);
            builder.HasOne(t => t.User).WithOne(u => u.UserRole).HasForeignKey<UserRole>(x => x.UserId);
        }
    }
}

