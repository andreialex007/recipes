using System.Collections.Generic;

namespace RecipesSystem.Code.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Ingredients { get; set; }
        public int Year { get; set; }
        public int Calories { get; set; }

        public List<RecipeHistory> RecipeHistories { get; set; }


    }
}
