using System;
using System.Collections.Generic;

namespace NetChill.DAL
{
    //Movies table Object
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int YearOfRelease { get; set; }
        public DateTime AvailaibilityStarts { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
        public string ContentPath { get; set; }
        public string PosterPath { get; set; }
        public long Views { get; set; }

        public virtual ICollection<ListOfMovies> ListOfMovies { get; set; }
    }
}
