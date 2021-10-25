using System.Collections.Generic;
using NetChill.BOL;

namespace NetChill.BLL
{
    public interface IGetMovies
    {
        List<BOL_Movie> GetFeaturedMovies(int? limit);

        List<BOL_Movie> GetMyListMovies(int userId);


        List<BOL_Movie> GetUpcomingMovies(int? limit);

        List<BOL_Movie> GetNewReleaseMovies(int? limit);


        List<BOL_Movie> GetSimillarMovies(int id, string category);

        List<BOL_Movie> GetSearchMovies(string name);


        List<BOL_Movie> GetTrendingMovies();


        List<BOL_Movie> GetRecommendedMovies(int userId);
        

    }
}
