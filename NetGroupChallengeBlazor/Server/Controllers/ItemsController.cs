using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Models;
using Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetGroupChallengeBlazor.Server.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public ItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            this.context = context;
            this.userManager = userManager;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get() {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var items = await context.Items
                .Include(x => x.ParentStorage)
                .Where(x => x.ParentStorage.OwnerId == currentUserId)
                .Include(x => x.Image)
                .ToListAsync();
            return Ok(items);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetAsync(Guid id) {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var item = await context.Items
                .Where(x => x.Id == id)
                .Include(x => x.ParentStorage)
                .Where(x => x.ParentStorage.OwnerId == currentUserId)
                .Include(x => x.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return Ok(item);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item) {
            /*
             * Add Image to DB
             * Add Image Id to Item
             */
            var image = await context.ItemsImages.AddAsync(item.Image);

            item.Image = null;
            item.ParentStorage = null;
            item.ImageId = image.Entity.Id;
           
            await context.AddAsync(item);
            await context.SaveChangesAsync();

            return Created(nameof(GetAsync), item);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item item) {

        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var item = await context.Items
                .Where(x => x.Id == id)
                .Include(x => x.ParentStorage)
                .Where(x => x.ParentStorage.OwnerId == currentUserId)
                .Include(x => x.Image)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            context.ItemsImages.Remove(item.Image);
            context.Items.Remove(item);

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
