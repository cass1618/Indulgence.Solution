using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Indulgence.Models;
using System.Linq;
using System;

namespace Indulgence.Models
{
    public class Cocktail
    {
        public Cocktail()
        {
            this.JoinEntities = new HashSet<CocktailIngredient>();
        }
        public int CocktailId { get; set; }
        [Required]
        [StringLength(50)]
        public string DrinkName { get; set; }
        // public List<Step> Steps { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }

        public virtual ICollection<CocktailIngredient> JoinEntities { get; }
    }
}