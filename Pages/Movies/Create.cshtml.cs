using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tibulca_Bogdan_Proiect.Data;
using Tibulca_Bogdan_Proiect.Models;

namespace Tibulca_Bogdan_Proiect.Pages.Movies
{
    public class CreateModel : MovieCategoriesPageModel
    {
        private readonly Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext _context;

        public CreateModel(Tibulca_Bogdan_Proiect.Data.Tibulca_Bogdan_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MovieDirectorID"] = new SelectList(_context.Set<MovieDirector>(), "ID", "MovieDirectorName");

            var movie = new Movie();
            movie.MovieCategories = new List<MovieCategory>();

            PopulateAssignedCategoryData(_context, movie);

            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMovie = new Movie();
            if (selectedCategories != null)
            {
                newMovie.MovieCategories = new List<MovieCategory>();

                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MovieCategory
                    {
                        CategoryID = int.Parse(cat)
                    };

                    newMovie.MovieCategories.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Movie>(newMovie, "Movie",
                 m => m.Name, m => m.MovieDirectorID, m => m.Year, m => m.PersonalReview))
            {
                _context.Movie.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, newMovie);
            return Page();
        }
    }
}
