using NetChill.BOL;

namespace NetChill.BLL
{
    public interface ISignUp
    {
        BOL_LoginedUser SignUpUser(BOL_SignUser user);
        
    }
}
