using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Data
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(t => new { t.UserId, t.RoleId });
            builder.HasOne(t => t.Role).WithMany(u => u.UserRoles).HasForeignKey(x => x.RoleId);
            builder.HasOne(t => t.User).WithMany(u => u.UserRoles).HasForeignKey(x => x.UserId);
        }
    }
}

