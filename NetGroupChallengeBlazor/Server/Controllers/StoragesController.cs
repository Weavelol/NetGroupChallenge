using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Data;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace NetGroupChallengeBlazor.Server.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase {
        private ApplicationDbContext context;
        private readonly IStoragesService storagesService;

        public StoragesController(ApplicationDbContext context, IStoragesService storagesService) { 
            this.context = context;
            this.storagesService = storagesService;
        }

        // GET api/storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storage>>> GetAllAsync() {
            var storages = await storagesService.GetAllAsync();
            return Ok(storages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Storage>> GetStoragesOfParentStorageAsync(Guid? id) {
            var storages = await storagesService.GetNestedStoragesAsync(id);
            return Ok(storages);
        }

        // POST api/storages
        [HttpPost]
        public async Task<ActionResult<Storage>> PostAsync([FromBody] Storage storage) {
            storage.OwnerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (storage.ParentStorageId == Guid.Empty) {
                storage.ParentStorageId = null;
                storage.StoragePath = $"{storage.Title}/";
            } else {
                storage.ParentStorage = await context.Storages.Where(x => x.Id == storage.ParentStorageId).FirstOrDefaultAsync();
                storage.StoragePath = $"{storage.ParentStorage.StoragePath}{storage.Title}/";
            }
            
            await context.AddAsync(storage);
            await context.SaveChangesAsync();

            return Created(nameof(GetAllAsync), storage);
        }

        // DELETE api/storages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id) {
            var storageToDelete = context.Storages.Where(s => s.Id == id).FirstOrDefault();
            if (storageToDelete != null) {
                context.Storages.Remove(storageToDelete);
            }
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
