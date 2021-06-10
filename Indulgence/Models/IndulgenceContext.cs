using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Indulgence.Models
{
  public class IndulgenceContext : DbContext
  {
    public DbSet<Step> Steps { get; set; }
    public DbSet<Cocktail> Cocktails { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<CocktailStep> CocktailStep { get; set; }
    public DbSet<CocktailIngredient> CocktailIngredient { get; set; }

    public IndulgenceContext(DbContextOptions<IndulgenceContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Cocktail>()
        .HasData(
          new Cocktail { CocktailId = 1, DrinkName = "James Bond Vesper" },
          new Cocktail { CocktailId = 2, DrinkName = "Black Manhattan" },
          new Cocktail { CocktailId = 3, DrinkName = "White Gummy Bear" }
        );  
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}