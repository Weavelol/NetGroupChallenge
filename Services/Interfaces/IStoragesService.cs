using DTOModels;

namespace Services.Interfaces {
    /// <summary>
    /// Getting requests from external layer and communicates it to repository layer.
    /// </summary>
    public interface IStoragesService : IService<StorageDTO, StorageCreateDTO> {

        /// <summary>
        /// Getting Storages of specified User
        /// </summary>
        /// <param name="userId">specified user id</param>
        /// <returns>info about user's storages as DTO collection</returns>
        public Task<IEnumerable<StorageDTO>> GetStoragesOfUserAsync(string userId);
    }
}
