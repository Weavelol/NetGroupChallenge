using DTOModels;

namespace Services.Interfaces {
    public interface IItemsService : IService<ItemDTO, ItemCreateDTO> {
        public Task UpdateAsync(Guid id, ItemCreateDTO item);
    }
}
