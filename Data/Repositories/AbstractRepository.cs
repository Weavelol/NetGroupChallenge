using Data.Interfaces;
using Core.Models;
using Core.Exceptions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace Data.Repositories {
    public abstract class AbstractRepository<T> : IRepository<T> where T : AbstractModel {

        protected readonly ApplicationDbContext Context;

        protected AbstractRepository(ApplicationDbContext context) {
            Context = context;
        }

        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);

        public async Task<T> GetByIdAsync(Guid id) {
            var items = await GetByConditionAsync(x => x.Id == id);
            if (!items.Any()) {
                throw new EntityNotFoundException($"There is no entity with id: {id}");
            }
            return items.FirstOrDefault();
        }

        public async Task<T> CreateAsync(T item) {
            if (item is null) {
                throw new NullReferenceException("Source Item wasn't provided.");
            }
            var newItem = await Context.Set<T>().AddAsync(item);
            await SaveChangesAsync();
            return await GetByIdAsync(newItem.Entity.Id);
        }
        
        public async Task<T> UpdateAsync(T item) {
            /*
             * if (item is null) {
                throw new SourceEntityNullException("Source Item wasn't provided.");
            }
            if (!await ExistsAsync(item.Id)) {
                throw new EntityNotFoundException($"There is no entity with id: {item.Id}");
            }
            var updatedItem = Context.Set<T>().Update(item);
            await SaveChangesAsync();
            return await GetByIdAsync(updatedItem.Entity.Id);

             * 
             */
            throw new NotImplementedException();
        }
        public async Task DeleteAsync(Guid id) {
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
