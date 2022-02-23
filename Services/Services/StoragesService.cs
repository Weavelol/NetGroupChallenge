using Services.Interfaces;
using Core.Models;
using Data.Interfaces;

namespace Services.Services {
    public class StoragesService : AbstractService<Storage>, IStoragesService {
        private readonly IStoragesRepository storagesRepository;
        public StoragesService(IStoragesRepository storagesRepository) : base(storagesRepository){
            this.storagesRepository = storagesRepository;
        }

        public override async Task DeleteEntityAsync(Guid id) {
            await Repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Storage>> GetAllAsync() {
            return await storagesRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentId) {
            return await storagesRepository.GetNestedStoragesAsync(parentId);
        }

        public async Task<Storage> GetStorageByIdAsync(Guid id) {
            return await storagesRepository.GetStorageByIdAsync(id);
        }
    }
}
