using System.ComponentModel.DataAnnotations;

namespace NetChill.BOL
{
    public class BOL_LoginUser
    {
        [Required]
        [EmailAddress]
        public string email;
        [Required]
        public string password;
    }
}
