using DTOModels;

namespace Services.Interfaces {
    public interface IStatisticsService {
        public Task<StatisticsDTO> GetUserStatistics(string userId);
    }
}
