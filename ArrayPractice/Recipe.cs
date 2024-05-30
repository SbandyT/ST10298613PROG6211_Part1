using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
// This code was guided through knowledge forged by Microsoft Build accessabile here: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/
// Insight on Arrays from https://www.w3schools.com/cs/cs_arrays.php
// Insight on Looping from https://www.w3schools.com/cs/cs_arrays.php
// Insight on the Methods from https://www.w3schools.com/cs/cs_methods.php

namespace ArrayPractice
{

    public class Recipe
    {
        // Properties
        public string Name { get; set; } // Name of the recipe
        public List<Ingredient> Ingredients { get; set; } // List of ingredients
        public List<string> Steps { get; set; } // List of preparation steps
        public double TotalCalories { get; private set; } // Total calories in the recipe
        private List<Ingredient> OriginalIngredients { get; set; } // Original ingredients for resetting

        // Delegate and event for calories exceeded
        public delegate void CaloriesExceededEventHandler(string recipeName);
        public event CaloriesExceededEventHandler CaloriesExceeded;

        // Constructor
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        // ----------------------------------------
        // Method to add ingredient
        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            Ingredients.Add(ingredient);
            OriginalIngredients = Ingredients.Select(ing => ing.Clone()).ToList();
            CalculateTotalCalories();
        }

        // ----------------------------------------
        // Method to add step
        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        // ----------------------------------------
        // Method to calculate total calories
        private void CalculateTotalCalories()
        {
            TotalCalories = Ingredients.Sum(ing => ing.Calories * ing.Quantity);
            if (TotalCalories > 300)
            {
                CaloriesExceeded?.Invoke(Name);
            }
        }

        // ----------------------------------------
        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            Console.WriteLine($"Total Calories: {TotalCalories}");
        }

        // ----------------------------------------
        // Method to scale recipe
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
            CalculateTotalCalories();
        }

        // ----------------------------------------
        // Method to reset quantities
        public void ResetQuantities()
        {
            Ingredients = OriginalIngredients.Select(ing => ing.Clone()).ToList();
            CalculateTotalCalories();
        }

        // ----------------------------------------
        // Method to clear the recipe
        public void ClearRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
            TotalCalories = 0;
        }
    }

    // ----------------------------------------
    // Ingredient class
    public class Ingredient
    {
        // Properties
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // ----------------------------------------
        // Clone method for creating a copy of the ingredient
        public Ingredient Clone()
        {
            return new Ingredient(Name, Quantity, Unit, Calories, FoodGroup);
        }
    }
}
// *******88**************88*********END*******88******88****88****************************

