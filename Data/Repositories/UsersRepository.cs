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

        public void UpdateLastLoginTime(string userEmail) {
            var user = context.Set<ApplicationUser>().Where(x => x.Email == userEmail).FirstOrDefault();
            
            user.LastLoginDate = DateTime.Now;
            context.Set<ApplicationUser>().Update(user);
            context.SaveChanges();
        }
    }
}
