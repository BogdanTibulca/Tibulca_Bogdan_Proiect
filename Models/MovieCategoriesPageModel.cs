using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tibulca_Bogdan_Proiect.Data;

namespace Tibulca_Bogdan_Proiect.Models
{
    public class MovieCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Tibulca_Bogdan_ProiectContext context, Movie movie)
        {
            var allCategories = context.Category;
            var movieCategories = new HashSet<int>(movie.MovieCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = movieCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateMovieCategories(Tibulca_Bogdan_ProiectContext context, string[] selectedCategories, Movie movieToUpdate)
        {
            if (selectedCategories == null)
            {
                movieToUpdate.MovieCategories = new List<MovieCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var movieCategories = new HashSet<int>(movieToUpdate.MovieCategories.Select(c => c.Category.ID));

            foreach(var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!movieCategories.Contains(cat.ID))
                    {
                        movieToUpdate.MovieCategories.Add(new MovieCategory
                        {
                            MovieID = movieToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (movieCategories.Contains(cat.ID))
                    {
                        MovieCategory catToRemove = movieToUpdate.MovieCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(catToRemove);
                    }
                }
            }
        }
    }
}
