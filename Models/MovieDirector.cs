using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tibulca_Bogdan_Proiect.Models
{
    public class MovieDirector
    {
        public int ID { get; set; }
        [Display(Name = "Directed By")]
        public String MovieDirectorName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
