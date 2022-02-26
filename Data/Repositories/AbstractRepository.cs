using Data.Interfaces;
using Core.Models;
using Core.Exceptions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Data.Repositories {
    /// <inheritdoc/>
    public abstract class AbstractRepository<T> : IRepository<T> where T : AbstractModel {

        protected readonly ApplicationDbContext Context;
        protected readonly string? UserId;

        protected AbstractRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) {
            Context = context;
            UserId = httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetAllAsync() {
            return await GetByConditionAsync(x => true);
        }

        /// <inheritdoc/>
        public abstract Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);

        /// <inheritdoc/>
        public async Task<T> CreateAsync(T item) {
            if (item is null) {
                throw new NullReferenceException(Properties.Resources.ItemNotProvidedExceptionMessage);
            }
            UniqueCreatePart(item);
            var created = await Context.AddAsync(item);
            await SaveChangesAsync();
            return await GetByIdAsync(created.Entity.Id);
        }
        protected abstract void UniqueCreatePart(T item);

        /// <inheritdoc/>
        public virtual async Task<T> GetByIdAsync(Guid id) {
            var items = await GetByConditionAsync(x => x.Id == id);
            if (items is null || !items.Any()) {
                throw new EntityNotFoundException(Properties.Resources.NotFoundExceptionMessage);
            }
            return items.FirstOrDefault();
        }

        /// <inheritdoc/>
        public virtual async Task DeleteAsync(Guid id) {
            var item = await GetByIdAsync(id);
            Context.Set<T>().Remove(item);
            await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsAsync(Guid id) {
            return await Context.Set<T>().AnyAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task SaveChangesAsync() {
            await Context.SaveChangesAsync();
        }
    }
}
