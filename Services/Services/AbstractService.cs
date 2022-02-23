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
        public virtual async Task DeleteAsync(Guid id) {
            await Repository.DeleteAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id) {
            return await Repository.GetByIdAsync(id);
        }

        public async Task<T> CreateAsync(T entity) {
            return await Repository.CreateAsync(entity);
        }
    }
}
