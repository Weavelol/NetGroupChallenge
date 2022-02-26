using DTOModels;
using Data.FilterParameters;

namespace Services.Interfaces {
    /// <summary>
    /// Getting requests from external layer and communicates it to repository layer.
    /// </summary>
    public interface IItemsService : IService<ItemDTO, ItemCreateDTO> {
        /// <summary>
        /// Update Item Operation
        /// </summary>
        /// <param name="id">Id of updating item</param>
        /// <param name="item">data of updating item</param>
        public Task UpdateAsync(Guid id, ItemCreateDTO item);

        /// <summary>
        /// Get filtered items from database
        /// </summary>
        /// <param name="filters">filters which have to be applied</param>
        /// <returns>filtered items as ItemDTO collection</returns>
        public Task<IEnumerable<ItemDTO>> GetFilteredAsync(ItemFiltersParameters filters);
    }
}
