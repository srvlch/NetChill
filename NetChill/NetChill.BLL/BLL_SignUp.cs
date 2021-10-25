using NetChill.BOL;
using NetChill.DAL;
using System.Linq;

namespace NetChill.BLL
{
    //Logic for Sign Up User
    public class BLL_SignUp: ISignUp
    {
        public BOL_LoginedUser SignUpUser(BOL_SignUser user)
        {
            user.Email = user.Email.ToLower();
            using (var context = new Context())
            {
                var chkUser = context.Users.FirstOrDefault(x=>x.Email==user.Email);
                if (chkUser == null)
                {
                    User newUser = new User() { FullName = user.FullName, Email = user.Email, Password = user.Password, IsAdmin = false, isRevoked = false };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    return new BOL_LoginedUser()
                    {
                        Id = newUser.Id,
                        Email = newUser.Email,
                        FullName = newUser.FullName,
                        IsAdmin = newUser.IsAdmin,
                        IsRevoked = newUser.isRevoked
                    };
                }
                return null;
            }
        }
    }
}
