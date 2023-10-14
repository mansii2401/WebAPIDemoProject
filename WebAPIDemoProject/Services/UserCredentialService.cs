using WebAPIDemoProject.Entities;
using WebAPIDemoProject.Entities.DTO;
using WebAPIDemoProject.Repositories;

namespace WebAPIDemoProject.Services
{
    public class UserCredentialService
    {
        private readonly UserDetailRepository _userDetailRepository;
        private readonly UserCredentialRepository _userCredentialRepository;

        public UserCredentialService(UserDetailRepository userDetailRepository, UserCredentialRepository userCredentialRepository)
        {
            _userDetailRepository = userDetailRepository;
            _userCredentialRepository = userCredentialRepository;
        }

        public Response<UserDetail> Login(UserCredentialRequest userCredentialRequest)
        {
            var userCredential = _userCredentialRepository.GetByUserName(userCredentialRequest.UserName);
            if (userCredential == null)
            {
                return new Response<UserDetail>
                {
                    StatusMessage = "User not found"
                };
            }
            else if (userCredential.Password != userCredentialRequest.Password)
            {
                return new Response<UserDetail>
                {
                    StatusMessage = "Invalid password"
                };
            }
            else
            {
                var userDetail = _userDetailRepository.Get(userCredential.UserId);
                return new Response<UserDetail>
                {
                    Result = userDetail,
                    StatusMessage = "Login successful"
                };
            }
        }
    }
}