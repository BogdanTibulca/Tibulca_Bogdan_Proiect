using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tibulca_Bogdan_Proiect.Models;

namespace Tibulca_Bogdan_Proiect.Data
{
    public class Tibulca_Bogdan_ProiectContext : DbContext
    {
        public Tibulca_Bogdan_ProiectContext (DbContextOptions<Tibulca_Bogdan_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Tibulca_Bogdan_Proiect.Models.Movie> Movie { get; set; }

        public DbSet<Tibulca_Bogdan_Proiect.Models.MovieDirector> MovieDirector { get; set; }

        public DbSet<Tibulca_Bogdan_Proiect.Models.Category> Category { get; set; }
    }
}
