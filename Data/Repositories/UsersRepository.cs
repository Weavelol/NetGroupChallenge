using Core.Models;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories {
    public class UsersRepository : IUsersRepository {
        private readonly ApplicationDbContext context;
        public UsersRepository(ApplicationDbContext context) { 
            this.context = context;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync() {
            return await context.Set<ApplicationUser>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateLastLoginTime(string userId) {
            var user = await context.Set<ApplicationUser>()
                .Where(x => x.Id == userId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            user.LastLoginDate = DateTime.Now;
            context.Set<ApplicationUser>().Update(user);
            await context.SaveChangesAsync();
        }
    }
}
