using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tibulca_Bogdan_Proiect.Data;
using Tibulca_Bogdan_Proiect.Models;

namespace Tibulca_Bogdan_Proiect.Pages.MovieDirectors
{
    public class EditModel : PageModel
    {
        private readonly Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext _context;

        public EditModel(Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieDirector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieDirectorExists(MovieDirector.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieDirectorExists(int id)
        {
            return _context.MovieDirector.Any(e => e.ID == id);
        }
    }
}
