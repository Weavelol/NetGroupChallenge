using Services.Interfaces;
using Core.Models;
using Data.Interfaces;

namespace Services.Services {
    public class ItemsService : AbstractService<Item>, IItemsService {
        private readonly IItemsRepository itemsRepository;
        public ItemsService(IItemsRepository itemsRepository) : base(itemsRepository){
            this.itemsRepository = itemsRepository;
        }

        public override async Task DeleteAsync(Guid id) {
            await itemsRepository.DeleteAsync(id);
        }

        public override async Task<IEnumerable<Item>> GetAllAsync() {
            return await itemsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Item item) {
            await itemsRepository.UpdateAsync(item);
        }
    }
}
