using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tibulca_Bogdan_Proiect.Data;
using Tibulca_Bogdan_Proiect.Models;

namespace Tibulca_Bogdan_Proiect.Pages.MovieDirectors
{
    public class IndexModel : PageModel
    {
        private readonly Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext _context;

        public IndexModel(Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext context)
        {
            _context = context;
        }

        public IList<MovieDirector> MovieDirector { get;set; }

        public async Task OnGetAsync()
        {
            MovieDirector = await _context.MovieDirector.ToListAsync();
        }
    }
}
