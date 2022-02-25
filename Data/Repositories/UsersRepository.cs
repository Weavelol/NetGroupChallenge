using Core.Models;
using Data.Interfaces;

namespace Data.Repositories {
    public class UsersRepository : IUsersRepository {
        public Task<IEnumerable<ApplicationUser>> GetAllAsync() {
            throw new NotImplementedException();
        }
    }
}
