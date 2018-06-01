using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Data
{
    public class UserDetailMap
    {
        public UserDetailMap(EntityTypeBuilder<UserDetail> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Address);
        }
    }
}
