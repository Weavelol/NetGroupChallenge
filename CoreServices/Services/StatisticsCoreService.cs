using Core.Models;
using CoreServices.Interfaces;

namespace CoreServices.Services {
    public class StatisticsCoreService : IStatisticsCoreService {

        public StatisticsModel AnalyzeStorages(List<Storage> storages, ApplicationUser user) {
            var statisticsResults = new StatisticsModel {
                StoragesAmount = storages.Count

            };

            int itemsCount = 0, maxItemsInStorage = 0;

            if (user.RegistrationDate is not null) {
                statisticsResults.RegistrationDate = (DateTime)user.RegistrationDate;
            }
            if (user.LastLoginDate is not null) {
                statisticsResults.LastLoginDate = (DateTime)user.LastLoginDate;
            }



            foreach (var storage in storages) {
                if (storage.NestedItems is not null) {
                    itemsCount += storage.NestedItems.Count;

                    if (maxItemsInStorage < storage.NestedItems.Count) {
                        maxItemsInStorage = storage.NestedItems.Count;
                    }
                }
            }

            statisticsResults.MaxItemsInStorage = maxItemsInStorage;
            statisticsResults.ItemsAmount = itemsCount;

            return statisticsResults;
        }


    }
}