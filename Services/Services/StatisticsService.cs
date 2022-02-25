using Services.Interfaces;
using CoreServices.Interfaces;
using Data.Interfaces;
using DTOModels;
using AutoMapper;

namespace Services.Services {
    public class StatisticsService : IStatisticsService{
        private readonly IStatisticsCoreService statisticsCoreService;
        private readonly IStoragesRepository storagesRepository;
        private readonly IMapper mapper;

        public StatisticsService(IStatisticsCoreService statisticsCoreService, 
            IStoragesRepository storagesRepository, IMapper mapper) { 
            this.statisticsCoreService = statisticsCoreService;
            this.storagesRepository = storagesRepository;
            this.mapper = mapper;
        }

        public async Task<StatisticsDTO> GetUserStatistics(string userId) {
            var storagesToAnalyze = await storagesRepository.GetStoragesOfUserAsync(userId);
            var statistics = statisticsCoreService.AnalyzeStorages(storagesToAnalyze.ToList());
            return mapper.Map<StatisticsDTO>(statistics);
        }
    }
}
