using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Data
{
    public class UserDetailMap:IEntityTypeConfiguration<UserDetail>
    {

        public void Configure(EntityTypeBuilder<UserDetail> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            entityBuilder.Property(t => t.LastName).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            entityBuilder.Property(t => t.Address).HasMaxLength(50).HasColumnType("varchar(50)");
        }
    }
}
