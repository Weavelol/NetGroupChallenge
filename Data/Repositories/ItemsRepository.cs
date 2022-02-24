using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Core.Exceptions;
using Data.FilterParameters;

namespace Data.Repositories {
    public class ItemsRepository : AbstractRepository<Item>, IItemsRepository {

        public ItemsRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor) { }

        public override async Task<IEnumerable<Item>> GetByConditionAsync(Expression<Func<Item, bool>> expression) {
            return await Context.Set<Item>()
                .Include(x => x.ParentStorage)
                .Where(x => x.ParentStorage.OwnerId == UserId)
                .Where(expression)
                .Include(x => x.Image)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<IEnumerable<Item>> GetFilteredAsync(ItemFilters filters) {
            throw new NotImplementedException();
        }

        protected override void UniqueCreatePart(Item item) {
            item.ParentStorage = null;
        }

        public async Task UpdateAsync(Item item) {
            if (item is null) {
                throw new NullReferenceException("Source Item wasn't provided.");
            }
            if (!await ExistsAsync(item.Id)) {
                throw new EntityNotFoundException($"There is no entity with id: {item.Id}");
            }
            Context.Set<Item>().Update(item);
            await SaveChangesAsync();
        }
    }
}
