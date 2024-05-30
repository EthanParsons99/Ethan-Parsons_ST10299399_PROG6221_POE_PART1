/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG6221
/// </summary>

/// <summary> 
/// Refrences
/// 
/// Troelsen, A. & Japikse, P., 2022. Pro C# 10 with .NET 6 Foundational Principles and Practices in Programming. 11th ed. USA: Apress.
/// 
///w3resource, 2024. w3resource. [Online]
///Available at: https://www.w3resource.com/csharp-exercises/exception-handling/csharp-exception-handling-exercise-6.php
///[Accessed 15 April 2024].
///
///Witscad, 2021.Witscad. [Online]
///Available at: https://witscad.com/course/csharp-basics/chapter/string-manipulations
///[Accessed 13 April 2024].
///
/// Chand, M., 2018. C# Corner. [Online] 
///Available at: https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/
///[Accessed 15 April 2024].
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 //-----------------------------------------=========------------------------------------//
namespace RecipeApp.Classes
{
    public class RecipeDetails
    {
        public Recipe AddRecipe()
        {
            var newRecipe = new Recipe(); // Create a new recipe object.

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("******************************"); 
            Console.ResetColor();
            Console.Write("Enter the name of recipe: "); // Prompt the user to enter the name of the recipe.
            newRecipe.recipeName = Console.ReadLine();

            Console.Write("Enter the number of ingredients: "); // Prompt the user to enter the number of ingredients.
            try // Try catch block to handle exceptions. Will prompt the user to enter a new option if an invalid choice is entered.
            {
                int numIngredients = Convert.ToInt32(Console.ReadLine()); // Store the number of ingredients entered by the user.

                for (int i = 0; i < numIngredients; i++) // Loop to enter the name, qauntity and unit of measurement for each ingredient.
                {
                    Console.Write("Enter the name ingredient: "); // Prompt the user to enter the name of the ingredient.
                    string ingredientName = Console.ReadLine();
                    Console.Write("Enter the qauntity if ingrediant: "); // Prompt the user to enter the qauntity of the ingredient.
                    string ingredientQuantity = Console.ReadLine();
                    try // Try catch block to handle exceptions. Will prompt the user to enter a new option if an invalid choice is entered.
                    {
                        int ingredientQauntity = Convert.ToInt32(ingredientQuantity);
                    }
                    catch (FormatException)
                    {

                        while (!int.TryParse(ingredientQuantity, out int n)) // Loop to check if the qauntity entered is a number.
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input. Please enter a number for the qauntity of the ingredient.");
                            Console.ResetColor();
                            Console.Write("Enter the qauntity if ingrediant: ");
                            ingredientQuantity = Console.ReadLine();
                        }
                    }
                    Console.Write("Enter the unit of measurement: "); // Prompt the user to enter the unit of measurement for the ingredient.
                    string ingredientUnit = Console.ReadLine();
                    Console.Write("Enter the calories of the ingredient: "); // Prompt the user to enter the calories of the ingredient.
                    string ingredientCalories = Console.ReadLine();
                    try // Try catch block to handle exceptions. Will prompt the user to enter a new option if an invalid choice is entered.
                    {
                        int ingredientCaloriesInt = Convert.ToInt32(ingredientCalories);
                    }
                    catch (FormatException)
                    {
                        while (!int.TryParse(ingredientCalories, out int n)) // Loop to check if the calories entered is a number.
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input. Please enter a number for the calories of the ingredient.");
                            Console.ResetColor();
                            Console.Write("Enter the calories of the ingredient: ");
                            ingredientCalories = Console.ReadLine();
                        }
                    }
                    Console.Write("Enter the food group of the ingredient: "); // Prompt the user to enter the food group of the ingredient.
                    string ingredientFoodGroup = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("******************************");
                    Console.ResetColor();
                    newRecipe.ingredients.Add(new Ingredient(ingredientName, Convert.ToDouble(ingredientQuantity), ingredientUnit, Convert.ToDouble(ingredientCalories), ingredientFoodGroup));
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number for the number of ingredients.");
                Console.ResetColor();
            }

            Console.Write("Enter the number of steps for the recipe: "); // Prompt the user to enter the number of steps for the recipe.
            try // Try catch block to handle exceptions. Will prompt the user to enter a new option if an invalid choice is entered.
            {
                int numSteps = Convert.ToInt32(Console.ReadLine()); // Store the number of steps entered by the user.

                for (int i = 0; i < numSteps; i++) // Loop to enter each step for the recipe.
                {
                    Console.WriteLine("Enter the step: "); // Prompt the user to enter the step.
                    string step = Console.ReadLine(); // Store the step entered by the user.
                    newRecipe.Steps.Add(step); // Add the step to the recipe.
                }
            }
            catch (FormatException) // If the user enters an invalid choice, they will be prompted to enter a new option.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number for the number of steps.");
                Console.ResetColor();
            }

            return newRecipe;
        }
        //------------------------------------------End of method-----------------------------------------//
    }
}
 //-----------------------------------------End of file------------------------------------//