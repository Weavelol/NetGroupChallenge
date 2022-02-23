using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces {
    public interface IStoragesRepository : IRepository<Storage>{
        public Task<IEnumerable<Storage>> GetNestedStoragesAsync(Guid? parentStorageId);
    }
}
