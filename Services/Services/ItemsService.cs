using Services.Interfaces;
using Core.Models;
using Data.Interfaces;

namespace Services.Services {
    public class ItemsService : AbstractService<Item>, IItemsService {
        private readonly IImagesRepository imagesRepository;
        private readonly IItemsRepository itemsRepository;
        public ItemsService(IItemsRepository itemsRepository, IImagesRepository imagesRepository) : base(itemsRepository){
            this.imagesRepository = imagesRepository;
            this.itemsRepository = itemsRepository;
        }

        public override async Task DeleteEntityAsync(Guid id) {
            var item = await Repository.GetByIdAsync(id);

            await imagesRepository.DeleteAsync(item.ImageId);
            await itemsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Item>> GetAllAsync() {
            return await itemsRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsOfStorage(Guid? storageId) {
            return await itemsRepository.GetItemsOfStorage(storageId);
        }

        public async Task UpdateAsync(Item item) {
            await itemsRepository.UpdateItemAsync(item);
        }
    }
}
