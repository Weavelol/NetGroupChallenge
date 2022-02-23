using Core.Models;

namespace Services.Interfaces {
    public interface IItemsService : IService<Item> {
        public Task UpdateAsync(Item item);
    }
}
