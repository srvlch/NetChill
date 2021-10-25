namespace NetChill.DAL
{
    //ListOfMovies table Object
    public class ListOfMovies
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }

    }
}
