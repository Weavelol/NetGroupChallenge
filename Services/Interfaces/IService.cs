namespace Services.Interfaces {
    public interface IService<T> {
        public Task<T> GetByIdAsync(Guid Id);
        public Task<T> CreateAsync(T entity);
        public Task DeleteAsync(Guid Id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
