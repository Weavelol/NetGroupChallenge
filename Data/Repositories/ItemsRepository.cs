using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;

namespace Data.Repositories {
    public class ItemsRepository : AbstractRepository<Item>, IItemsRepository {

        public ItemsRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor) { }

        public override Task<Item> CreateAsync(Item item) {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Item>> GetByConditionAsync(Expression<Func<Item, bool>> expression) {
            throw new NotImplementedException();
        }
    }
}
