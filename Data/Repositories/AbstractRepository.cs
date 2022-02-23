using Data.Interfaces;
using Core.Models;
using Core.Exceptions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Data.Repositories {
    public abstract class AbstractRepository<T> : IRepository<T> where T : AbstractModel {

        protected readonly ApplicationDbContext Context;
        protected readonly IHttpContextAccessor HttpContextAccessor;

        protected AbstractRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) {
            Context = context;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            return await GetByConditionAsync(x => true);
        }
        public abstract Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        public abstract Task<T> CreateAsync(T item);

        public virtual async Task<T> GetByIdAsync(Guid id) {
            var items = await GetByConditionAsync(x => x.Id == id);
            if (items is null || !items.Any()) {
                throw new EntityNotFoundException($"There is no entity with id: {id}");
            }
            return items.FirstOrDefault();
        }
        
        public virtual async Task DeleteAsync(Guid id) {
            var item = await GetByIdAsync(id);
            Context.Set<T>().Remove(item);
            await SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id) {
            return await Context.Set<T>().AnyAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync() {
            await Context.SaveChangesAsync();
        }
    }
}
