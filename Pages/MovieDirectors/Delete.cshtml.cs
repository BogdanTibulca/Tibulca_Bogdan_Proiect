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
    public class DeleteModel : PageModel
    {
        private readonly Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext _context;

        public DeleteModel(Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovieDirector MovieDirector { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieDirector = await _context.MovieDirector.FirstOrDefaultAsync(m => m.ID == id);

            if (MovieDirector == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieDirector = await _context.MovieDirector.FindAsync(id);

            if (MovieDirector != null)
            {
                _context.MovieDirector.Remove(MovieDirector);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
