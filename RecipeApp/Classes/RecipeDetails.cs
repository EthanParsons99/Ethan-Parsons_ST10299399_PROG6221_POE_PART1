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
        public string recipeName; // Declaring the variables to store the recipe details.
        public int numIngredients = 0; // Declaring the variables to store the recipe details.
        public int numSteps = 0; // Declaring the variables to store the recipe details.
        public string[] ingredients; // Declaring the variables to store the recipe details.
        public string[] steps; // Declaring the variables to store the recipe details.
        public double scaleBy = 1; // Declaring the variables to store the recipe details.

        //-----------------------------------------Ingredients Method------------------------------------//
        /// <summary>
        /// This method is used to enter the ingredients for the recipe.
        /// The user will be prompted to enter the name of the recipe and the number of ingredients.
        /// The user will then be prompted to enter the name, qauntity and unit of measurement for each ingredient.
        /// The ingredients get stored in an array.
        /// </summary>
        public void recipeIngredients()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("******************************");
            Console.ResetColor();
            Console.Write("Enter the name of recipe: "); // Prompt the user to enter the name of the recipe.
            recipeName = Console.ReadLine();
            Console.Write("Enter the number of ingredients: "); // Prompt the user to enter the number of ingredients.
            try // Try catch block to handle exceptions. Will prompt the user to enter a new option if an invalid choice is entered.
            { 
            numIngredients = Convert.ToInt32(Console.ReadLine()); // Store the number of ingredients entered by the user.
            ingredients = new string[numIngredients]; // Create an array to store the ingredients.

                
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
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("******************************");
                    Console.ResetColor();
                    ingredients[i] = $"{ingredientName} - {ingredientQuantity} {ingredientUnit}"; // Store the ingredient details in an array.
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number for the number of ingredients.");
                Console.ResetColor();
                recipeIngredients();
            }
        }
        //------------------------------------------End of method-----------------------------------------//


        //------------------------------------------Steps Method-----------------------------------//
        /// <summary>
        /// This method is used to enter the steps for the recipe.
        /// The user will be prompted to enter the number of steps for the recipe.
        /// After entering the number of steps, the user will be prompted to enter each step.
        /// The steps get stored in an array.
        /// </summary>
        public void recipeSteps()
        {
            Console.Write("Enter the number of steps for the recipe: "); // Prompt the user to enter the number of steps for the recipe.
            try // Try catch block to handle exceptions. Will prompt the user to enter a new option if an invalid choice is entered.
            {
                numSteps = Convert.ToInt32(Console.ReadLine()); // Store the number of steps entered by the user.
                steps = new string[numSteps]; // Create an array to store the steps.

                for (int i = 0; i < numSteps; i++) // Loop to enter each step for the recipe.
                {
                    Console.WriteLine("Enter the step: "); // Prompt the user to enter the step.
                    string step = Console.ReadLine(); // Store the step in an array.
                    steps[i] = step; // Store the step in an array.
                }
            }
            catch (FormatException) // If the user enters an invalid choice, they will be prompted to enter a new option.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number for the number of steps.");
                Console.ResetColor();
                recipeSteps();
            }
        }
        //------------------------------------------End of method-----------------------------------------//


      
    }
}
 //-----------------------------------------End of file------------------------------------//