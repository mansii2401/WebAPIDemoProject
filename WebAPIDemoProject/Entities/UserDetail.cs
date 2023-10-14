using System.Text.Json.Serialization;

namespace WebAPIDemoProject.Entities
{
    public class UserDetail : BaseCRUD
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; }

        public enum UserRole
        {
            Employee,
            Student
        }
    }
}
