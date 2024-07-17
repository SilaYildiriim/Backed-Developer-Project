using Backed_Developer_Project.Domain.Entities;
using Backed_Developer_Project.InfraStructure.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backed_Developer_Project.InfraStructure.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-G2S16HQ;Database=Backed_Developer_Project_DB;Uid=sa;Pwd=123");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Admin Seed Data
            var adminUser = new User
            {
                Id = "1",
                UserName = "admin",
                Password = "1234",
                NormalizedUserName = "ADMIN",
            };

            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "1234");

            builder.Entity<User>().HasData(adminUser);
            #endregion

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new FormConfiguration());
            builder.ApplyConfiguration(new FormFieldConfiguration());

            base.OnModelCreating(builder);
        }
    }


}
