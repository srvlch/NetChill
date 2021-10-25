using System.Linq;
using System.Web.Http;
using NetChill.BOL;
using NetChill.BLL;
using NetChill.PL.Controllers.JWT_Token_Manager;

namespace NetChill.Controllers
{
    //controller to return movie details
    public class MovieDetailsController : ApiController
    {
        IGetUser getUser = null;
        IGetMovieDetails getMovieDetails = null;
        MovieDetailsController()
        {
            getUser = new BLL_GetUser();
            getMovieDetails = new BLL_GetMovieDetails();
        }

        [Route("api/moviedetails/{id}")]
        public IHttpActionResult Get(int id)
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
                    if (user != null)
                    {
                        return Ok(this.getMovieDetails.GetDetails(id, user.Id));
                    }

                }
            }

            return BadRequest("Session Expired.Please Login or Signup again ");
        }
    }
}
