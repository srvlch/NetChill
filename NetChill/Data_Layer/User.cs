using System.Collections.Generic;

namespace NetChill.DAL
{
    //User table Object
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool isRevoked { get; set; }

        public virtual ICollection<ListOfMovies> ListOfMovies { get; set; }
    }
}
