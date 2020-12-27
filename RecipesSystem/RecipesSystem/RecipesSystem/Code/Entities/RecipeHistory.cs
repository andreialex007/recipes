using System;

namespace RecipesSystem.Code.Entities
{
    public class RecipeHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Ingredients { get; set; }
        public int Year { get; set; }
        public int Calories { get; set; }

        public DateTime ModifyDate { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}