using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using Core.Models;
using Data.Interfaces;

namespace Services.Services {
    public class StoragesService : AbstractService<Storage>, IStoragesService {
        private readonly IStoragesRepository storagesRepository;
        public StoragesService(IStoragesRepository storagesRepository) : base(storagesRepository){
            this.storagesRepository = storagesRepository;
        }

        public async Task<IEnumerable<Storage>> GetAllAsync() {
            return await storagesRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentId) {
            return await storagesRepository.GetNestedStoragesAsync(parentId);
        }
    }
}
