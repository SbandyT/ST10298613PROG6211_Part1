using System;
using System.Collections.Generic;
using System.Linq;
// https://www.w3schools.com/cs/cs_inheritance.php
// https://www.w3schools.com/cs/cs_switch.php
// 
namespace ArrayPractice
{
    /// Khano Tshivhandekano 
    /// Std: St10298613
    /// Module: PRG6211
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                // Display menu options
                Console.WriteLine("\n1. Enter Recipe Details");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Display a Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Quantities");
                Console.WriteLine("6. Clear Recipe");
                Console.WriteLine("7. Exit");
                Console.Write("\nEnter your choice: ");

                // Error handling for choice input
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    DisplayError("Invalid input. Please enter a number between 1 and 7.");
                    continue;
                }

                // Switch case to handle user choices
                switch (choice)
                {
                    case 1:
                        EnterRecipeDetails();
                        break;
                    case 2:
                        DisplayAllRecipes();
                        break;
                    case 3:
                        DisplayARecipe();
                        break;
                    case 4:
                        ScaleRecipe();
                        break;
                    case 5:
                        ResetQuantities();
                        break;
                    case 6:
                        ConfirmClearRecipe();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        DisplayError("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // ----------------------------------------
        // Method to enter recipe details
        static void EnterRecipeDetails()
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine();
            if (string.IsNullOrEmpty(recipeName))
            {
                DisplayError("Recipe name cannot be empty.");
                return;
            }

            Recipe recipe = new Recipe(recipeName);
            recipe.CaloriesExceeded += OnCaloriesExceeded;

            Console.Write("Enter the number of ingredients: ");
            if (!int.TryParse(Console.ReadLine(), out int numOfIngredients) || numOfIngredients <= 0)
            {
                DisplayError("Invalid number of ingredients.");
                return;
            }

            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter the quantity of {name}: ");
                if (!double.TryParse(Console.ReadLine(), out double quantity) || quantity <= 0)
                {
                    DisplayError("Invalid quantity.");
                    return;
                }

                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                Console.Write($"Enter the number of calories for {name}: ");
                if (!int.TryParse(Console.ReadLine(), out int calories) || calories < 0)
                {
                    DisplayError("Invalid calories.");
                    return;
                }

                Console.Write($"Enter the food group for {name}: ");
                string foodGroup = Console.ReadLine();

                recipe.AddIngredient(name, quantity, unit, calories, foodGroup);
            }

            Console.Write("Enter the number of steps: ");
            if (!int.TryParse(Console.ReadLine(), out int numOfSteps) || numOfSteps <= 0)
            {
                DisplayError("Invalid number of steps.");
                return;
            }

            for (int i = 0; i < numOfSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                recipe.AddStep(Console.ReadLine());
            }

            recipes.Add(recipe);
        }

        // ----------------------------------------
        // Method to display all recipes
        static void DisplayAllRecipes()
        {
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            Console.WriteLine("\nList of Recipes:");
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // ----------------------------------------
        // Method to display a single recipe
        static void DisplayARecipe()
        {
            DisplayAllRecipes();
            Console.Write("\nEnter the name of the recipe you want to display: ");
            string recipeName = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.DisplayRecipe();
            }
            else
            {
                DisplayError("Recipe not found.");
            }
        }

        // ----------------------------------------
        // Method to scale a recipe
        static void ScaleRecipe()
        {
            DisplayAllRecipes();
            Console.Write("\nEnter the name of the recipe you want to scale: ");
            string recipeName = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                Console.Write("\nEnter scaling factor (0.5, 2, or 3): ");
                if (double.TryParse(Console.ReadLine(), out double factor) && (factor == 0.5 || factor == 2 || factor == 3))
                {
                    recipe.ScaleRecipe(factor);
                    Console.WriteLine("Recipe scaled successfully.");
                }
                else
                {
                    DisplayError("Invalid scaling factor.");
                }
            }
            else
            {
                DisplayError("Recipe not found.");
            }
        }

        // ----------------------------------------
        // Method to reset quantities of a recipe
        static void ResetQuantities()
        {
            DisplayAllRecipes();
            Console.Write("\nEnter the name of the recipe you want to reset: ");
            string recipeName = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.ResetQuantities();
                Console.WriteLine("Recipe quantities reset successfully.");
            }
            else
            {
                DisplayError("Recipe not found.");
            }
        }

        // ----------------------------------------
        // Method to confirm and clear recipe data
        static void ConfirmClearRecipe()
        {
            DisplayAllRecipes();
            Console.Write("\nEnter the name of the recipe you want to clear: ");
            string recipeName = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                Console.Write("Are you sure you want to clear this recipe? (yes/no): ");
                string confirmation = Console.ReadLine();
                if (confirmation.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    recipe.ClearRecipe();
                    recipes.Remove(recipe);
                    Console.WriteLine("Recipe cleared successfully.");
                }
                else
                {
                    Console.WriteLine("Recipe not cleared.");
                }
            }
            else
            {
                DisplayError("Recipe not found.");
            }
        }

        // ----------------------------------------
        // Event handler for calories exceeded event
        static void OnCaloriesExceeded(string recipeName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nWarning: The recipe '{recipeName}' exceeds 300 calories.");
            Console.ResetColor();
        }

        // ----------------------------------------
        // Method to display error messages
        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {message}");
            Console.ResetColor();
        }
    }
}






