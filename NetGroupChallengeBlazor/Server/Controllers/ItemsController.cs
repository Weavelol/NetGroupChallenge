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
            var items = new List<Item> {
                new Item {
                    Id = Guid.NewGuid(),
                    Title = "TestItem",
                    StorageId = Guid.NewGuid(),
                    ImageId = Guid.NewGuid(),
                    SerialNumber = "TestSerialNumber",
                    Classification = "TestClassification",
                    ItemOwner = "TestOwner",
                    Weight = 10,
                    Length = 10,
                    Width = 10,
                    Height = 10
                }
            };
            return Ok(items);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
