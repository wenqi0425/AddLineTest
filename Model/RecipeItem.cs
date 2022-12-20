using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AddLineTest.Model
{
    public class RecipeItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ingredient Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Amount:")]
        public string Amount { get; set; }
    }
}
