using System.Net.Http.Json;
using BlazorClientServices.Interfaces;
using Core.Models;

namespace BlazorClientServices.Services {
    public class ApiService : IApiService {
        private readonly HttpClient http;

        public ApiService(HttpClient http) { 
            this.http = http;
        }

        public async Task<Storage> GetStorageAsync(string url) {
            return await http.GetFromJsonAsync<Storage>(url);
        }
        public async Task<List<Storage>> GetStoragesAsync(string url) {
            return await http.GetFromJsonAsync<List<Storage>>(url);
        }
        public async Task PostStorageAsync(string url, Storage storage) {
            await http.PostAsJsonAsync(url, storage);
        }

        public async Task<List<Item>> GetItemsAsync(string url) {
            return await http.GetFromJsonAsync<List<Item>>(url);
        }
        public async Task PostItemAsync(string url, Item item) {
            await http.PostAsJsonAsync(url, item);
        }
        public async Task PutItemAsync(string url, Item item) {
            await http.PutAsJsonAsync(url, item);
        }

        public async Task DeleteAsync(string url) {
            await http.DeleteAsync(url);
        }
    }
}
