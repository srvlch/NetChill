using System;
using System.Linq;
using NetChill.BOL;
using NetChill.DAL;

namespace NetChill.BLL
{
    //Logic for Get Movie Details
    public class BLL_GetMovieDetails:IGetMovieDetails
    {
        public BOL_MovieDetails GetDetails(int Id, int UserId)
        {
            using (var context = new Context())
            {
                var movie = context.Movies.FirstOrDefault(x => x.Id == Id && x.AvailaibilityStarts < DateTime.Now);

                if (movie != null)
                {
                    movie.Views += 1;
                    var recentWatch = context.RecentWatch.FirstOrDefault(x => x.UserId == UserId);
                    if (recentWatch != null)
                    {
                        recentWatch.Category = movie.Category;
                        context.SaveChanges();
                    }


                    else
                        context.RecentWatch.Add(new RecentWatchCategory()
                        {
                            UserId = UserId,
                            Category = movie.Category
                        });
                    context.SaveChanges();
                    var IsListed = context.ListOfMovies.FirstOrDefault(x => x.MovieId == Id && x.UserId == UserId);
                    context.SaveChanges();
                    return new BOL_MovieDetails()
                    {
                        Id = movie.Id,
                        Name = movie.Name,
                        Category = movie.Category,
                        YearOfRelease = movie.YearOfRelease,
                        AvailaibilityStarts = movie.AvailaibilityStarts,
                        Description = movie.Description,
                        PosterPath = movie.PosterPath,
                        IsFeatured = movie.IsFeatured,
                        ContentPath = movie.ContentPath,
                        Views = movie.Views,
                        IsListed = IsListed != null ? true : false
                    };
                }
                return null;
            }
        }
    }
}
