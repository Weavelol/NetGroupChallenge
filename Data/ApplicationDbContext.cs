﻿using Core.Models;
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

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Storage>()
                .HasMany(x => x.NestedStorages)
                .WithOne(x => x.ParentStorage)
                .OnDelete(DeleteBehavior.Cascade);

            var adminRole = new IdentityRole {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            var userRole = new IdentityRole {
                Name = "User",
                NormalizedName = "USER",
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            builder.Entity<IdentityRole>().HasData(adminRole);
            builder.Entity<IdentityRole>().HasData(userRole);


            var hasher = new PasswordHasher<IdentityUser>();

            var adminUser = new IdentityUser {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin123#"),
                SecurityStamp = Guid.NewGuid().ToString()
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