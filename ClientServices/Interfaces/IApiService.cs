namespace ClientServices.Interfaces {
    public interface IApiService {
        public Task<List<T>> GetEntitiesAsync<T>(string url);
        public Task<T> GetEntityAsync<T>(string url);
        public Task CreateEntityAsync(string url, object entity);
        public Task UpdateEntityAsync(string url, object entity);
        public Task DeleteAsync(string url);
    }
}
