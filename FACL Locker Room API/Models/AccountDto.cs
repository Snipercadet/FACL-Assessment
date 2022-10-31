using System.ComponentModel.DataAnnotations;

namespace FACL_Locker_Room_API.Models
{
    public class CreateAccountDto 
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Nationality { get; set; }
    }

    public class GetAccountDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
