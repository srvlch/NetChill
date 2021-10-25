using System.ComponentModel.DataAnnotations;

namespace NetChill.BOL
{
    public class BOL_SignUser
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "FullName cannot be longer than 255 characters.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters long.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
