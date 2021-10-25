using NetChill.BOL;
using NetChill.DAL;

namespace NetChill.BLL
{
    public class BLL_Upload:IUpload
    {
        //Logic for Upload movie
        public void BLL_UploadMovie(BOL_Movie movie)
        {
            using (var context = new Context())
            {
                context.Movies.Add(new Movie()
                {
                    Name = movie.Name,
                    Category = movie.Category,
                    YearOfRelease = movie.YearOfRelease,
                    AvailaibilityStarts = movie.AvailaibilityStarts,
                    Description = movie.Description,
                    IsFeatured = movie.IsFeatured ?? false,
                    PosterPath = movie.PosterPath,
                    ContentPath = movie.ContentPath,
                    Views = 0
                });
                context.SaveChanges();
                return;
            }
        }
    }
}
