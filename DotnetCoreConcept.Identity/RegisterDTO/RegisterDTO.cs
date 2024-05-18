using System.ComponentModel.DataAnnotations;

namespace DotnetCoreConcept.Identity.DTO
{
    public class RegisterDTO
    {
        public string? Location { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [Required]
        [DataType(DataType.Password)]

        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string? ConfirmPassword { get; set; }


        [Required]
        [RegularExpression("^[0-9]*$",ErrorMessage = "Phone number is not valid")]
        public string? Phone { get; set;}
    }
}
