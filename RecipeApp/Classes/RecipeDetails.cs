/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG6221
/// </summary>

/// <summary> 
/// Refrences
/// 
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
        public string recipeName;
        public int numIngredients = 0;
        public int numSteps = 0;
        public string[] ingredients;
        public string[] steps;
        public double scaleBy = 1;

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
                        recipeIngredients();
                        recipeSteps();
                        printRecipeDetails();
                        RecipeAppMenu();
                        break;
                    case 2:
                        clearData();
                        RecipeAppMenu();
                        break;
                    case 3:
                        scaleBy = scaleRecipe();
                        RecipeAppMenu();
                        break;
                    case 4:
                        resetQauntity(scaleBy);
                        RecipeAppMenu();
                        break;
                    case 5:
                        printRecipeDetails();
                        RecipeAppMenu();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thank you for using our app.Exiting the Recipe App");
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
            numIngredients = Convert.ToInt32(Console.ReadLine());
            ingredients = new string[numIngredients];

                
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
                numSteps = Convert.ToInt32(Console.ReadLine());
                steps = new string[numSteps];

                for (int i = 0; i < numSteps; i++) // Loop to enter each step for the recipe.
                {
                    Console.WriteLine("Enter the step: "); // Prompt the user to enter the step.
                    string step = Console.ReadLine();
                    steps[i] = step;
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


        //------------------------------------Print Recipe Method------------------------------------------//
        /// <summary>
        /// This method is used to print the recipe details.
        /// The method will print the recipe name, ingredients and steps.
        /// </summary>
        public void printRecipeDetails()
        {
            if (numIngredients == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add recipe details first !!!!"); 
                Console.ResetColor();
                RecipeAppMenu();
            }

            // Output the recipe details
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("******************************");
            Console.WriteLine("Recipe Details");
            Console.WriteLine("******************************");
            Console.ResetColor();
            Console.WriteLine("Recipe Name: {0}", recipeName); // Print the recipe name.
            Console.WriteLine("Ingredients: ");
            foreach (string ingredient in ingredients) // Loop to print the ingredients.
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine("Steps: ");
            for(int i = 0; i < steps.Length; i++) // Loop to print the steps.
            {
                Console.WriteLine($"Step {i + 1}: {steps[i]}"); // Print the step number and the step.
            }
        }
        //------------------------------------------End of method-----------------------------------------//


        //----------------------------------------Scaleing Method------------------------------------//
        /// <summary>
        /// This method is used to scale the recipe by the qauntity entered by the user.
        /// If there is no recipe details entered, the user will be prompted to enter recipe details first.
        /// If the user chooses to scale the recipe, they will be prompted to enter the qauntity by which they want to scale the recipe.
        /// if the user chooses not to scale the recipe, they will be taken back to the main menu.
        /// </summary>
        public double scaleRecipe()
        {
            if (numIngredients == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add recipe details first !!!!");
                Console.ResetColor();
                RecipeAppMenu();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Are you sure you want to scale recipe? (yes/no) : "); // Prompt the user to enter if they want to scale the recipe.
            Console.ResetColor();
            string scale = Console.ReadLine();
            if (scale == "yes") // If the user chooses to scale the recipe, they will be prompted to enter the qauntity by which they want to scale the recipe.
            {
                Console.Write("By how much should the ingrdients be scaled? : ");
                double scaleBy = Convert.ToDouble(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++) // Loop to scale the qauntity of the ingredients.
                {
                    string[] parts = ingredients[i].Split('-'); // Split the ingredient details to get the qauntity.
                    string qauntity = parts[1].Trim(); // Trim the qauntity to remove any white spaces.
                    string[] qauntityParts = qauntity.Split(' '); // Split the qauntity to get the qauntity value and unit of measurement.
                    string qauntityValue = qauntityParts[0]; // Get the qauntity value.
                    double newQauntity = Convert.ToDouble(qauntityValue) * scaleBy; // Scale the qauntity by the qauntity entered by the user.
                    ingredients[i] = $"{parts[0]} - {newQauntity} {qauntityParts[1]}"; // Store the new qauntity in the ingredients array.
                }
                Console.WriteLine("Recipe has been scaled by {0}", scaleBy); // Output the message that the recipe has been scaled.
                printRecipeDetails();
                return scaleBy; // Return the qauntity by which the recipe was scaled.   
            }
            else if (scale == "no") // If the user chooses not to scale the recipe, they will be taken back to the main menu.
            {
                RecipeAppMenu();
            }
            return 1; // Return 1 if the user chooses not to scale the recipe.
        }
        //------------------------------------------End of method-----------------------------------------//


        //-------------------------------------Clear data method------------------------------------//
        /// <summary>
        /// This method is used to clear the recipe details. And then prompts the user to enter a new recipe.
        /// If the user chooses to enter a new recipe, they will be prompted to enter the recipe details.
        /// if the user chooses not to enter a new recipe, they will be taken back to the main menu.
        /// If there are no recipe details entered, the user will be prompted to enter recipe details first.
        /// if the user chooses not to clear the recipe, they will be taken back to the main menu.
        /// </summary>
        public void clearData()
        {
            if (numIngredients == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add recipe details first !!!!"); 
                Console.ResetColor();
                RecipeAppMenu();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Are you sure you want to clear the recipe? (yes/no) : "); // Prompt the user to enter if they want to clear the recipe.
            Console.ResetColor();
            string clear = Console.ReadLine();
            if (clear == "yes") // If the user chooses to clear the recipe, the recipe details will be cleared.
            {
                numIngredients = 0; // Clear the number of ingredients.
                numSteps = 0; // Clear the number of steps.
                ingredients = null; // Clear the ingredients.
                steps = null; // Clear the steps.
                Console.WriteLine("Recipe has been cleared");
                Console.Write("Do you want to enter a new recipe? (yes/no) : "); // Prompt the user to enter if they want to enter a new recipe.
                string newRecipe = Console.ReadLine();
                if (newRecipe == "yes") // If the user chooses to enter a new recipe, they will be prompted to enter the recipe details.
                {
                    recipeIngredients();
                    recipeSteps();
                    printRecipeDetails();
                }
                else if (newRecipe == "no") // If the user chooses not to enter a new recipe, they will be taken back to the main menu.
                {
                    RecipeAppMenu();
                }
            }
            else if (clear == "no") // If the user chooses not to clear the recipe, they will be taken back to the main menu.
            {
                RecipeAppMenu();
            }

        }
        //------------------------------------------End of method-----------------------------------------//


        //---------------------------------Reset Qauntity Method------------------------------------//
        /// <summary>
        /// This method is used to reset the qauntity of the recipe to the origanal values enterd at the beginning by user.
        /// This is done by dividing the qauntity of the ingredients by the scaleBy value.
        /// That was entered by the user when they scaled the recipe.
        /// This method will only work if the user has already scaled the recipe. Otherwise it will just output the same recipe.
        /// If no recipe details have been entered, the user will be prompted to enter recipe details first.
        /// If the user chooses not to reset the qauntity, they will be taken back to the main menu.
        /// </summary>
        public void resetQauntity(double scaleBy)
        {
            if (numIngredients == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add recipe details first !!!!");
                Console.ResetColor();
                RecipeAppMenu();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Are you sure you want to reset the qauntity of the recipe? (yes/no)"); // Prompt the user to enter if they want to reset the qauntity of the recipe.
            Console.ResetColor();
            string reset = Console.ReadLine();
            if (reset == "yes") // If the user chooses to reset the qauntity of the recipe, the qauntity of the ingredients will be reset to the original values.
            {
                for (int i = 0; i < numIngredients; i++) // Loop to reset the qauntity of the ingredients.
                {
                    string[] parts = ingredients[i].Split('-'); // Split the ingredient details to get the qauntity.
                    string qauntity = parts[1].Trim(); // Trim the qauntity to remove any white spaces.
                    string[] qauntityParts = qauntity.Split(' '); // Split the qauntity to get the qauntity value and unit of measurement.
                    string qauntityValue = qauntityParts[0]; // Get the qauntity value.
                    double newQauntity = Convert.ToDouble(qauntityValue) / scaleBy; // Reset the qauntity to the original value by deviding with scaleBy.
                    ingredients[i] = $"{parts[0]} - {newQauntity} {qauntityParts[1]}"; // Store the new qauntity in the ingredients array.
                }
                Console.WriteLine("Recipe has been reset to original qauntity"); // Output the message that the recipe has been reset.
                printRecipeDetails();
            }
            else if (reset == "no") // If the user chooses not to reset the qauntity of the recipe, they will be taken back to the main menu.
            {
                RecipeAppMenu();
            }
        }
        //------------------------------------------End of method-----------------------------------------//
    }
}
 //-----------------------------------------End of file------------------------------------//