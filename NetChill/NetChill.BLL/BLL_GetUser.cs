using NetChill.BOL;
using NetChill.DAL;
using System.Linq;

namespace NetChill.BLL
{
    //Logic for Get User Details ang Login
    public class BLL_GetUser:IGetUser
    {
        public BOL_LoginedUser ValidateUser(string email, string password)
        {
            email = email.ToLower();
            using (var context = new Context())
            {
                User user = context.Users.SingleOrDefault(x => x.Email == email);
                if (user != null && user.Password==password)
                {
                    return new BOL_LoginedUser()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FullName = user.FullName,
                        IsAdmin = user.IsAdmin,
                        IsRevoked = user.isRevoked
                    };
                }
                
                return null;
                
            }
        }

        public BOL_LoginedUser GetUserByEmail(string email)
        {
            email = email.ToLower();
            using (var context = new Context())
            {
                User user = context.Users.SingleOrDefault(x => x.Email == email);
                if (user != null)
                {
                    return new BOL_LoginedUser()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FullName = user.FullName,
                        IsAdmin = user.IsAdmin,
                        IsRevoked = user.isRevoked
                    };
                }

                return null;

            }
        }


    }
}
