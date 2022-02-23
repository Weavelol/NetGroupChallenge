using Core.Models;

namespace Data.Interfaces {
    public interface IItemsRepository : IRepository<Item> {
        public Task<IEnumerable<Item>> GetItemsOfStorage(Guid? storageId);
    }
}
