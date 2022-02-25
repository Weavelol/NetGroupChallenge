using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTOModels;
using Services.Interfaces;

namespace NetGroupChallengeBlazor.Server.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService) {
            this.statisticsService = statisticsService;
        }

        // GET: api/statistics
        [HttpGet("{userId}")]
        public async Task<ActionResult<StatisticsDTO>> GetUserStatisticsAsync(string userId) {
            var statistics = await statisticsService.GetUserStatistics(userId);
            return Ok(statistics);
        }
    }
}
