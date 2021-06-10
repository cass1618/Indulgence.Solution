namespace Indulgence.Models
{
  public class CocktailStep
  {       
    public int CocktailStepId { get; set; }
    public int StepId { get; set; }
    public int CocktailId { get; set; }
    public virtual Step Step { get; set; }
    public virtual Cocktail Cocktail { get; set; }
  }
}