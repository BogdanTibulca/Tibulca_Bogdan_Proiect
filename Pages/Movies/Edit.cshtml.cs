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

namespace Tibulca_Bogdan_Proiect.Pages.Movies
{
    public class EditModel : MovieCategoriesPageModel
    {
        private readonly Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext _context;

        public EditModel(Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie
                .Include(m => m.MovieDirector)
                .Include(m => m.MovieCategories).ThenInclude(m => m.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Movie);

            ViewData["MovieDirectorID"] = new SelectList(_context.Set<MovieDirector>(), "ID", "MovieDirectorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieToUpdate = await _context.Movie
                .Include(m => m.MovieDirector)
                .Include(m => m.MovieCategories).ThenInclude(m => m.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Movie>(movieToUpdate, "Movie",
                m => m.Name, m => m.MovieDirectorID, m => m.Year, m => m.PersonalReview))
            {
                UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateMovieCategories(_context, selectedCategories, movieToUpdate);
            PopulateAssignedCategoryData(_context, movieToUpdate);
            return Page();
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
