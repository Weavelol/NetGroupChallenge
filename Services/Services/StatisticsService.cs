using Services.Interfaces;
using CoreServices.Interfaces;
using Data.Interfaces;
using DTOModels;
using AutoMapper;

namespace Services.Services {
    public class StatisticsService : IStatisticsService{
        private readonly IStatisticsCoreService statisticsCoreService;
        private readonly IStoragesRepository storagesRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public StatisticsService(IStatisticsCoreService statisticsCoreService,
            IStoragesRepository storagesRepository, IMapper mapper,
            IUsersRepository usersRepository) {
            this.statisticsCoreService = statisticsCoreService;
            this.storagesRepository = storagesRepository;
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<StatisticsDTO> GetUserStatistics(string userId) {
            var storagesToAnalyze = await storagesRepository.GetStoragesOfUserAsync(userId);
            var user = await usersRepository.GetUserByIdAsync(userId);
            var statistics = statisticsCoreService.AnalyzeStorages(storagesToAnalyze.ToList(), user);
            return mapper.Map<StatisticsDTO>(statistics);
        }
    }
}
