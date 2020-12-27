namespace RecipesSystem.Models
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Ingredients { get; set; }
        public int Year { get; set; }
        public int Calories { get; set; }
    }
}
