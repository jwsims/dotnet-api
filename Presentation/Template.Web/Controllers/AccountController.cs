using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Template.Web.Controllers
{
    [Authorize]
    [Route("api/account")]
    public class AccountController : BaseController
    {
        [HttpGet(Name = nameof(GetUser))]
        public async Task<IActionResult> GetUser()
        {
            return this.NoContent();
        }
    }
}