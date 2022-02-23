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
    public class ImagesRepository : AbstractRepository<ItemImage>, IImagesRepository {
        public ImagesRepository(ApplicationDbContext context) : base(context) { }

        public override Task<IEnumerable<ItemImage>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ItemImage>> GetByConditionAsync(Expression<Func<ItemImage, bool>> expression) {
            throw new NotImplementedException();
        }
    }
}
