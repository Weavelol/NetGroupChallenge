using Services.Interfaces;
using Core.Models;
using Data.Interfaces;
using DTOModels;
using AutoMapper;

namespace Services.Services {
    /// <inheritdoc/>
    public class StoragesService : AbstractService<Storage, StorageDTO, StorageCreateDTO>, IStoragesService {
        private readonly IStoragesRepository storagesRepository;
        public StoragesService(IStoragesRepository storagesRepository, IMapper mapper) : base(storagesRepository, mapper){
            this.storagesRepository = storagesRepository;
        }

        /// <inheritdoc/>
        public override async Task<IEnumerable<StorageDTO>> GetAllAsync() {
            var storages = await storagesRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<StorageDTO>>(storages);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StorageDTO>> GetStoragesOfUserAsync(string userId) {
            var storages = await storagesRepository.GetStoragesOfUserAsync(userId);
            return Mapper.Map<IEnumerable<StorageDTO>>(storages);
        }
    }
}
