using DTOModels;

namespace BlazorClientServices.Interfaces {
    public interface IApiService {
        public Task<List<ApplicationUserDTO>> GetUsersAsync(string url);
        public Task<List<StorageDTO>> GetUsersStoragesAsync(string url);

        public Task<StorageDTO> GetStorageAsync(string url);
        public Task<List<StorageDTO>> GetStoragesAsync(string url);
        public Task PostStorageAsync(string url, StorageCreateDTO storage);

        public Task<List<ItemDTO>> GetItemsAsync(string url);
        public Task PostItemAsync(string url, ItemCreateDTO item);
        public Task PutItemAsync(string url, ItemCreateDTO item);

        public Task DeleteAsync(string url);
    }
}
