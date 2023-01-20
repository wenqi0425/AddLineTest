using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddLineTest.Model;
using AddLineTest.Services.EFServices;
using AddLineTest.Services.Interfaces;

namespace AddLineTest.Pages.RecipeItems
{
    public class CreateModel : PageModel
    {
        //private readonly AppDbContext _context;

        private IRecipeItemService _recipeItemService;

        public CreateModel(IRecipeItemService recipeItemService)
        {
            _recipeItemService = recipeItemService;
        }

        [BindProperty]
        public RecipeItem RecipeItem { get; set; }        

        public IActionResult OnGet(int id)
        {
            RecipeItem = _recipeItemService.GetRecipeItemsById(id);
            return Page();
        }        

        public IActionResult OnPost()
        {
            var recipeItemId = RecipeItem.Id;

            // fetching existing recipeItems
            IEnumerable<RecipeItem> recipeItemsExisted = _recipeItemService.GetAllRecipeItems();

            var newItems = new List<RecipeItem>();

            // existed item names
            var itemNameExisted = recipeItemsExisted.Select(recipe => recipe.Name).ToList();

            //if found newly created items, then saving them
            newItems.ForEach
                (item => saveNewlyAddedItem
                ( item, itemNameExisted, _recipeItemService));

            return Page();
        }

        private void saveNewlyAddedItem(RecipeItem recipeItem, List<string> itemNamesExisted, IRecipeItemService recipeItemService)
        {
            if (recipeItem != null && recipeItem.Name != null && recipeItem.Name.Length > 0 && !itemNamesExisted.Contains(recipeItem.Name))
            {
                RecipeItem item = new RecipeItem();
                item.Amount = recipeItem.Amount;
                item.Name = recipeItem.Name;
                recipeItemService.AddRecipeItem(item);
            }
        }
    }
}
