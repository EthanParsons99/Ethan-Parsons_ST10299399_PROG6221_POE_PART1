using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Classes
{
    public class RecipeMethods
    {
        public List<Recipe> Recipes { get; set; } // Property to store the recipes.
        public double scaleBy { get; set; } // Property to store the qauntity by which the recipe was scaled.

        public RecipeMethods()
        {
            Recipes = new List<Recipe>(); // Initialize the recipes list.
        }


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
                        var input = new RecipeDetails();
                        var recipe = input.AddRecipe(); // Call the AddRecipe method to enter a new recipe.
                        Recipes.Add(recipe); // Add the recipe to the recipes list.
                        printRecipeDetails(recipe); // Call the printRecipeDetails method to print the recipe details.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 2:
                        clearData(); // Call the clearData method to clear the recipe details.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 3:
                        scaleRecipe(); // Call the scaleRecipe method to scale the recipe.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 4:
                        resetQauntity(); // Call the resetQauntity method to reset the qauntity of the recipe.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 5:
                        printAllRecipeDetails(); // Call the printRecipeDetails method to print the recipe details.
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

        public void printAllRecipeDetails()
        {
            foreach (var recipe in Recipes)
            {
                printRecipeDetails(recipe);
            }
        }

        //------------------------------------Print Recipe Method------------------------------------------//
        /// <summary>
        /// This method is used to print the recipe details.
        /// The method will print the recipe name, ingredients and steps.
        /// </summary>
        public void printRecipeDetails(Recipe recipe)
        {
            if (Recipes.Count == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
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

            
            
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Recipe Name: {recipe.recipeName}"); // Print the recipe name.
                Console.ResetColor();
                //Console.WriteLine(recipe.recipeName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ingredients: ");
                Console.ResetColor();
                foreach (var ingredient in recipe.ingredients) // Loop to print the ingredients.
                {
                    Console.WriteLine(ingredient);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Steps: ");
                Console.ResetColor();
                for (int i = 0; i < recipe.Steps.Count; i++) // Loop to print the steps.
                {
                    Console.WriteLine($"Step {i + 1}: {recipe.Steps[i]}"); // Print the step number and the step.
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
        public void scaleRecipe()
        {
            if (Recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add recipe details first !!!!");
                Console.ResetColor();
                RecipeAppMenu();
            }

            Console.WriteLine("Enter the number of the recipe you want to select:");
            for (int i = 0; i < Recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Recipes[i].recipeName}");
            }

            if (!int.TryParse(Console.ReadLine(), out int recipeNumber) && recipeNumber >= 1 && recipeNumber <= Recipes.Count)
            {
                Console.WriteLine("Invalid");
            }
            Recipe recipe = Recipes[recipeNumber - 1];

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Are you sure you want to scale recipe? (yes/no) : "); // Prompt the user to enter if they want to scale the recipe.
            Console.ResetColor();
            string scale = Console.ReadLine();
            if (scale == "yes") // If the user chooses to scale the recipe, they will be prompted to enter the qauntity by which they want to scale the recipe.
            {
                Console.WriteLine("By how much should it be scaled:");
                double scaleBy = Convert.ToDouble(Console.ReadLine());

                foreach (var ingredient in recipe.ingredients)
                {
                    ingredient.Quantity *= scaleBy;
                }
                Console.WriteLine($"Recipe has been scaled by {scaleBy}"); // Output the message that the recipe has been scaled.
                printRecipeDetails(recipe);
            }
        }
            ////------------------------------------------End of method-----------------------------------------//


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

                if (Recipes.Count == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
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
                   Recipes.Clear();
                   Console.WriteLine("Recipe has been cleared");
                  
                }
                else if (clear == "no") // If the user chooses not to clear the recipe, they will be taken back to the main menu.
                {
                RecipeAppMenu();
                }

            }
        ////------------------------------------------End of method-----------------------------------------//


        //---------------------------------Reset Qauntity Method------------------------------------//
        /// <summary>
        /// This method is used to reset the qauntity of the recipe to the origanal values enterd at the beginning by user.
        /// This is done by dividing the qauntity of the ingredients by the scaleBy value.
        /// That was entered by the user when they scaled the recipe.
        /// This method will only work if the user has already scaled the recipe. Otherwise it will just output the same recipe.
        /// If no recipe details have been entered, the user will be prompted to enter recipe details first.
        /// If the user chooses not to reset the qauntity, they will be taken back to the main menu.
        /// </summary>
        /// 
        public void resetQauntity()
        {
            if (Recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add recipe details first !!!!");
                Console.ResetColor();
                RecipeAppMenu();
            }

            Console.WriteLine("Enter the number of the recipe you want to select:");
            for (int i = 0; i < Recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Recipes[i].recipeName}");
            }

            if (!int.TryParse(Console.ReadLine(), out int recipeNumber) || recipeNumber < 1 || recipeNumber > Recipes.Count)
            {
                Console.WriteLine("Invalid");
            }
            Recipe recipe = Recipes[recipeNumber - 1];

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Are you sure you want to scale recipe? (yes/no) : "); // Prompt the user to enter if they want to scale the recipe.
            Console.ResetColor();
            string reset = Console.ReadLine();
            if (reset == "yes") // If the user chooses to scale the recipe, they will be prompted to enter the qauntity by which they want to scale the recipe.
            {
                Console.WriteLine("By how much was the recipe scaled?:");
                double scaleBy = Convert.ToDouble(Console.ReadLine());
                foreach (var ingredient in recipe.ingredients)
                {
                    ingredient.Quantity /= scaleBy;
                }
                Console.WriteLine($"Recipe has been scaled by {scaleBy}"); // Output the message that the recipe has been scaled.
                printRecipeDetails(recipe);
            }
        }
       
        //------------------------------------------End of method-----------------------------------------//
    }
}

