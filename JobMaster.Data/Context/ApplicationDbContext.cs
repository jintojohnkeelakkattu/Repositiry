using JobMaster.Data;
using Microsoft.EntityFrameworkCore;

namespace JobMaster.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().
            //new UserMap(modelBuilder.Entity<User>());
            //new UserDetailMap(modelBuilder.Entity<UserDetail>());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
