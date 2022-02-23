using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using Core.Models;
using Data.Interfaces;

namespace Services.Services {
    public class ItemsService : AbstractService<Item>, IItemsService {
        private readonly IItemsRepository itemsRepository;
        public ItemsService(IItemsRepository itemsRepository) : base(itemsRepository){
            this.itemsRepository = itemsRepository;
        }
    }
}
