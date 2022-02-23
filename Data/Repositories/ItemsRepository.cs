using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;

namespace Data.Repositories {
    public class ItemsRepository : AbstractRepository<Item>, IItemsRepository {

        public ItemsRepository(ApplicationDbContext context) : base(context) { }
        public override Task<IEnumerable<Item>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Item>> GetByConditionAsync(Expression<Func<Item, bool>> expression) {
            throw new NotImplementedException();
        }
    }
}
