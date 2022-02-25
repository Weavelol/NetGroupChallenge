using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTOModels;
using Services.Interfaces;

namespace NetGroupChallengeBlazor.Server.Controllers {
    
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase {
        private readonly IStoragesService storagesService;

        public StatisticsController(IStoragesService storagesService) {
            this.storagesService = storagesService;
        }

        // GET: api/statistics
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<StorageDTO>>> GetAllAsync(string userId) {
            var storages = await storagesService.GetStoragesOfUserAsync(userId);
            return Ok(storages);
        }
    }
}
