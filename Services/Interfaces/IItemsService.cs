using DTOModels;
using Data.FilterParameters;

namespace Services.Interfaces {
    public interface IItemsService : IService<ItemDTO, ItemCreateDTO> {
        public Task UpdateAsync(Guid id, ItemCreateDTO item);
       public Task<IEnumerable<ItemDTO>> GetFilteredAsync(ItemFilters filters);
    }
}
