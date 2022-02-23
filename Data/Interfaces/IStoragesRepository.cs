using Core.Models;

namespace Data.Interfaces {
    public interface IStoragesRepository : IRepository<Storage>{
        public Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentStorageId);
    }
}
