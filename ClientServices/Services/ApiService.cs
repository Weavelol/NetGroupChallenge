using System.Net.Http.Json;
using ClientServices.Interfaces;

namespace ClientServices.Services {
    public class ApiService : IApiService {
        private readonly HttpClient http;

        public ApiService(HttpClient http) {
            this.http = http;
        }

        public async Task<List<T>> GetEntitiesAsync<T>(string url) {
            return await http.GetFromJsonAsync<List<T>>(url);
        }
        public async Task<T> GetEntityAsync<T>(string url) {
            return await http.GetFromJsonAsync<T>(url);
        }
        public async Task CreateEntityAsync(string url, object entity) {
            await http.PostAsJsonAsync(url, entity);
        }
        public async Task UpdateEntityAsync(string url, object entity) {
            await http.PutAsJsonAsync(url, entity);
        }
        public async Task DeleteAsync(string url) {
            await http.DeleteAsync(url);
        }
    }
}
