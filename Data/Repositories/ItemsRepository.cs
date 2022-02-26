using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Core.Exceptions;
using Data.Filters;
using Data.FilterParameters;

namespace Data.Repositories {
    /// <inheritdoc/>
    public class ItemsRepository : AbstractRepository<Item>, IItemsRepository {

        public ItemsRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor) { }

        /// <inheritdoc/>
        public override async Task<IEnumerable<Item>> GetByConditionAsync(Expression<Func<Item, bool>> expression) {
            return await Context.Set<Item>()
                .Include(x => x.ParentStorage)
                .Where(x => x.ParentStorage.OwnerId == UserId)
                .Where(expression)
                .Include(x => x.Image)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Item>> GetFilteredAsync(ItemFiltersParameters filters) {
            return await GetByConditionAsync(ItemFilter.GetFilteringExpression(filters));
        }

        protected override void UniqueCreatePart(Item item) {
            item.ParentStorage = null;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Item item) {
            if (item is null) {
                throw new NullReferenceException(Properties.Resources.ItemNotProvidedExceptionMessage);
            }
            if (!await ExistsAsync(item.Id)) {
                throw new EntityNotFoundException(Properties.Resources.NotFoundExceptionMessage);
            }
            Context.Set<Item>().Update(item);
            await SaveChangesAsync();
        }
    }
}
