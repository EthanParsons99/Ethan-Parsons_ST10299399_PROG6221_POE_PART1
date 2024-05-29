using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Classes
{
    public class RecipeMethods
    {
        //-----------------------------------------Menu Method-----------------------------------//
        /// <summary>
        /// In this method, the user is presented with a menu of options to choose from. 
        /// The user can choose to enter a new recipe, clear the recipe, scale the recipe, 
        /// reset the qauntity of the recipe, print the recipe details or exit the app.
        /// </summary>
        public void RecipeAppMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            // This is the output display of the menu
            Console.WriteLine("******************************");
            Console.WriteLine("Welcome to the Recipe App Menu");
            Console.WriteLine("******************************");
            Console.ResetColor();

            Console.WriteLine("Please select an option from the menu below: ");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Clear the recipe");
            Console.WriteLine("3. Scale the recipe");
            Console.WriteLine("4. Reset the qauntity of the recipe");
            Console.WriteLine("5. Print the recipe details");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            try // Try catch block to handle exceptions. Will prompt the user to enter a new option if an invalid choice is entered.
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) // Switch case to handle the user choice.
                {
                    case 1:
                        recipeIngredients(); // Call the recipeIngredients method to enter the ingredients for the recipe.
                        recipeSteps(); // Call the recipeSteps method to enter the steps for the recipe.
                        printRecipeDetails(); // Call the printRecipeDetails method to print the recipe details.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 2:
                        clearData(); // Call the clearData method to clear the recipe details.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 3:
                        scaleBy = scaleRecipe(); // Call the scaleRecipe method to scale the recipe.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 4:
                        resetQauntity(scaleBy); // Call the resetQauntity method to reset the qauntity of the recipe.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 5:
                        printRecipeDetails(); // Call the printRecipeDetails method to print the recipe details.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thank you for using our app.Exiting the Recipe App"); // Output the message that the app is exiting.
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default: // If the user enters an invalid choice, they will be prompted to enter a new option.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice!!! Please choose a new option.");
                        Console.ResetColor();
                        RecipeAppMenu();
                        break;
                }
            }
            catch (FormatException) // If the user enters an invalid choice, they will be prompted to enter a new option.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice!!! Please enter a number for your option.");
                Console.ResetColor();
                RecipeAppMenu();
            }
        }
        //------------------------------------------End of method-----------------------------------------//

    }
}
