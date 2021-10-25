using System.Linq;
using NetChill.DAL;

namespace NetChill.BLL
{
    //Logic for List Movie in user List
    public class BLL_ListMovie:IListMovie
    {
        public void ListMovie(int Id, int UserId)
        {
            using (var context = new Context())
            {
                var IsListed = context.ListOfMovies.FirstOrDefault(x => x.MovieId == Id && x.UserId == UserId);
                if (IsListed == null)
                {
                    context.ListOfMovies.Add(new ListOfMovies()
                    {
                        UserId = UserId,
                        MovieId = Id
                    });
                    context.SaveChanges();
                    return;
                }
                else
                {
                    context.ListOfMovies.Remove(IsListed);
                    context.SaveChanges();
                    return;
                }
            }
        }
    }
}
