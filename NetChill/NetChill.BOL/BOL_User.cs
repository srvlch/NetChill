using System.ComponentModel.DataAnnotations;

namespace NetChill.BOL
{
    public class BOL_User
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}
