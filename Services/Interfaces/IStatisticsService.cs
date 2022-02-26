using DTOModels;

namespace Services.Interfaces {
    /// <summary>
    /// Getting requests from external layer and communicates it to repository layer.
    /// </summary>
    public interface IStatisticsService {

        /// <summary>
        /// Request statistics of specified user
        /// </summary>
        /// <param name="userId">User's id</param>
        /// <returns>Users statistics data as DTO</returns>
        public Task<StatisticsDTO> GetUserStatistics(string userId);
    }
}
