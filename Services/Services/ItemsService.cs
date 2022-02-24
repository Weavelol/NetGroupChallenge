using Services.Interfaces;
using Core.Models;
using Data.Interfaces;
using DTOModels;
using AutoMapper;

namespace Services.Services {
    public class ItemsService : AbstractService<Item, ItemDTO, ItemCreateDTO>, IItemsService {
        private readonly IItemsRepository itemsRepository;
        public ItemsService(IItemsRepository itemsRepository, IMapper mapper) : base(itemsRepository, mapper){
            this.itemsRepository = itemsRepository;
        }

        public override async Task<IEnumerable<ItemDTO>> GetAllAsync() {
            var entities = await itemsRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<ItemDTO>>(entities);
        }

        public async Task UpdateAsync(Guid id, ItemCreateDTO item) {
            var itemModel = Mapper.Map<Item>(item);
            itemModel.Id = id;
            await itemsRepository.UpdateAsync(itemModel);
        }
    }
}
