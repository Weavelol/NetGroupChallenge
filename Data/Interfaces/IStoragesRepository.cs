using Core.Models;

namespace Data.Interfaces {
    public interface IStoragesRepository : IRepository<Storage>{
        public Task<Storage> GetStorageByIdAsync(Guid id);
    }
}
