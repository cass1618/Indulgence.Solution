using Microsoft.EntityFrameworkCore;

namespace Indulgence.Models
{
  public class IndulgenceContext : DbContext
  {
    public IndulgenceContext(DbContextOptions<IndulgenceContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Cocktail>()
        .HasData(
          new Cocktail { AnimalId = 1 }
        );
    }

    public DbSet<Cocktail> Animals { get; set; }
  }
}