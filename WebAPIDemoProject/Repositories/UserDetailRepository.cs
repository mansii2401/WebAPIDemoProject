using WebAPIDemoProject.Entities;

namespace WebAPIDemoProject.Repositories
{
    public class UserDetailRepository : CRUDRepository<UserDetail>
    {
        public UserDetailRepository() : base(nameof(UserDetail))
        {
        }
    }
}