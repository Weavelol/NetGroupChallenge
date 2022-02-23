using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Data.Repositories {
    public class ImagesRepository : AbstractRepository<ItemImage>, IImagesRepository {
        public ImagesRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor) { }

        public override Task<ItemImage> CreateAsync(ItemImage item) {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<ItemImage>> GetAllAsync() {
            return await Context.Set<ItemImage>()
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<IEnumerable<ItemImage>> GetByConditionAsync(Expression<Func<ItemImage, bool>> expression) {
            return await Context.Set<ItemImage>()
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
