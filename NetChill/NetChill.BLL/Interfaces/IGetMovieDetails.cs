using NetChill.BOL;

namespace NetChill.BLL
{
    public interface IGetMovieDetails
    {
        BOL_MovieDetails GetDetails(int Id, int UserId);
    }
}
