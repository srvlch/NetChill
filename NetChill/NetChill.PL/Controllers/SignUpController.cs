using System.Web.Http;
using NetChill.BLL;
using NetChill.BOL;
using NetChill.PL.Controllers.JWT_Token_Manager;

namespace NetChill.Controllers
{
    //controller to Signup user
    public class SignUpController : ApiController
    {
        ISignUp signUp = null;
        SignUpController()
        {
            signUp = new BLL_SignUp();
        }

        // POST api/values
        [Route("api/signup")]
        public IHttpActionResult Post([FromBody]BOL_SignUser user)
        {
           
            if (ModelState.IsValid)
            {
                var signUpUser = this.signUp.SignUpUser(user);
                if (signUpUser == null) return BadRequest(user.Email + " is already exists. Please Login.");

                string newToken = JWTTokenManager.GenerateToken(signUpUser.Email);
                
                return Ok(new
                {
                    token = newToken,
                    signUpUser.IsAdmin
                });
            }
                return BadRequest("Passwords didn't match. Try again.");
            
        }
        
    }
}
