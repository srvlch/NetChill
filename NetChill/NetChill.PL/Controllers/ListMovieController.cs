using System.Linq;
using System.Web.Http;
using NetChill.BOL;
using NetChill.BLL;
using NetChill.PL.Controllers.JWT_Token_Manager;

namespace NetChill.Controllers
{
    //controller for List movie in user list
    public class ListMovieController : ApiController
    {
        private IGetUser user=null;
        private IListMovie listMovie = null;
        ListMovieController()
        {
            user = new BLL_GetUser();
            listMovie = new BLL_ListMovie();
        }

        [Route("api/listmovie/{id}")]
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
                    BOL_LoginedUser user = this.user.GetUserByEmail(email);
                    if (user != null)
                    {
                        this.listMovie.ListMovie(id, user.Id);
                        return Ok();
                    }

                }
            }

            return BadRequest("Session Expired.Please Login or Signup again ");


        }
    }
}
