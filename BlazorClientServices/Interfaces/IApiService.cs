using Core.Models;

namespace BlazorClientServices.Interfaces {
    public interface IApiService {
        public Task<Storage> GetStorageAsync(string url);
        public Task<List<Storage>> GetStoragesAsync(string url);
        public Task PostStorageAsync(string url, Storage storage);

        public Task<List<Item>> GetItemsAsync(string url);
        public Task PostItemAsync(string url, Item item);
        public Task PutItemAsync(string url, Item item);

        public Task DeleteAsync(string url);
    }
}
