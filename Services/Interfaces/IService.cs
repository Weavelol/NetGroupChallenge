namespace Services.Interfaces {
    public interface IService<T> {
        public Task<T> GetByIdAsync(Guid Id);
        public Task<T> CreateEntityAsync(T entity);
        public Task DeleteEntityAsync(Guid Id);
        public Task<bool> ExistsAsync(Guid id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
