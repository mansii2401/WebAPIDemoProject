using System.ComponentModel.DataAnnotations;

namespace WebAPIDemoProject.Entities.DTO
{
    public class UserCredentialRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}