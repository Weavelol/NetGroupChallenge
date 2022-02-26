using Core.Models;

namespace CoreServices.Interfaces {
    /// <summary>
    /// StatisticsCoreService is responsible for analyzing user and his storages.
    /// </summary>
    public interface IStatisticsCoreService {
        /// <summary>
        /// Analyzing given user and his storages and return results as Statistics Object
        /// </summary>
        /// <param name="storages">List of all storages owned by user</param>
        /// <param name="user">User to be analyzed</param>
        /// <returns>Analyze results as Statistics Object</returns>
        public Statistics AnalyzeStorages(List<Storage> storages, ApplicationUser user);
    }
}
