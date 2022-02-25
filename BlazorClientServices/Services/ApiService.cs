using System.Net.Http.Json;
using BlazorClientServices.Interfaces;
using DTOModels;

namespace BlazorClientServices.Services {
    public class ApiService : IApiService {
        private readonly HttpClient http;

        public ApiService(HttpClient http) { 
            this.http = http;
        }

        public async Task<List<ApplicationUserDTO>> GetUsersAsync(string url) {
            return await http.GetFromJsonAsync<List<ApplicationUserDTO>>(url);
        }
        public async Task<StatisticsDTO> GetUsersStatisticsAsync(string url) {
            return await http.GetFromJsonAsync<StatisticsDTO>(url);
        }


        public async Task<StorageDTO> GetStorageAsync(string url) {
            return await http.GetFromJsonAsync<StorageDTO>(url);
        }
        public async Task<List<StorageDTO>> GetStoragesAsync(string url) {
            return await http.GetFromJsonAsync<List<StorageDTO>>(url);
        }
        public async Task PostStorageAsync(string url, StorageCreateDTO storage) {
            await http.PostAsJsonAsync(url, storage);
        }

        public async Task<List<ItemDTO>> GetItemsAsync(string url) {
            return await http.GetFromJsonAsync<List<ItemDTO>>(url);
        }
        public async Task PostItemAsync(string url, ItemCreateDTO item) {
            await http.PostAsJsonAsync(url, item);
        }
        public async Task PutItemAsync(string url, ItemCreateDTO item) {
            await http.PutAsJsonAsync(url, item);
        }

        public async Task DeleteAsync(string url) {
            await http.DeleteAsync(url);
        }
    }
}
