namespace Indulgence.Models
{
  public class CocktailIngredient
  {       
    public int CocktailIngredientId { get; set; }
    public int IngredientId { get; set; }
    public int CocktailId { get; set; }
    public virtual Ingredient Ingredient { get; set; }
    public virtual Cocktail Cocktail { get; set; }
  }
}