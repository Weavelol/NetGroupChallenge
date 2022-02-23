﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Models;
using Services.Interfaces;

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
        public async Task<ActionResult<IEnumerable<Item>>> GetAsync() {
            var items = await itemsService.GetAllAsync();
            return Ok(items);
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetAsync(Guid id) {
            var item = await itemsService.GetByIdAsync(id);
            return Ok(item);
        }

        // POST api/items
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item) {
            var created = await itemsService.CreateAsync(item);
            return Created(nameof(GetAsync), created);
        }

        // PUT api/items
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Item item) {
            await itemsService.UpdateAsync(item);
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
