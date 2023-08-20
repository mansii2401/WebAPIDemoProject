using WebAPIDemoProject.Entities;

namespace WebAPIDemoProject.Repositories
{
    public class TeacherRepository : CRUDRepository<Teacher>
    {
        public TeacherRepository() : base(nameof(Teacher))
        {
        }
    }
}