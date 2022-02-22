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

        // GET: api/storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storage>>> GetAsync() {
            var storages = await context.Storages.ToListAsync();
            return Ok(storages);
        }

        // GET api/storages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Storage>>> GetAllNestedAsync(Guid? id) {
            IEnumerable<Storage> storages;

            if(id == Guid.Empty || id is null) {
                storages = await context.Storages
                    .Where(x => x.ParentStorageId == null)
                    .Where(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    .Include(x => x.ParentStorage)
                    .ToListAsync();
            } 
            else {
                storages = await context.Storages
                    .Where(s => s.ParentStorageId == id)
                    .Where(x => x.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                    .Include(s => s.ParentStorage)
                    .ToListAsync();
            }
            return Ok(storages);
        }

        [HttpGet]
        public async Task<ActionResult<Storage>> GetByIdAsync([FromBody] Guid Id) {
            var storage = await context.Storages
                .Where(s => s.Id == Id)
                .Include(s => s.ParentStorage)
                .FirstOrDefaultAsync();
            return Ok(storage);
        }

        // POST api/storages
        [HttpPost]
        public async Task<ActionResult<Storage>> PostAsync([FromBody] Storage storage) {
            storage.OwnerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (storage.ParentStorageId == Guid.Empty) {
                storage.ParentStorageId = null;
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
