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
        public async Task<ActionResult<IEnumerable<Storage>>> GetAllRootAsync() {
            var storages = await context.Storages
                    .Where(x => x.ParentStorageId == null)
                    .Where(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    .Include(x => x.ParentStorage)
                    .Include(x => x.NestedItems)
                    .ToListAsync();
            return Ok(storages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Storage>> GetByIdAsync(Guid? Id) {
            var storage = await context.Storages
                .Where(s => s.Id == Id)
                .Include(s => s.ParentStorage)
                .FirstOrDefaultAsync();
            storage.NestedStorages = await context.Storages.Where(x => x.ParentStorageId == storage.Id).ToListAsync();
            return Ok(storage);
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
            var x = await context.AddAsync(storage);

            var y = await context.SaveChangesAsync();

            return Ok();
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
