using Core.Models;
using CoreServices.Interfaces;

namespace CoreServices.Services {
    public class StatisticsCoreService : IStatisticsCoreService {
        public StatisticsModel AnalyzeStorages(List<Storage> storages) {
            var statisticsResults = new StatisticsModel {
                StoragesAmount = storages.Count,
            };

            

            foreach (var storage in storages) { 

            }

            return statisticsResults;
        }
    }
}
