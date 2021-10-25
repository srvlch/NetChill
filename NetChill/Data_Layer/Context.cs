using Data_Layer.Seeding;
using System.Data.Entity;

namespace NetChill.DAL
{
    //Context Class
    public class Context : DbContext
    {

        public Context()
            : base("name=NetChillConnectionString")
        {
            //Seeding if model changes
            Database.SetInitializer(new Seeding());
        }

        public virtual DbSet<ListOfMovies> ListOfMovies { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RecentWatchCategory> RecentWatch { get; set; }

    }
}
