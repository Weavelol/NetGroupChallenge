using Services.Interfaces;
using Core.Models;
using Data.Interfaces;

namespace Services.Services {
    public class ImagesService : AbstractService<ItemImage>, IImagesService {
        public ImagesService(IImagesRepository imagesRepository) : base(imagesRepository){ }

        public override async Task DeleteEntityAsync(Guid id) {
            await Repository.DeleteAsync(id);
        }
    }
}
