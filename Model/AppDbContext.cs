using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Reflection.Emit;

namespace AddLineTest.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<RecipeItem> RecipeItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        //  only derived class can visit it
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
