namespace Services.Interfaces {
    /// <summary>
    /// Getting requests from external layer and communicates it to repository layer.
    /// </summary>
    public interface IService<TDTO, TCreateDTO> {

        /// <summary>
        /// Get entity from database by Id
        /// </summary>
        /// <param name="Id">Id of requested entity</param>
        /// <returns>database entity info as DTO</returns>
        public Task<TDTO> GetByIdAsync(Guid Id);

        /// <summary>
        /// Add new entity to database
        /// </summary>
        /// <param name="entity">data of new entity</param>
        /// <returns>database entity info as DTO</returns>
        public Task<TDTO> CreateAsync(TCreateDTO entity);

        /// <summary>
        /// Delete entity of specified Id
        /// </summary>
        /// <param name="Id">Id of entity to be deleted</param>
        public Task DeleteAsync(Guid Id);

        /// <summary>
        /// Getting All entities from database
        /// </summary>
        /// <returns>Database entities as DTO collection</returns>
        public Task<IEnumerable<TDTO>> GetAllAsync();
    }
}
