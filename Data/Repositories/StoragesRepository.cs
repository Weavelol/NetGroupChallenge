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

        public override async Task<IEnumerable<Storage>> GetByConditionAsync(Expression<Func<Storage, bool>>? expression = null) {
            var userId = HttpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await Context.Set<Storage>()
                .Where(x => x.OwnerId == userId)
                .Where(expression)
                .AsNoTracking()
                .Include(x => x.ParentStorage)
                .Include(x => x.NestedStorages)
                .ToListAsync();
        }

        

        public override async Task<Storage> CreateAsync(Storage storage) {
            if (storage is null) {
                throw new NullReferenceException("Source Item wasn't provided.");
            }
            var userId = HttpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            storage.OwnerId = userId;

            if (storage.ParentStorageId == Guid.Empty) {
                storage.ParentStorageId = null;
                storage.StoragePath = $"{storage.Title}/";
            } else {
                var parentStorage = await GetByIdAsync((Guid)storage.ParentStorageId);
                storage.StoragePath = $"{parentStorage.StoragePath}{storage.Title}/";
            }

            var newItem = await Context.AddAsync(storage);
            await SaveChangesAsync();
            return await GetByIdAsync(newItem.Entity.Id);
        }

        public override async Task<IEnumerable<Storage>> GetAllAsync() {
            var userId = HttpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await Context.Set<Storage>()
                .Where(x => x.OwnerId == userId)
                .AsNoTracking()
                .Include(x => x.ParentStorage)
                .Include(x => x.NestedStorages)
                .ToListAsync();
        }

        public override async Task<Storage> GetByIdAsync(Guid id) {
            var userId = HttpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if(userId is null) {
                throw new NotAuthorizedException("there is no authorized user in system.");
            }

            if (id == Guid.Empty) {
                var nested = await GetNestedStoragesAsync(Guid.Empty);
                var dummyStorage = new Storage {
                    Id = Guid.Empty,
                    Title = "DummyStorage",
                    NestedStorages = nested.ToList(),
                    OwnerId = userId,
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
