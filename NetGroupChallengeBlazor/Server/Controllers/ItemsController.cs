using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;
using DTOModels;
using Data.FilterParameters;

namespace NetGroupChallengeBlazor.Server.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase {
        private readonly IItemsService itemsService;

        public ItemsController(IItemsService itemsService) {
            this.itemsService = itemsService;
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAsync([FromQuery] ItemFiltersParameters filters) {
            var items2 = await itemsService.GetFilteredAsync(filters);
            return Ok(items2);
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetAsync(Guid id) {
            var item = await itemsService.GetByIdAsync(id);
            return Ok(item);
        }

        // POST api/items
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemCreateDTO item) {
            var created = await itemsService.CreateAsync(item);
            return Created(nameof(GetAsync), created);
        }

        // PUT api/items
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ItemCreateDTO item) {
            await itemsService.UpdateAsync(id, item);
            return NoContent();
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            await itemsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
