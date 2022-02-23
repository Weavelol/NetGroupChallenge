using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Core.Exceptions;

namespace Data.Repositories {
    public class StoragesRepository : AbstractRepository<Storage>, IStoragesRepository {

        public StoragesRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor) { }

        public override async Task<IEnumerable<Storage>> GetByConditionAsync(Expression<Func<Storage, bool>> expression) {
            return await Context.Set<Storage>()
                .Where(x => x.OwnerId == UserId)
                .Where(expression)
                .AsNoTracking()
                .Include(x => x.ParentStorage)
                .Include(x => x.NestedStorages)
                .ToListAsync();
        }


        protected override void UniqueCreatePart(Storage item) {
            item.OwnerId = UserId;
            SetStoragePath(item);
        }
        private void SetStoragePath(Storage storage) {
            if (storage.ParentStorageId == Guid.Empty) {
                storage.ParentStorageId = null;
                storage.StoragePath = $"{storage.Title}/";
            } else {
                storage.StoragePath = $"{storage.ParentStorage.StoragePath}{storage.Title}/";
            }
            //setting parent storage to null to avoid cascade creation.
            storage.ParentStorage = null;
        }
        

        public override async Task<Storage> GetByIdAsync(Guid id) {
            if(UserId is null) {
                throw new NotAuthorizedException("there is no authorized user in system.");
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
                throw new EntityNotFoundException($"There is no entity with id: {id}");
            }
            return items.FirstOrDefault();
        }

        private Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentStorageId) {
            if (parentStorageId == Guid.Empty) {
                return GetByConditionAsync(x => x.ParentStorageId == null);
            }
            return GetByConditionAsync(x => x.ParentStorageId == parentStorageId);
        }
    }
}
