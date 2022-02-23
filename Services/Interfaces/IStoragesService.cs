using Core.Models;

namespace Services.Interfaces {
    public interface IStoragesService : IService<Storage> {
        public Task<Storage> GetStorageByIdAsync(Guid id);
    }
}
