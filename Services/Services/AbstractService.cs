using Services.Interfaces;
using Data.Interfaces;
using Core.Models;
using AutoMapper;

namespace Services.Services {
    public abstract class AbstractService<TModel, TDTO, TCreateDTO> 
            : IService<TDTO, TCreateDTO> where TModel : AbstractModel{
        protected readonly IRepository<TModel> Repository;
        protected readonly IMapper Mapper;

        public AbstractService(IRepository<TModel> repository, IMapper mapper) {
            Repository = repository;
            Mapper = mapper;
        }

        public abstract Task<IEnumerable<TDTO>> GetAllAsync();
        public async Task DeleteAsync(Guid id) {
            await Repository.DeleteAsync(id);
        }

        public async Task<TDTO> GetByIdAsync(Guid id) {
            var entity = await Repository.GetByIdAsync(id);
            return Mapper.Map<TDTO>(entity);
        }

        public async Task<TDTO> CreateAsync(TCreateDTO entityToCreate) {
            var createdEntity = await Repository.CreateAsync(Mapper.Map<TModel>(entityToCreate));
            return Mapper.Map<TDTO>(createdEntity);
        }
    }
}
