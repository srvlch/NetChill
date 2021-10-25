using System.Collections.Generic;
using NetChill.BOL;

namespace NetChill.BLL
{
    public interface IRevoke
    {
        List<BOL_LoginedUser> GetUsers(string userName);

        void RevokeUser(int id);
        
    }
}
