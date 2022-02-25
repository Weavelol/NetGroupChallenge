using Core.Models;

namespace Data.Interfaces {
    public interface IUsersRepository {
        public Task<IEnumerable<ApplicationUser>> GetAllAsync();
        public Task<ApplicationUser> GetUserByIdAsync(string userId);
        public void UpdateLastLoginTime(string usersEmail);
    }
}
