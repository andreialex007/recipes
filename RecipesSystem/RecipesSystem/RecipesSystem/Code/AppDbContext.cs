using Microsoft.EntityFrameworkCore;
using RecipesSystem.Code.Entities;

namespace RecipesSystem.Code
{
    public class AppDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeHistory> History { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .Property(p => p.RowVersion).IsConcurrencyToken();

            base.OnModelCreating(modelBuilder);
        }
    }
}
