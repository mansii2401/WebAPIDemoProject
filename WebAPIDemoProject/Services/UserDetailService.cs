using WebAPIDemoProject.Entities;
using WebAPIDemoProject.Entities.DTO;
using WebAPIDemoProject.Repositories;

namespace WebAPIDemoProject.Services
{
    public class UserDetailService
    {
        private readonly UserDetailRepository _userDetailRepository;

        public UserDetailService(UserDetailRepository userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }

        public Response<List<UserDetail>> GetAll()
        {
            var userDetailList = _userDetailRepository.Get();
            return new Response<List<UserDetail>>
            {
                Result = userDetailList,
                StatusMessage = "Success"
            };
        }
    }
}