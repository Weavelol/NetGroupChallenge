using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Data;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace NetGroupChallengeBlazor.Server.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public StoragesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) { 
            this.context = context;
            this.userManager = userManager;
        }

        // GET api/storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storage>>> GetAllAsync() {
            var storages = await context.Storages
                    .Where(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    .Include(x => x.ParentStorage)
                    .ToListAsync();
            return Ok(storages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Storage>> GetStoragesOfParentStorageAsync(Guid? Id) {
            if(Id is null || Id == Guid.Empty) {
                var storages2 = await context.Storages
                    .Where(x => x.ParentStorageId == null)
                    .Where(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    .ToListAsync();
                return Ok(storages2);
            }

            var storages = await context.Storages
                    .Where(x => x.ParentStorageId == Id)
                    .Where(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    .Include(x => x.ParentStorage)
                    .ToListAsync();
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
