using System;
using System.Collections.Generic;
using System.Linq;
using NetChill.BOL;
using NetChill.DAL;

namespace NetChill.BLL
{
    //Logic for Get Movies List 
    public class BLL_GetMovies:IGetMovies
    {
        public List<BOL_Movie> GetFeaturedMovies(int? limit)
        {
            using (var context = new Context())
            {
                var movies = context.Movies.Where(x => x.IsFeatured == true && x.AvailaibilityStarts < DateTime.Now).Select(x => new BOL_Movie()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    YearOfRelease = x.YearOfRelease,
                    AvailaibilityStarts = x.AvailaibilityStarts,
                    Description = x.Description,
                    IsFeatured = x.IsFeatured,
                    ContentPath = x.ContentPath,
                    PosterPath = x.PosterPath,
                    Views=x.Views
                }).OrderByDescending(x=>x.AvailaibilityStarts).ToList();
                if (limit != null)
                    movies = movies.Take(limit ?? 0).ToList();
                return movies;
            }
        }

        public List<BOL_Movie> GetMyListMovies(int userId)
        {
            using (var context = new Context())
            {
                var list = context.ListOfMovies.Where(x => x.UserId == userId).Select(x => x.MovieId).ToList();

                List<BOL_Movie> moviesList = new List<BOL_Movie>();

                foreach (var id in list)
                {
                    var movie = context.Movies.FirstOrDefault(x => x.Id == id && x.AvailaibilityStarts < DateTime.Now);
                    if (movie != null)
                    {
                        moviesList.Add(new BOL_Movie()
                        {
                            Id = movie.Id,
                            Name = movie.Name,
                            Category = movie.Category,
                            YearOfRelease = movie.YearOfRelease,
                            AvailaibilityStarts = movie.AvailaibilityStarts,
                            Description = movie.Description,
                            IsFeatured = movie.IsFeatured,
                            ContentPath = movie.ContentPath,
                            PosterPath = movie.PosterPath,
                            Views = movie.Views
                        });
                    }
                }

                return moviesList;
            }
        }

        public List<BOL_Movie> GetUpcomingMovies(int? limit)
        {
            using (var context = new Context())
            {
                var movies = context.Movies.Where(x => x.AvailaibilityStarts > DateTime.Now).Select(x => new BOL_Movie()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    YearOfRelease = x.YearOfRelease,
                    AvailaibilityStarts = x.AvailaibilityStarts,
                    Description = x.Description,
                    IsFeatured = x.IsFeatured,
                    ContentPath = x.ContentPath,
                    PosterPath = x.PosterPath,
                    Views = x.Views
                }).OrderBy(x=>x.AvailaibilityStarts).ToList();
                if (limit != null)
                    movies = movies.Take(limit??0).ToList();
                return movies;
            }
        }

        public List<BOL_Movie> GetNewReleaseMovies(int? limit)
        {
            using (var context = new Context())
            {
                var dateBefore30Days = DateTime.Now.AddDays(-30);
                var movies = context.Movies.Where(x => x.AvailaibilityStarts < DateTime.Now && x.AvailaibilityStarts > dateBefore30Days).Select(x => new BOL_Movie()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    YearOfRelease = x.YearOfRelease,
                    AvailaibilityStarts = x.AvailaibilityStarts,
                    Description = x.Description,
                    IsFeatured = x.IsFeatured,
                    ContentPath = x.ContentPath,
                    PosterPath = x.PosterPath,
                    Views = x.Views
                }).OrderByDescending(x=>x.AvailaibilityStarts).ToList();
                if (limit != null)
                    movies = movies.Take(limit ?? 0).ToList();
                return movies;
            }
        }


        public List<BOL_Movie> GetSimillarMovies(int id,string category)
        {
            using (var context = new Context())
            {
                var movies = context.Movies.Where(x => x.AvailaibilityStarts < DateTime.Now && x.Category==category && x.Id!=id).Select(x => new BOL_Movie()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    YearOfRelease = x.YearOfRelease,
                    AvailaibilityStarts = x.AvailaibilityStarts,
                    Description = x.Description,
                    IsFeatured = x.IsFeatured,
                    ContentPath = x.ContentPath,
                    PosterPath = x.PosterPath,
                    Views = x.Views
                }).OrderByDescending(x => x.AvailaibilityStarts).ToList();
                if (movies.Count() == 0)
                {
                    movies = GetTrendingMovies().Take(4).ToList();
                }
                return movies;
            }
        }

        public List<BOL_Movie> GetSearchMovies(string name)
        {
            using (var context = new Context())
            {
                var movies = context.Movies.Where(x => x.AvailaibilityStarts < DateTime.Now).Select(x => new BOL_Movie()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    YearOfRelease = x.YearOfRelease,
                    AvailaibilityStarts = x.AvailaibilityStarts,
                    Description = x.Description,
                    IsFeatured = x.IsFeatured,
                    ContentPath = x.ContentPath,
                    PosterPath = x.PosterPath,
                    Views = x.Views
                }).OrderByDescending(x => x.AvailaibilityStarts).ToList().FindAll(x=>x.Name.ToLower().Contains(name.ToLower()));
                return movies;
            }
        }

        public List<BOL_Movie> GetTrendingMovies()
        {
            using (var context = new Context())
            {
                var movies = context.Movies.Where(x => x.AvailaibilityStarts < DateTime.Now).Select(x => new BOL_Movie()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    YearOfRelease = x.YearOfRelease,
                    AvailaibilityStarts = x.AvailaibilityStarts,
                    Description = x.Description,
                    IsFeatured = x.IsFeatured,
                    ContentPath = x.ContentPath,
                    PosterPath = x.PosterPath,
                    Views=x.Views
                }).ToList();

                var result = movies.OrderByDescending(x => x.Views).ToList();


                return result;
            }
        }

        public List<BOL_Movie> GetRecommendedMovies(int userId)
        {
            using (var context = new Context())
            {
                var recentWatch = context.RecentWatch.FirstOrDefault(x=>x.UserId==userId);

                if (recentWatch != null)
                {
                    var recentWatchCategory = recentWatch.Category;
                    var movies = context.Movies.Where(x => x.AvailaibilityStarts < DateTime.Now && x.Category == recentWatchCategory).Select(x => new BOL_Movie()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category = x.Category,
                        YearOfRelease = x.YearOfRelease,
                        AvailaibilityStarts = x.AvailaibilityStarts,
                        Description = x.Description,
                        IsFeatured = x.IsFeatured,
                        ContentPath = x.ContentPath,
                        PosterPath = x.PosterPath,
                        Views = x.Views
                    }).OrderByDescending(x => x.AvailaibilityStarts).ToList();
                    if (movies.Count() == 0)
                    {
                        movies = GetTrendingMovies().ToList();
                    }
                    return movies;
                }

                else
                {
                   return GetTrendingMovies();
                }
                
            }
        }

    }
}
