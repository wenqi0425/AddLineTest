using AddLineTest.Model;
using System.Collections.Generic;
using System.Linq;

namespace AddLineTest.Services.EFServices
{
    public class EFRecipeItemService
    {
        AppDbContext _context;
        public EFRecipeItemService(AppDbContext context)
        {
            _context = context;
        }

        public void AddRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Add(recipeItem);
            _context.SaveChanges();
        }

        public void DeleteRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Remove(recipeItem);
            _context.SaveChanges();
        }

        public void EditRecipeItem(RecipeItem recipeItem)
        {
            _context.RecipeItems.Update(recipeItem);
            _context.SaveChanges();
        }
    }
}
