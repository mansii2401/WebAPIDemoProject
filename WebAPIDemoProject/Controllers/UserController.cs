using Microsoft.AspNetCore.Mvc;
using WebAPIDemoProject.Entities;
using WebAPIDemoProject.Entities.DTO;
using WebAPIDemoProject.Services;

namespace WebAPIDemoProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDetailService _userDetailService;
        private readonly ScoreListService _scoreListService;

        public UserController(UserDetailService userDetailService, ScoreListService scoreListService)
        {
            _userDetailService = userDetailService;
            _scoreListService = scoreListService;
        }

        [HttpGet("UserDetails")]
        public Response<List<UserDetail>> GetUserDetails()
        {
            return _userDetailService.GetAll();
        }
        [HttpPost("ScoreList")]
        public ActionResult<Response<ScoreList>> AddScoreDetails(ScoreList scoreList)
        {
            return _scoreListService.AddOrUpdate(scoreList);
        }
    }
}