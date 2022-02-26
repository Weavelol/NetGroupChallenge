using Core.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Data {
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser> {
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemImage> ItemsImages { get; set; }

        public ApplicationDbContext( DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            var adminRole = new IdentityRole {
                Name = Properties.Resources.adminRoleName,
                NormalizedName = Properties.Resources.adminRoleName.ToUpper(),
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            var userRole = new IdentityRole {
                Name = Properties.Resources.userRoleName,
                NormalizedName = Properties.Resources.userRoleName.ToUpper(),
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            builder.Entity<IdentityRole>().HasData(adminRole);
            builder.Entity<IdentityRole>().HasData(userRole);


            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser {
                Id = Guid.NewGuid().ToString(),
                UserName = Properties.Resources.adminEmail,
                NormalizedUserName = Properties.Resources.adminEmail.ToUpper(),
                Email = Properties.Resources.adminEmail,
                NormalizedEmail = Properties.Resources.adminEmail.ToUpper(),
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, Properties.Resources.adminPassword),
                SecurityStamp = Guid.NewGuid().ToString(),
                RegistrationDate = DateTime.Now,
            };

            builder.Entity<ApplicationUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string> {
                    RoleId = adminRole.Id,
                    UserId = adminUser.Id
                });
        }
    }
}