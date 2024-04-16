
using System;
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
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe(); //  an instance of the Recipe class to work with recipe data.
            bool exit = false;

            while (!exit)
            {
                // Display menu options
                Console.WriteLine("\n1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");

                // Read user choice
                int choice = int.Parse(Console.ReadLine());

                // Switch case to handle user choices
                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipeDetails(); // the method to enter recipe details.
                        break;
                    case 2:
                        recipe.DisplayRecipe(); //  the method to display the recipe.
                        break;
                    case 3:
                        Console.Write("\nEnter scaling factor (0.5, 2, or 3): ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);//  the method to scale the recipe.
                        break;
                    case 4:
                        recipe.ResetQuantities(); //  method to reset quantities.
                        break;
                    case 5:
                        recipe.ClearRecipe(); // method to clear the recipe.
                        break;
                    case 6:
                        exit = true; //  exit flag set to true to exit the loop and terminate the program.
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}






