using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tibulca_Bogdan_Proiect.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required, StringLength(200, MinimumLength = 3)]
        [Display(Name = "Movie Title")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime Year { get; set; }
        [Range(1, 10)]
        [Display(Name = "Personal Review")]
        public int PersonalReview { get; set; }
        public int MovieDirectorID { get; set; }
        public MovieDirector MovieDirector { get; set; }
        [Display(Name = "Category")]
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
