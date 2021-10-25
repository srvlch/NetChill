using System.Linq;
using System.Web.Http;
using NetChill.BOL;
using NetChill.BLL;
using NetChill.PL.Controllers.JWT_Token_Manager;

namespace NetChill.Controllers
{
    //controller to return List of movies according to URL.
    [RoutePrefix("api")]
    public class MoviesController : ApiController
    {
        IGetMovies getMovieDetails = null;
        IGetUser getUser = null;
        MoviesController()
        {
            getMovieDetails = new BLL_GetMovies();
            getUser = new BLL_GetUser();
        }


        [Route("featuredmovies")]
        public IHttpActionResult GetFeaturedMovies()
        {
            var res = Request;
            var headers = res.Headers;

            if (headers.Contains("Authorization"))
            {
                string token = headers.GetValues("Authorization").First();
                var email = JWTTokenManager.ValidateToken(token);
                if (email != null)
                {
                    return Ok(this.getMovieDetails.GetFeaturedMovies(null));
                }
            }
            return BadRequest("Session Expired.Please Login or Signup again ");
            
        }

        [Route("featuredmovies/{limit}")]
        public IHttpActionResult GetFeaturedMovies(int limit)
        {
            return Ok(this.getMovieDetails.GetFeaturedMovies(limit));
        }




        [Route("mylistmovies")]
        public IHttpActionResult GetListMovies()
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
                    if(user!=null)
                        return Ok(this.getMovieDetails.GetMyListMovies(user.Id));
                }
            }

            return BadRequest("Session Expired.Please Login or Signup again ");
        }

       
 
        [Route("upcomingmovies")]
        public IHttpActionResult GetUpcomingMovies()
        {
            var res = Request;
            var headers = res.Headers;

            if (headers.Contains("Authorization"))
            {
                string token = headers.GetValues("Authorization").First();
                var email = JWTTokenManager.ValidateToken(token);
                if (email != null)
                {
                    return Ok(this.getMovieDetails.GetUpcomingMovies(null));
                }
            }

            return BadRequest("Session Expired.Please Login or Signup again ");

        }

        [Route("upcomingmovies/{limit}")]
        public IHttpActionResult GetUpcomingMovies(int limit)
        {
            return Ok(this.getMovieDetails.GetUpcomingMovies(limit));
        }



        [Route("newreleasemovies")]
        public IHttpActionResult GetNewReleaseMovies()
        {
            var res = Request;
            var headers = res.Headers;

            if (headers.Contains("Authorization"))
            {
                string token = headers.GetValues("Authorization").First();
                var email = JWTTokenManager.ValidateToken(token);
                if (email != null)
                {
                    return Ok(this.getMovieDetails.GetNewReleaseMovies(null));
                }
            }
            return BadRequest("Session Expired.Please Login or Signup again ");
        }

        [Route("newreleasemovies/{limit}")]
        public IHttpActionResult GetNewReleaseMovies(int limit)
        {
            return Ok(this.getMovieDetails.GetNewReleaseMovies(limit));
        }


        [Route("similarmovies/{id}/{category}")]
        public IHttpActionResult GetSimilarMovies(int id,string category)
        {
            var res = Request;
            var headers = res.Headers;

            if (headers.Contains("Authorization"))
            {
                string token = headers.GetValues("Authorization").First();
                var email = JWTTokenManager.ValidateToken(token);
                if (email != null)
                {
                    return Ok(this.getMovieDetails.GetSimillarMovies(id,category));
                }
            }
            return BadRequest("Session Expired.Please Login or Signup again ");
        }

        [Route("searchmovies/{name}")]
        public IHttpActionResult GetSearchMovies(string name)
        {
            var res = Request;
            var headers = res.Headers;

            if (headers.Contains("Authorization"))
            {
                string token = headers.GetValues("Authorization").First();
                var email = JWTTokenManager.ValidateToken(token);
                if (email != null)
                {
                    return Ok(this.getMovieDetails.GetSearchMovies(name));
                }
            }
            return BadRequest("Session Expired.Please Login or Signup again ");

        }

        [Route("trendingmovies")]
        public IHttpActionResult GetTrendingMovies()
        {
            var res = Request;
            var headers = res.Headers;

            if (headers.Contains("Authorization"))
            {
                string token = headers.GetValues("Authorization").First();
                var email = JWTTokenManager.ValidateToken(token);
                if (email != null)
                {
                    return Ok(this.getMovieDetails.GetTrendingMovies());
                }
            }
            return BadRequest("Session Expired.Please Login or Signup again ");
        }

        [Route("recommendedmovies")]
        public IHttpActionResult GetRecommendedMovies()
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
                        return Ok(this.getMovieDetails.GetRecommendedMovies(user.Id));
                    }

                }
            }

            return BadRequest("Session Expired.Please Login or Signup again ");
        }

    }
}
