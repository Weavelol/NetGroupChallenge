using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using DTOModels;

namespace NetGroupChallengeBlazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsersController : ControllerBase {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService) { 
            this.usersService = usersService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUserDTO>>> GetAsync() {
            var users = await usersService.GetAllAsync();
            return Ok(users);
        }
    }
}
