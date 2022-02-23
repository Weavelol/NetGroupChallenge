using Services.Interfaces;
using Core.Models;
using Data.Interfaces;

namespace Services.Services {
    public class StoragesService : AbstractService<Storage>, IStoragesService {
        private readonly IStoragesRepository storagesRepository;
        public StoragesService(IStoragesRepository storagesRepository) : base(storagesRepository){
            this.storagesRepository = storagesRepository;
        }

        public override async Task<IEnumerable<Storage>> GetAllAsync() {
            return await storagesRepository.GetAllAsync();
        }
    }
}
