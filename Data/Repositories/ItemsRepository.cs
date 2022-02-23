﻿using Data.Interfaces;
using Core.Models;
using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Core.Exceptions;

namespace Data.Repositories {
    public class ItemsRepository : AbstractRepository<Item>, IItemsRepository {

        public ItemsRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor) { }

        public override async Task<IEnumerable<Item>> GetByConditionAsync(Expression<Func<Item, bool>> expression) {
            var userId = HttpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await Context.Set<Item>()
                .Include(x => x.ParentStorage)
                .Where(x => x.ParentStorage.OwnerId == userId)
                .Where(expression)
                .Include(x => x.Image)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Item> CreateAsync(Item item) {
            item.ParentStorage = null;
            var created = await Context.AddAsync(item);
            await SaveChangesAsync();
            return await GetByIdAsync(created.Entity.Id);
        }


        public async Task UpdateAsync(Item item) {
            if (item is null) {
                throw new NullReferenceException("Source Item wasn't provided.");
            }
            if (!await ExistsAsync(item.Id)) {
                throw new EntityNotFoundException($"There is no entity with id: {item.Id}");
            }
            Context.Set<Item>().Update(item);
            await SaveChangesAsync();
        }

        public override async Task DeleteAsync(Guid id) {
            var item = await GetByIdAsync(id);
            Context.Set<ItemImage>().Remove(item.Image);
            Context.Set<Item>().Remove(item);
            await SaveChangesAsync();
        }
    }
}
