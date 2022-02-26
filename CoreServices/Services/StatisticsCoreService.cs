using Core.Models;
using CoreServices.Interfaces;

namespace CoreServices.Services {
    /// <inheritdoc/>
    public class StatisticsCoreService : IStatisticsCoreService {

        /// <inheritdoc/>
        public Statistics AnalyzeStorages(List<Storage> storages, ApplicationUser user) {
            var statisticsResults = new Statistics {
                StoragesAmount = storages.Count
            };

            if (TryGetDateTime(user.RegistrationDate, out var result)) {
                statisticsResults.RegistrationDate = result;
            }

            if (TryGetDateTime(user.LastLoginDate, out result)) {
                statisticsResults.LastLoginDate = result;
            }


            int itemsCount = 0, maxItemsInStorage = 0;

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

        private bool TryGetDateTime(DateTime? source, out DateTime result) {
            result = DateTime.Now;
            if(source is not null) {
                result = (DateTime)source;
                return true;
            }
            return false;
        }
    }
}