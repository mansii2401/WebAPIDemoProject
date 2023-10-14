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

        public Response<UserDetail> GetById(int id)
        {
            var userDetail = _userDetailRepository.Get(id);
            if (userDetail == null)
            {
                return new Response<UserDetail>
                {
                    StatusMessage = "User not found"
                };
            }

            return new Response<UserDetail>
            {
                Result = userDetail,
                StatusMessage = "Success"
            };
        }
    }
}