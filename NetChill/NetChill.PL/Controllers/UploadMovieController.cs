using NetChill.BLL;
using NetChill.BOL;
using NetChill.PL.Controllers.JWT_Token_Manager;
using System.Linq;
using System.Web.Http;

namespace NetChill.Controllers
{
    //controller to Upload movie (used by only admin)
    public class UploadMovieController : ApiController
    {
        IGetUser getUser = null;
        IUpload upload = null;
        UploadMovieController()
        {
            getUser = new BLL_GetUser();
            upload = new BLL_Upload();
        }

        [Route("api/uploadmovie")]
        public IHttpActionResult Post([FromBody]BOL_Movie movie)
        {
            if (ModelState.IsValid)
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
                            this.upload.BLL_UploadMovie(movie);
                            return Ok();
                        }

                    }
                }
                return BadRequest("Either Session is Expired or you are not Authorized.");
            }
            return BadRequest("Invalid Data.");
            
        }
    }
}
