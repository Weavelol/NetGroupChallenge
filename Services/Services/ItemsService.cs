using Services.Interfaces;
using Core.Models;
using Data.Interfaces;
using DTOModels;
using AutoMapper;
using Data.FilterParameters;

namespace Services.Services {
    /// <inheritdoc/>
    public class ItemsService : AbstractService<Item, ItemDTO, ItemCreateDTO>, IItemsService {
        private readonly IItemsRepository itemsRepository;
        public ItemsService(IItemsRepository itemsRepository, IMapper mapper) : base(itemsRepository, mapper){
            this.itemsRepository = itemsRepository;
        }

        /// <inheritdoc/>
        public override async Task<IEnumerable<ItemDTO>> GetAllAsync() {
            var entities = await itemsRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<ItemDTO>>(entities);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ItemDTO>> GetFilteredAsync(ItemFiltersParameters filters) {
            var entities = await itemsRepository.GetFilteredAsync(filters);
            return Mapper.Map<IEnumerable<ItemDTO>>(entities);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Guid id, ItemCreateDTO item) {
            var itemModel = Mapper.Map<Item>(item);
            itemModel.Id = id;
            await itemsRepository.UpdateAsync(itemModel);
        }
    }
}
