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
    public class StorageController : ControllerBase {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public StorageController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            this.context = context;
            this.userManager = userManager;
        }

        // GET: api/<StorageController>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StorageController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Storage>> GetByIdAsync(Guid? Id) {
            var storage = await context.Storages
                .Where(s => s.Id == Id)
                .Include(s => s.ParentStorage)
                .FirstOrDefaultAsync();
            return Ok(storage);
        }

        // POST api/<StorageController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<StorageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<StorageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
