using AddLineTest.Model;
using System.Collections.Generic;

namespace AddLineTest.Services.Interfaces
{
    public interface IRecipeItemService
    {
        void AddRecipeItem(RecipeItem recipe);
        void DeleteRecipeItem(RecipeItem recipe);
        void EditRecipeItem(RecipeItem recipe);
        IEnumerable<RecipeItem> GetRecipeItemsByRecipeId(int recipeId);
    }
}
