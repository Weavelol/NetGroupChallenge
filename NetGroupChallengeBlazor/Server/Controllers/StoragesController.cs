using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTOModels;
using Services.Interfaces;

namespace NetGroupChallengeBlazor.Server.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase {
        private readonly IStoragesService storagesService;

        public StoragesController(IStoragesService storagesService) {
            this.storagesService = storagesService;
        }

        // GET api/storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageDTO>>> GetAllAsync() {
            var storages = await storagesService.GetAllAsync();
            return Ok(storages);
        }

        // GET api/storages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageDTO>> GetAsync(Guid id) {
            var storage = await storagesService.GetByIdAsync(id);
            return Ok(storage);
        }

        // POST api/storages
        [HttpPost]
        public async Task<ActionResult<StorageDTO>> PostAsync([FromBody] StorageCreateDTO storage) {
            var createdStorage = await storagesService.CreateAsync(storage);
            return Created(nameof(GetAllAsync), createdStorage);
        }

        // DELETE api/storages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id) {
            await storagesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
