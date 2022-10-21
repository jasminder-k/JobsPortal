using JobsPortal.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace JobsPortal.API.Models.DTOModels
{
    public class UserDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "maximum {1} characters allowed")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "maximum {1} characters allowed")]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }
}
