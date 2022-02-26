using Core.Models;
using Data.FilterParameters;

namespace Data.Interfaces {
    public interface IItemsRepository : IRepository<Item> {
        /// <summary>
        /// Update item's data in database.
        /// </summary>
        /// <param name="item">item with data to be updated</param>
        public Task UpdateAsync(Item item);

        /// <summary>
        /// Getting all objects from database, which satisfy filter values
        /// </summary>
        /// <param name="filters">filter values</param>
        /// <returns>Item Objects which satisfy filter values</returns>
        public Task<IEnumerable<Item>> GetFilteredAsync(ItemFiltersParameters filters);
    }
}
