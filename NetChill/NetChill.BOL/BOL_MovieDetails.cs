using System;
using System.ComponentModel.DataAnnotations;

namespace NetChill.BOL
{
    public class BOL_MovieDetails
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int YearOfRelease { get; set; }
        [Required]
        public DateTime AvailaibilityStarts { get; set; }
        [Required]
        public string Description { get; set; }

        public bool? IsFeatured { get; set; }
        [Required]
        public string ContentPath { get; set; }
        [Required]
        public string PosterPath { get; set; }

        public long Views { get; set; }
        public bool IsListed { get; set; }
    }
}
