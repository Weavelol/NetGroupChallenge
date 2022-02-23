using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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
                .ToListAsync();
        }

        public Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentStorageId) {
            if (parentStorageId == Guid.Empty) {
                return GetByConditionAsync(x => x.ParentStorageId == null);
            }
            return GetByConditionAsync(x => x.ParentStorageId == parentStorageId);
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
    }
}
