using WebAPIDemoProject.Entities;

namespace WebAPIDemoProject.Repositories
{
    public class UserCredentialRepository : CRUDRepository<UserCredential>
    {
        public UserCredentialRepository() : base(nameof(UserCredential))
        {
        }
    }
}