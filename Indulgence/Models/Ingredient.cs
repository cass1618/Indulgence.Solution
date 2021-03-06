using System.Collections.Generic;

namespace Indulgence.Models
{
  public class Ingredient
  {
    public Ingredient()
    {
      this.JoinEntities = new HashSet<CocktailIngredient>();
    }

    public int IngredientId { get; set; }
    public string IngredientName { get; set; }
    public string IngredientType { get; set; }

    public virtual ICollection<CocktailIngredient> JoinEntities { get;}
  }
}