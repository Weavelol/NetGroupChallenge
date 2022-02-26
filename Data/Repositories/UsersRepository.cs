using Core.Models;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories {
    /// <inheritdoc/>
    public class UsersRepository : IUsersRepository {
        private readonly ApplicationDbContext context;
        public UsersRepository(ApplicationDbContext context) { 
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync() {
            return await context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<ApplicationUser> GetUserByIdAsync(string userId) {
            return await context.Users
                .Where(x => x.Id == userId)
                .AsNoTracking()
                .FirstAsync();
        }

        /// <inheritdoc/>
        public void UpdateLastLoginTime(string userEmail) {
            var user = context.Users
                .Where(x => x.Email == userEmail)
                .FirstOrDefault();

            user.LastLoginDate = DateTime.Now;
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
