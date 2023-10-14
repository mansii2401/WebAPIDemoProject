using WebAPIDemoProject.Entities;

namespace WebAPIDemoProject.Repositories
{
    public class UserCredentialRepository : CRUDRepository<UserCredential>
    {
        public UserCredentialRepository() : base(nameof(UserCredential))
        {
        }

        public UserCredential GetByUserName(string userName)
        {
            return Get().Find(userCredential => userCredential.UserName == userName);
        }
    }
}