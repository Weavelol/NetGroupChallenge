using DTOModels;

namespace BlazorClientServices.Interfaces {
    public interface IApiService {
        public Task<List<ApplicationUserDTO>> GetUsersAsync();
        public Task<StatisticsDTO> GetUsersStatisticsAsync(string userId);

        public Task<StorageDTO> GetStorageByIdAsync(Guid? storageId);
        public Task<List<StorageDTO>> GetStoragesAsync();
        public Task PostStorageAsync(StorageCreateDTO storage);
        public Task DeleteStorageAsync(Guid? storageId);


        public Task<List<ItemDTO>> GetItemsAsync(string apiQuery);
        public Task PostItemAsync(ItemCreateDTO item);
        public Task PutItemAsync(Guid? updatingItemId, ItemCreateDTO item);
        public Task DeleteItemAsync(Guid? itemId);
    }
}
