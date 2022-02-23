using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;

namespace Data.Repositories {
    public class ImagesRepository : AbstractRepository<ItemImage>, IImagesRepository {
        public ImagesRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor) { }

        public override Task<ItemImage> CreateAsync(ItemImage item) {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ItemImage>> GetByConditionAsync(Expression<Func<ItemImage, bool>> expression) {
            throw new NotImplementedException();
        }
    }
}
