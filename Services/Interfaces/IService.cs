namespace Services.Interfaces {
    public interface IService<TDTO, TCreateDTO> {
        public Task<TDTO> GetByIdAsync(Guid Id);
        public Task<TDTO> CreateAsync(TCreateDTO entity);
        public Task DeleteAsync(Guid Id);
        public Task<IEnumerable<TDTO>> GetAllAsync();
    }
}
