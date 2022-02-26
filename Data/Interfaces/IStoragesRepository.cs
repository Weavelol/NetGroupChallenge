using Core.Models;

namespace Data.Interfaces {
    public interface IStoragesRepository : IRepository<Storage>{
        /// <summary>
        /// Getting All storages of specified user
        /// </summary>
        /// <param name="UserId">Id of user which storages requested</param>
        /// <returns>Storages of user with specified Id</returns>
        public Task<IEnumerable<Storage>> GetStoragesOfUserAsync(string UserId);
    }
}
