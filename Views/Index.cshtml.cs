using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddLineTest.Model;

namespace AddLineTest.Views
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<RecipeItem> RecipeItem { get;set; }

        public async Task OnGetAsync()
        {
            RecipeItem = await _context.RecipeItems.ToListAsync();
        }
    }
}
