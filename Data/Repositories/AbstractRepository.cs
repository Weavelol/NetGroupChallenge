using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;

namespace Data.Repositories {
    public class AbstractRepository<T> : IRepository<T> where T : AbstractModel {
        public Task<IEnumerable<T>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression) {
            throw new NotImplementedException();
        }
        public Task<T> GetByIdAsync(Guid id) {
            throw new NotImplementedException();
        }

        public Task<T> CreateAsync(T item) {
            throw new NotImplementedException();
        }
        public Task<T> UpdateAsync(T item) {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Guid id) {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id) {
            throw new NotImplementedException();
        }
        public Task SaveChangesAsync() {
            throw new NotImplementedException();
        }
    }
}
