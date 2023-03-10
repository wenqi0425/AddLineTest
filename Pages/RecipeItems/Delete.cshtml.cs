using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddLineTest.Model;

namespace AddLineTest.Pages.RecipeItems
{
    public class DeleteModel : PageModel
    {
        private readonly AddLineTest.Model.AppDbContext _context;

        public DeleteModel(AddLineTest.Model.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeItem RecipeItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeItem = await _context.RecipeItems.FirstOrDefaultAsync(m => m.Id == id);

            if (RecipeItem == null)
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

            RecipeItem = await _context.RecipeItems.FindAsync(id);

            if (RecipeItem != null)
            {
                _context.RecipeItems.Remove(RecipeItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
