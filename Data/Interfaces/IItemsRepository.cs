using Core.Models;

namespace Data.Interfaces {
    public interface IItemsRepository : IRepository<Item> {
        public Task UpdateAsync(Item item);
    }
}
