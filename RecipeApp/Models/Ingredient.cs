namespace RecipeApp.Models
{
    /// <summary>
    /// Represents an ingredient in a recipe.
    /// </summary>
    public class Ingredient
    {
        public string Name { get; set; }        // Name of the ingredient
        public double Quantity { get; set; }    // Quantity of the ingredient
        public string Unit { get; set; }        // Unit of measurement (e.g., grams, cups)
        public int Calories { get; set; }       // Number of calories in the ingredient
        public string FoodGroup { get; set; }   // Food group the ingredient belongs to (e.g., Protein, Carbohydrate)
    }
}
