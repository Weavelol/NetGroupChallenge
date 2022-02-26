using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Core.Exceptions;

namespace Data.Repositories {
    /// <inheritdoc/>
    public class StoragesRepository : AbstractRepository<Storage>, IStoragesRepository {

        public StoragesRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor) { }

        /// <inheritdoc/>
        public override async Task<IEnumerable<Storage>> GetByConditionAsync(Expression<Func<Storage, bool>> expression) {
            return await Context.Set<Storage>()
                .Where(x => x.OwnerId == UserId)
                .Where(expression)
                .AsNoTracking()
                .Include(x => x.ParentStorage)
                .Include(x => x.NestedStorages)
                .Include(x => x.NestedItems)
                .ToListAsync();
        }


        protected override void UniqueCreatePart(Storage item) {
            item.OwnerId = UserId;
        }

        /// <inheritdoc/>
        public override async Task<Storage> GetByIdAsync(Guid id) {
            if(UserId is null) {
                throw new NotAuthorizedException(Properties.Resources.NotAuthorizedException);
            }

            if (id == Guid.Empty) {
                var nested = await GetNestedStoragesAsync(Guid.Empty);
                var dummyStorage = new Storage {
                    Id = Guid.Empty,
                    Title = "DummyStorage",
                    NestedStorages = nested.ToList(),
                    OwnerId = UserId,
                    StoragePath = string.Empty
                };
                return dummyStorage;
            }
            var items = await GetByConditionAsync(x => x.Id == id);
            if (items is null || !items.Any()) {
                throw new EntityNotFoundException(Properties.Resources.NotFoundExceptionMessage);
            }
            return items.FirstOrDefault();
        }

        /// <inheritdoc/>
        public override async Task DeleteAsync(Guid id) {
            var item = await GetByIdAsync(id);
            if (item.NestedStorages.Any() || item.NestedItems.Any()) {
                throw new CascadeDeleteException(Properties.Resources.CascadeDeleteException);
            }

            Context.Set<Storage>().Remove(item);
            await SaveChangesAsync();
        }

        private Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentStorageId) {
            if (parentStorageId == Guid.Empty) {
                return GetByConditionAsync(x => x.ParentStorageId == null);
            }
            return GetByConditionAsync(x => x.ParentStorageId == parentStorageId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Storage>> GetStoragesOfUserAsync(string UserId) {
            return await Context.Set<Storage>()
                .Where(x => x.OwnerId == UserId)
                .AsNoTracking()
                .Include(x => x.ParentStorage)
                .Include(x => x.NestedStorages)
                .Include(x => x.NestedItems)
                .ToListAsync();
        }
    }
}
