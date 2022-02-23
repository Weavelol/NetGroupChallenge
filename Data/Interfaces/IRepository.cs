using System.Linq.Expressions;
using Core.Models;

namespace Data.Interfaces {
    public interface IRepository<T> where T : AbstractModel{
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T item);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task SaveChangesAsync();
    }
}
