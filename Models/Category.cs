using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tibulca_Bogdan_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
