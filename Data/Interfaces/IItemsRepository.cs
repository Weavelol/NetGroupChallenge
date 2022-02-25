using Core.Models;
using Data.FilterParameters;

namespace Data.Interfaces {
    public interface IItemsRepository : IRepository<Item> {
        public Task UpdateAsync(Item item);
        public Task<IEnumerable<Item>> GetFilteredAsync(ItemFiltersParameters filters);
    }
}
