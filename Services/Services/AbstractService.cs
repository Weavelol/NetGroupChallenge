using Services.Interfaces;
using Data.Interfaces;
using Core.Models;

namespace Services.Services {
    public abstract class AbstractService<T> : IService<T> where T : AbstractModel{
        protected readonly IRepository<T> Repository;

        public AbstractService(IRepository<T> repository) {
            Repository = repository;
        }

        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task DeleteEntityAsync(Guid id);

        public async Task<T> GetByIdAsync(Guid id) {
            return await Repository.GetByIdAsync(id);
        }

        public async Task<T> CreateEntityAsync(T entity) {
            return await Repository.CreateAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id) {
            return await Repository.ExistsAsync(id);
        }
    }
}
