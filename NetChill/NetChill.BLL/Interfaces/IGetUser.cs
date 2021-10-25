using NetChill.BOL;

namespace NetChill.BLL
{
    public interface IGetUser
    {
        BOL_LoginedUser ValidateUser(string email, string password);
        
        BOL_LoginedUser GetUserByEmail(string email);
       
    }
}
