using System.Net.Http.Json;
using BlazorClientServices.Interfaces;
using DTOModels;

namespace BlazorClientServices.Services {
    public class ApiService : IApiService {
        private readonly HttpClient http;

        public ApiService(HttpClient http) { 
            this.http = http;
        }

        public async Task<List<ApplicationUserDTO>> GetUsersAsync() {
            return await http.GetFromJsonAsync<List<ApplicationUserDTO>>("api/users");
        }
        public async Task<StatisticsDTO> GetUsersStatisticsAsync(string userId) {
            return await http.GetFromJsonAsync<StatisticsDTO>($"api/statistics/{userId}");
        }


        public async Task<StorageDTO> GetStorageByIdAsync(Guid? storageId) {
            return await http.GetFromJsonAsync<StorageDTO>($"api/storages/{storageId}");
        }
        public async Task<List<StorageDTO>> GetStoragesAsync() {
            return await http.GetFromJsonAsync<List<StorageDTO>>($"api/storages");
        }
        public async Task PostStorageAsync(StorageCreateDTO storage) {
            await http.PostAsJsonAsync("api/storages", storage);
        }
        public async Task DeleteStorageAsync(Guid? storageId) {
            await http.DeleteAsync($"api/storages/{storageId}");
        }


        public async Task<List<ItemDTO>> GetItemsAsync(string apiQuery) {
            return await http.GetFromJsonAsync<List<ItemDTO>>($"api/{apiQuery}");
        }
        public async Task PostItemAsync(ItemCreateDTO item) {
            await http.PostAsJsonAsync("api/items", item);
        }
        public async Task PutItemAsync(Guid? updatingItemId, ItemCreateDTO item) {
            await http.PutAsJsonAsync($"api/items/{updatingItemId}", item);
        }
        public async Task DeleteItemAsync(Guid? itemId) {
            await http.DeleteAsync($"api/items/{itemId}");
        }
    }
}
