using EvaluationBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvaluationBackend.DATA
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<AppUser> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Fine> fines { get; set; }
        public DbSet<FineTypes> fineTypes { get; set; }
        public DbSet<Citizen> citizens { get; set; }
        public DbSet<PlaceFine> placeFines { get; set; }
        
 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId, rp.PermissionId });

            
// seed data 

        }
        
    }
}