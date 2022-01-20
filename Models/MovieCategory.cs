using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tibulca_Bogdan_Proiect.Models
{
    public class MovieCategory
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
