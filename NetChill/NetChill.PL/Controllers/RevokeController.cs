using System.Linq;
using System.Web.Http;
using NetChill.BOL;
using NetChill.BLL;
using NetChill.PL.Controllers.JWT_Token_Manager;

namespace NetChill.Controllers
{
    //controller to Revoke user (Used by admin only)
    public class RevokeController : ApiController
    {
        
        IGetUser getUser = null;
        IRevoke revoke = null;
        RevokeController()
        {
            getUser = new BLL_GetUser();
            revoke = new BLL_Revoke();
        }


        [Route("api/getusers/{username}")]
        public IHttpActionResult GetUsers(string username)
        {
            
            var res = Request;
            var headers = res.Headers;

            if (headers.Contains("Authorization"))
            {
                string token = headers.GetValues("Authorization").First();
                var email = JWTTokenManager.ValidateToken(token);
                if (email != null)
                {
                    BOL_LoginedUser user = this.getUser.GetUserByEmail(email);
                    if (user != null && user.IsAdmin == true)
                    {
                        if (username != null)
                        {
                            var users = this.revoke.GetUsers(username);
                            if (users.Count() != 0)
                                return Ok(users);
                        }
                        return NotFound();
                    }
                        
                }
            }

            return BadRequest("Either Session is Expired or you are not Authorized.");
            
        }

        [Route("api/usertoberevoke/{id}")]
        [HttpGet]
        public IHttpActionResult RevokeUser(int id)
        {
            var res = Request;
            var headers = res.Headers;

            if (headers.Contains("Authorization"))
            {
                string token = headers.GetValues("Authorization").First();
                var email = JWTTokenManager.ValidateToken(token);
                if (email != null)
                {
                    BOL_LoginedUser user = this.getUser.GetUserByEmail(email);
                    if (user != null && user.IsAdmin == true)
                    {
                        this.revoke.RevokeUser(id);
                        return Ok();
                    }

                }
            }

            return BadRequest("Either Session is Expired or you are not Authorized.");


        }
    }
}
