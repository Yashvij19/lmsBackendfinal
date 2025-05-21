using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Sme> Smes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Lob> Lobs { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<Ta> Tas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "User" },
                new Role { RoleId = 2, RoleName = "Admin" },
                new Role { RoleId = 3, RoleName = "SME" },
                new Role { RoleId = 4, RoleName = "TA"}
            );

            // User and Lob relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Lob)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LobId);

            // User and Role relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // Admin and User relationship
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // SME and Admin relationship
            modelBuilder.Entity<Sme>()
                .HasOne(s => s.Admin)
                .WithMany()
                .HasForeignKey(s => s.AdminId)
                .OnDelete(DeleteBehavior.Cascade);

            //TA
            modelBuilder.Entity<Ta>()
               .HasOne(t => t.Admin)
               .WithMany()
               .HasForeignKey(t => t.AdminId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
