using Core.Models;

namespace Data.Interfaces {
    public interface IStoragesRepository : IRepository<Storage>{
        public Task<IEnumerable<Storage>> GetStoragesOfUserAsync(string UserId);
    }
}
