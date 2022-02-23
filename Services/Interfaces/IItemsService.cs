using Core.Models;

namespace Services.Interfaces {
    public interface IItemsService : IService<Item> {
        public Task<IEnumerable<Item>> GetAllAsync();
        public Task<IEnumerable<Item>> GetItemsOfStorage(Guid? storageId);
        public Task UpdateAsync(Item item);
    }
}
