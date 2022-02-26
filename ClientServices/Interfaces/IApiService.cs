namespace ClientServices.Interfaces {
    /// <summary>
    /// Used to make http requests to api
    /// </summary>
    public interface IApiService {
        /// <summary>
        /// Get request of entities of required type
        /// </summary>
        /// <typeparam name="T">required type of entities</typeparam>
        /// <param name="url">api url</param>
        /// <returns>entities collection of required type</returns>
        public Task<List<T>> GetEntitiesAsync<T>(string url);

        /// <summary>
        /// Get request of entity of required  type
        /// </summary>
        /// <typeparam name="T">required type of entity</typeparam>
        /// <param name="url">api url</param>
        /// <returns>entity of required type</returns>
        public Task<T> GetEntityAsync<T>(string url);

        /// <summary>
        /// Post request
        /// </summary>
        /// <param name="url">api url</param>
        /// <param name="entity">object to post</param>
        public Task CreateEntityAsync(string url, object entity);

        /// <summary>
        /// Update request
        /// </summary>
        /// <param name="url">api url</param>
        /// <param name="entity">entity to update</param>
        public Task UpdateEntityAsync(string url, object entity);

        /// <summary>
        /// Delete request
        /// </summary>
        /// <param name="url">api url</param>
        public Task DeleteAsync(string url);
    }
}
