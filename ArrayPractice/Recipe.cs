using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// This code was guided through knowledge forged by Microsoft Build accessabile here: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/
// Insight on Arrays from https://www.w3schools.com/cs/cs_arrays.php
// Insight on Looping from https://www.w3schools.com/cs/cs_arrays.php
// Insight on the Methods from https://www.w3schools.com/cs/cs_methods.php

namespace ArrayPractice
{
 
    class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numOfIngredients = Convert.ToInt32(Console.ReadLine());

            // Initialize arrays based on the number of ingredients entered
            ingredients = new string[numOfIngredients];
            quantities = new double[numOfIngredients];
            units = new string[numOfIngredients];

            // Loop to input details for each ingredient
            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                ingredients[i] = Console.ReadLine();

                Console.Write($"Enter the quantity of {ingredients[i]}: ");
                quantities[i] = Convert.ToDouble(Console.ReadLine());

                Console.Write($"Enter the unit of measurement for {ingredients[i]}: ");
                units[i] = Console.ReadLine();
            }

            Console.Write("Enter the number of steps: ");
            int numOfSteps = Convert.ToInt32(Console.ReadLine());

            // Initialize array for steps based on the number entered
            steps = new string[numOfSteps];
            // Loop to input preparation steps
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }
        }
        // Method to display the recipe
        public void DisplayRecipe()
        {
            // Check if recipe details are entered
            if (ingredients == null || steps == null)
            {
                Console.WriteLine("Recipe details are not entered yet.");
                return;
            }

            // Display ingredients and quantities
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{ingredients[i]} - {quantities[i]} {units[i]}");
            }

            // Display preparation steps
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            // Check if recipe details are entered
            if (quantities == null)
            {
                Console.WriteLine("Recipe details are not entered yet.");
                return;
            }

            // Scale quantities of ingredients
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }

            Console.WriteLine("\nRecipe scaled successfully.");
            DisplayRecipe();
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            // Check if recipe details are entered
            if (quantities == null)
            {
                Console.WriteLine("Recipe details are not entered yet.");
                return;
            }

            Console.WriteLine("\nQuantities reset to original values.");
            DisplayRecipe();
        }

        // Method to clear all recipe data
        public void ClearRecipe()
        {
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;
            Console.WriteLine("\nRecipe details cleared.");
        }
    }
}


