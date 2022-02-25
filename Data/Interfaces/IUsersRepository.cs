using Core.Models;

namespace Data.Interfaces {
    public interface IUsersRepository {
        public Task<IEnumerable<ApplicationUser>> GetAllAsync();
        public void UpdateLastLoginTime(string usersEmail);
    }
}
