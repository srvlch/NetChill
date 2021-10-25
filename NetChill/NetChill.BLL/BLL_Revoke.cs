using System.Collections.Generic;
using System.Linq;
using NetChill.BOL;
using NetChill.DAL;

namespace NetChill.BLL
{
    //Logic for Revoke user
    public class BLL_Revoke:IRevoke
    {
        public List<BOL_LoginedUser> GetUsers(string userName)
        {
            using (var context = new Context())
            {
                var users = context.Users.Where(x => x.IsAdmin == false).Select(x => new BOL_LoginedUser()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    IsAdmin = x.IsAdmin,
                    IsRevoked = x.isRevoked
                }).ToList().FindAll(x => x.FullName.ToLower().Contains(userName.ToLower()));
                return users;
            }
        }

        public void RevokeUser(int id)
        {
            using (var context = new Context())
            {
                var userToBeRevoked = context.Users.FirstOrDefault(x => x.Id == id);
                if (userToBeRevoked.isRevoked == false)
                    userToBeRevoked.isRevoked = true;

                else
                    userToBeRevoked.isRevoked = false;

                context.SaveChanges();
                return;
            }
        }
    }
}
