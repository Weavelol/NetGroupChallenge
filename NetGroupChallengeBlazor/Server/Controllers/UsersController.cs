using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTOModels;
using Services.Interfaces;

namespace NetGroupChallengeBlazor.Server.Controllers {
   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService) {
            this.usersService = usersService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUserDTO>>> GetAllAsync() {
            var users = await usersService.GetAllAsync();
            return Ok(users);
        }
    }
}
