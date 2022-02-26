using System.Net.Http.Json;
using ClientServices.Interfaces;

namespace ClientServices.Services {
    /// <inheritdoc/>
    public class ApiService : IApiService {
        private readonly HttpClient http;

        public ApiService(HttpClient http) {
            this.http = http;
        }

        /// <inheritdoc/>
        public async Task<List<T>> GetEntitiesAsync<T>(string url) {
            return await http.GetFromJsonAsync<List<T>>(url);
        }

        /// <inheritdoc/>
        public async Task<T> GetEntityAsync<T>(string url) {
            return await http.GetFromJsonAsync<T>(url);
        }

        /// <inheritdoc/>
        public async Task CreateEntityAsync(string url, object entity) {
            await http.PostAsJsonAsync(url, entity);
        }

        /// <inheritdoc/>
        public async Task UpdateEntityAsync(string url, object entity) {
            await http.PutAsJsonAsync(url, entity);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string url) {
            await http.DeleteAsync(url);
        }
    }
}
