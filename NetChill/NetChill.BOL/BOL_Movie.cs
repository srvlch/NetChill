using System;
using System.ComponentModel.DataAnnotations;

namespace NetChill.BOL
{
    public class BOL_Movie
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        [MaxLength(255)]
        public string Category { get; set; }

        [Required]
        public int YearOfRelease { get; set; }

        [Required]
        public DateTime AvailaibilityStarts { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        [MaxLength(8000)]
        public string Description { get; set; }


        public bool? IsFeatured { get; set; }

        [Required]
        public string ContentPath { get; set; }

        [Required]
        public string PosterPath { get; set; }

        public long Views { get; set; }
    }
}
