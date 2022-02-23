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
        private readonly IHttpContextAccessor httpContextAccessor;

        public StoragesRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context) {
            this.httpContextAccessor = httpContextAccessor;
        }

        public override async Task<IEnumerable<Storage>> GetByConditionAsync(Expression<Func<Storage, bool>>? expression) {
            var userId = httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await Context.Set<Storage>()
                .Where(x => x.OwnerId == userId)
                .Where(expression)
                .AsNoTracking()
                .Include(x => x.ParentStorage)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Storage>> GetAllAsync() {
            return await GetByConditionAsync(null);
        }

        public Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentStorageId) {
            if (parentStorageId == Guid.Empty) {
                return GetByConditionAsync(x => x.ParentStorageId == null);
            }
            return GetByConditionAsync(x => x.ParentStorageId == parentStorageId);
        }
    }
}
