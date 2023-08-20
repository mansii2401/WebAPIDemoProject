using WebAPIDemoProject.Entities;

namespace WebAPIDemoProject.Repositories
{
    public class StudentRepository : CRUDRepository<Student>
    {
        public StudentRepository() : base(nameof(Student))
        {
        }
    }
}