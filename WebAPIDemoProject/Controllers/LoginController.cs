using Microsoft.AspNetCore.Mvc;
using WebAPIDemoProject.Entities;
using WebAPIDemoProject.Entities.DTO;
using WebAPIDemoProject.Services;

namespace WebAPIDemoProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserCredentialService _userCredentialService;

        public LoginController(UserCredentialService userloginservice)
        {
            _userCredentialService = userloginservice;
        }

        [HttpPost]
        public ActionResult<Response<UserDetail>> LoginUser(UserCredentialRequest userCredentialRequest)
        {
            return _userCredentialService.Login(userCredentialRequest);
        }
    }
}