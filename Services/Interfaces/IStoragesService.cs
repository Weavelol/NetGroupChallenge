using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Services.Interfaces {
    public interface IStoragesService : IService<Storage> {
        public Task<IEnumerable<Storage>> GetAllAsync();
        public Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentId);
    }
}
