using Core.Models;

namespace CoreServices.Interfaces {
    public interface IStatisticsCoreService {
        public StatisticsModel AnalyzeStorages(List<Storage> storages);
    }
}
