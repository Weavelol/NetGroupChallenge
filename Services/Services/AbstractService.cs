using Services.Interfaces;
using Data.Interfaces;
using Core.Models;

namespace Services.Services {
    public class AbstractService<T> : IService<T> where T : AbstractModel{
        protected readonly IRepository<T> Repository;

        public AbstractService(IRepository<T> repository) {
            Repository = repository;
        }

        public async Task<T> GetByIdAsync(Guid id) {
            return await Repository.GetByIdAsync(id);
        }
        public async Task<T> CreateEntityAsync(T entity) {
            return await Repository.CreateAsync(entity);
        }
        public async Task DeleteEntityAsync(Guid id) {
            await Repository.DeleteAsync(id);
        }
        public async Task<bool> ExistsAsync(Guid id) {
            return await Repository.ExistsAsync(id);
        }
    }
}
