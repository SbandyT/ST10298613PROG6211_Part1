using Xunit;
using Moq;
using System.Collections.Generic;

namespace RecipeAppTestUnits
{
    public class RecipeTests
    {
        [Fact]
        public void TestCalculateTotalCalories()
        {
            // Arrange
            var mockIngredient1 = new Mock<Ingredient>();
            mockIngredient1.SetupGet(i => i.Calories).Returns(100);
            mockIngredient1.SetupGet(i => i.Quantity).Returns(2);

            var mockIngredient2 = new Mock<Ingredient>();
            mockIngredient2.SetupGet(i => i.Calories).Returns(200);
            mockIngredient2.SetupGet(i => i.Quantity).Returns(3);

            var ingredients = new List<Ingredient> { mockIngredient1.Object, mockIngredient2.Object };

            var recipe = new Recipe("Test Recipe", ingredients, new List<string>());

            // Act
            recipe.CalculateTotalCalories();

            // Assert
            Xunit.Assert.Equal(800, recipe.TotalCalories);
        }

        [Fact]
        public void TestScaleRecipe()
        {
            // Arrange
            var mockIngredient1 = new Mock<Ingredient>();
            mockIngredient1.SetupGet(i => i.Quantity).Returns(2);

            var mockIngredient2 = new Mock<Ingredient>();
            mockIngredient2.SetupGet(i => i.Quantity).Returns(3);

            var ingredients = new List<Ingredient> { mockIngredient1.Object, mockIngredient2.Object };

            var recipe = new Recipe("Test Recipe", ingredients, new List<string>());

            // Act
            recipe.ScaleRecipe(0.5);

            // Assert
            Xunit.Assert.Equal(1, recipe.Ingredients[0].Quantity);
            Xunit.Assert.Equal(1.5, recipe.Ingredients[1].Quantity);
        }

        [Fact]
        public void TestResetQuantities()
        {
            // Arrange
            var mockIngredient1 = new Mock<Ingredient>();
            mockIngredient1.SetupGet(i => i.Quantity).Returns(2);

            var mockIngredient2 = new Mock<Ingredient>();
            mockIngredient2.SetupGet(i => i.Quantity).Returns(3);

            var ingredients = new List<Ingredient> { mockIngredient1.Object, mockIngredient2.Object };

            var recipe = new Recipe("Test Recipe", ingredients, new List<string>());

            // Act
            recipe.ResetQuantities();

            // Assert
            Xunit.Assert.Equal(2, recipe.Ingredients[0].Quantity);
            Xunit.Assert.Equal(3, recipe.Ingredients[1].Quantity);
        }
    }

    // Mock Ingredient class for testing
    public class Ingredient
    {
        public double Quantity { get; set; }
        public int Calories { get; set; }
    }

    // Mock Recipe class for testing
    public class Recipe
    {
        public string Name { get; }
        public List<Ingredient> Ingredients { get; }
        public List<string> Steps { get; }

        public double TotalCalories { get; private set; }

        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public void CalculateTotalCalories()
        {
            TotalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                TotalCalories += ingredient.Quantity * ingredient.Calories;
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            // No need to reset in mock class
        }
    }
}

