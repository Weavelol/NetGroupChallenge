using DTOModels;

namespace Services.Interfaces {
    public interface IStoragesService : IService<StorageDTO, StorageCreateDTO> {
        public Task<IEnumerable<StorageDTO>> GetStoragesOfUserAsync(string userId);
    }
}
