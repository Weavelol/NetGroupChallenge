using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using Core.Models;
using Data.Interfaces;

namespace Services.Services {
    public class ImagesService : AbstractService<ItemImage>, IImagesService {
        private readonly IImagesRepository imagesRepository;
        public ImagesService(IImagesRepository imagesRepository) : base(imagesRepository){
            this.imagesRepository = imagesRepository;
        }

        public override async Task DeleteEntityAsync(Guid id) {
            await Repository.DeleteAsync(id);
        }
    }
}
