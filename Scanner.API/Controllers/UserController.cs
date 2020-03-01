using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scanner.API.BusinessLogic.Logics.Users;
using Scanner.API.Model.Domains;
using System.Threading.Tasks;

namespace Scanner.API.Controllers {
    [ApiController]
    [Authorize]
    [Route("api/user")]
    public class UserController : ControllerBase {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic) {
            _userLogic = userLogic;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SignIn([FromBody]User user) {
            var result = await _userLogic.SignIn(user);

            return Ok(result);
        }
    }
}
