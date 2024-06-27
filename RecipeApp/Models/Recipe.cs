using System.Collections.Generic;

namespace RecipeApp.Models
{
    public class Recipe
    {
        // Property for recipe name
        public string Name { get; set; }

        // List of ingredients for the recipe
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        // List of steps for the recipe
        public List<string> Steps { get; set; } = new List<string>();

        // Property to calculate the total calories of the recipe
        public int TotalCalories
        {
            get
            {
                int total = 0;
                foreach (var ingredient in Ingredients)
                {
                    total += ingredient.Calories;
                }
                return total;
            }
        }
    }
}
