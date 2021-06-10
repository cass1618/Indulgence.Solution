using System.Collections.Generic;

namespace Indulgence.Models
{
  public class Step
  {
    public Step()
    {
      this.JoinEntities = new HashSet<CocktailStep>();
    }

    public int StepId { get; set; }
    public string StepName { get; set; }
    public string StepType { get; set; }

    public virtual ICollection<CocktailStep> JoinEntities { get;}
  }
}