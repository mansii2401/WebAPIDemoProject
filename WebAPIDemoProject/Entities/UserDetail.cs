namespace WebAPIDemoProject.Entities
{
    public class UserDetail : BaseCRUD
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public UserType Type { get; set; }

        public enum UserType
        {
            Teacher,
            Student
        }
    }
}
