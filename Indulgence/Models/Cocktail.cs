using System.ComponentModel.DataAnnotations;

namespace Indulgence.Models
{
    public class Cocktail
    {
        public int AnimalId { get; set; }
        [Required]
        [StringLength(50)]
        public string DrinkName { get; set; }
        [Required]
        public List<string> Instructions { get; set; }
        [Required]
        public List<Ingredients> Ingredients { get; set; }
    }
}