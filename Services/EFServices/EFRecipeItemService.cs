using AddLineTest.Model;
using AddLineTest.Services.Interfaces;

using System.Collections.Generic;
using System.Linq;

namespace AddLineTest.Services.EFServices
{
    public class EFRecipeItemService : IRecipeItemService
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

        public IEnumerable<RecipeItem> GetAllRecipeItems()
        {
            return _context.RecipeItems;
        }

        public RecipeItem GetRecipeItemsById(int recipeItemId)
        {
            return _context.RecipeItems.FirstOrDefault(r => r.Id == recipeItemId);
        }
    }
}
