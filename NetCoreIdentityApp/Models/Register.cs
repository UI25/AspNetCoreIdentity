using System.ComponentModel.DataAnnotations;

namespace NetCoreIdentityApp.Models
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword did not match")]
        public string? ConfirmPassword { get; set; }
    }
}
