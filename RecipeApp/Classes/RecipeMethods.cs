/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG6221
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Classes
{
    public delegate void CalorieDelegate(double totalCalories); // Delegate to calculate the total calories of the recipe.

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
            // This is the output for the heading of the menu
            Console.ForegroundColor = ConsoleColor.Cyan; // Changes the colour of text
            Console.WriteLine("******************************");
            Console.WriteLine("Welcome to the Recipe App Menu");
            Console.WriteLine("******************************");
            Console.ResetColor(); // Resets the colour text 


            // This is the output of the menu and how it would look like
            Console.WriteLine("Please select an option from the menu below: ");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Clear the recipe");
            Console.WriteLine("3. Scale the recipe");
            Console.WriteLine("4. Reset the qauntity of the recipe");
            Console.WriteLine("5. Print the recipe details");
            Console.WriteLine("6. Sort Recipes");
            Console.WriteLine("7. Select Recipe");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");



            try // Try catch block to handle exceptions. Will prompt the user to enter a new option if an invalid choice is entered.
            {
                int choice = Convert.ToInt32(Console.ReadLine()); // Prompt the user to enter a choice from the menu.

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
                        sortRecipes(); // Call the sortRecipes method to sort the recipes by name.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break; 
                    case 7:
                        selectRecipe(); // Call the selectRecipe method to select a recipe.
                        RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                        break;
                    case 8:
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

        public void printAllRecipeDetails() // Method to print all the recipe details
        {
            foreach (var recipe in Recipes) // Loop to print all the recipe details
            {
                printRecipeDetails(recipe); // Call the printRecipeDetails method to print the recipe details.
            }
        }

        //------------------------------------Print Recipe Method------------------------------------------//
        /// <summary>
        /// This method is used to print the recipe details.
        /// The method will print the recipe name, ingredients and steps.
        /// </summary>
        public void printRecipeDetails(Recipe recipe) // Method to print the recipe details
        {
            if (Recipes.Count == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
            {
                Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                Console.WriteLine("Please add recipe details first !!!!");
                Console.ResetColor(); // Resets the colour text
                RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
            }


            // Output the recipe details
            Console.ForegroundColor = ConsoleColor.Cyan; // Changes the colour of text
            Console.WriteLine("******************************"); 
            Console.WriteLine("Recipe Details"); // Output the message that the recipe details are being printed.
            Console.WriteLine("******************************");
            Console.ResetColor(); // Resets the colour text

            
            
                Console.ForegroundColor = ConsoleColor.Green; // Changes the colour of text
                Console.WriteLine($"Recipe Name: {recipe.recipeName}"); // Print the recipe name.
                Console.ResetColor(); // Resets the colour text


                double totalCalories = calculateCalories(recipe); // Calculate the total calories of the recipe.
                if(totalCalories > 300) // If the total calories are over 300, the total calories will be printed in red.
                { 
                    Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                    Console.WriteLine($"Warning the total Calories are over 300: {totalCalories} calories"); // Print the total calories.
                    Console.ResetColor(); // Resets the colour text
                }
                else // If the total calories are less than 300, the total calories will be printed in green.
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Changes the colour of text
                    Console.WriteLine($"Total Calories: {totalCalories}"); // Print the total calories.
                    Console.ResetColor(); // Resets the colour text
                }


                Console.ForegroundColor = ConsoleColor.Green; // Changes the colour of text
                Console.WriteLine("Ingredients: "); // Print the ingredients.
                Console.ResetColor(); // Resets the colour text
                foreach (var ingredient in recipe.ingredients) // Loop to print the ingredients.
                {
                    Console.WriteLine(ingredient); // Print the ingredients.
                }


                Console.ForegroundColor = ConsoleColor.Green; // Changes the colour of text
                Console.WriteLine("Steps: "); // Print the steps.
                Console.ResetColor(); // Resets the colour text
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
        public void scaleRecipe() // Method to scale the recipe
        {
            try
            {
                if (Recipes.Count == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                    Console.WriteLine("Please add recipe details first !!!!");
                    Console.ResetColor(); // Resets the colour text
                    RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                }

                Console.WriteLine("Enter the number of the recipe you want to select:"); // Output the message to enter the number of the recipe to scale the qauntity.
                for (int i = 0; i < Recipes.Count; i++) // Loop to print the recipe names.
                {
                    Console.WriteLine($"{i + 1}. {Recipes[i].recipeName}"); // Print the recipe number and the recipe name.
                }


                if (!int.TryParse(Console.ReadLine(), out int recipeNumber) || recipeNumber < 1 || recipeNumber > Recipes.Count) // If the user enters an invalid recipe number, they will be prompted to enter a new recipe number.
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                    Console.WriteLine("Invalid option try again !!!"); // Output the message that the selection is invalid.
                    Console.ResetColor(); // Resets the colour text
                    RecipeAppMenu();// Call the RecipeAppMenu method to display the menu again.
                    return;
                }


                Recipe recipe = Recipes[recipeNumber - 1]; // Select the recipe to scale the qauntity.


                Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                Console.Write("Are you sure you want to scale recipe? (yes/no) : "); // Prompt the user to enter if they want to scale the recipe.
                Console.ResetColor(); // Resets the colour text
                string scale = Console.ReadLine(); // Prompt the user to enter if they want to scale the recipe.
                if (scale == "yes") // If the user chooses to scale the recipe, they will be prompted to enter the qauntity by which they want to scale the recipe.
                {
                    Console.WriteLine("By how much should it be scaled:"); // Prompt the user to enter the qauntity by which they want to scale the recipe.
                    double scaleBy = Convert.ToDouble(Console.ReadLine()); // Prompt the user to enter the qauntity by which they want to scale the recipe.

                    foreach (var ingredient in recipe.ingredients) // Loop to scale the qauntity of the ingredients.
                    {
                        ingredient.Quantity *= scaleBy; // Scale the qauntity of the ingredients by multiplying the qauntity by the scaleBy value.
                    }

                    Console.WriteLine($"Recipe has been scaled by {scaleBy}"); // Output the message that the recipe has been scaled.
                    printRecipeDetails(recipe); // Call the printRecipeDetails method to print the recipe details.
                }
                else if (scale == "no") // If the user chooses not to scale the recipe, they will be taken back to the main menu.
                {
                    RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                }
            }
            catch (FormatException) // If the user enters an invalid choice, they will be prompted to enter a new option.
            {
                Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                Console.WriteLine("Invalid choice!!! Please enter a number for your option."); // Output the message that the selection is invalid.
                Console.ResetColor(); // Resets the colour text
                RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
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

            public void clearData() // Method to clear the recipe details
            {

                if (Recipes.Count == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                    Console.WriteLine("Please add recipe details first !!!!"); // Output the message to enter recipe details first.
                    Console.ResetColor(); // Resets the colour text
                    RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
                }

                Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                Console.Write("Are you sure you want to clear the recipe? (yes/no) : "); // Prompt the user to enter if they want to clear the recipe.
                Console.ResetColor(); // Resets the colour text
                string clear = Console.ReadLine(); // Prompt the user to enter if they want to clear the recipe.
                if (clear == "yes") // If the user chooses to clear the recipe, the recipe details will be cleared.
                {
                   Recipes.Clear(); // Clear the recipe details.
                   Console.WriteLine("Recipe has been cleared"); // Output the message that the recipe has been cleared.
                  
                }
                else if (clear == "no") // If the user chooses not to clear the recipe, they will be taken back to the main menu.
                {
                RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
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
        public void resetQauntity() // Method to reset the qauntity of the recipe
        {
            if (Recipes.Count == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
            {
                Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                Console.WriteLine("Please add recipe details first !!!!"); 
                Console.ResetColor(); // Resets the colour text
                RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
            }

            Console.WriteLine("Enter the number of the recipe you want to select:"); // Output the message to enter the number of the recipe to reset the qauntity.
            for (int i = 0; i < Recipes.Count; i++) // Loop to print the recipe names.  
            {
                Console.WriteLine($"{i + 1}. {Recipes[i].recipeName}"); // Print the recipe number and the recipe name.
            }

            if (!int.TryParse(Console.ReadLine(), out int recipeNumber) || recipeNumber < 1 || recipeNumber > Recipes.Count) // If the user enters an invalid recipe number, they will be prompted to enter a new recipe number.
            {
                Console.WriteLine("Invalid"); // Output the message that the selection is invalid.  
            }
            Recipe recipe = Recipes[recipeNumber - 1]; // Select the recipe to reset the qauntity.

            Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
            Console.Write("Are you sure you want to scale recipe? (yes/no) : "); // Prompt the user to enter if they want to scale the recipe.
            Console.ResetColor(); // Resets the colour text
            string reset = Console.ReadLine(); // Prompt the user to enter if they want to scale the recipe.
            if (reset == "yes") // If the user chooses to scale the recipe, they will be prompted to enter the qauntity by which they want to scale the recipe.
            {
                Console.WriteLine("By how much was the recipe scaled?:"); // Prompt the user to enter the qauntity by which they want to scale the recipe.
                double scaleBy = Convert.ToDouble(Console.ReadLine()); // Prompt the user to enter the qauntity by which they want to scale the recipe.
                foreach (var ingredient in recipe.ingredients) // Loop to reset the qauntity of the ingredients.
                {
                    ingredient.Quantity /= scaleBy; // Reset the qauntity of the ingredients by dividing the qauntity by the scaleBy value.
                }
                Console.WriteLine($"Recipe has been scaled by {scaleBy}"); // Output the message that the recipe has been scaled.
                printRecipeDetails(recipe); // Call the printRecipeDetails method to print the recipe details.
            }
        }

        public event CalorieDelegate CalorieEvent; // Event to calculate the total calories of the recipe.

        public double calculateCalories(Recipe recipe) // Method to calculate the total calories of the recipe
        {
            double totalCalories = 0; // Initialize the total calories to 0
            foreach (var ingredient in recipe.ingredients) // Loop to calculate the total calories
            {
                totalCalories += ingredient.Calories * ingredient.Quantity; // Calculate the total calories
            }

            if(totalCalories > 300)
            {
                CalorieEvent?.Invoke(totalCalories); // Invoke the event to calculate the total calories
            }

            return totalCalories; // Return the total calories
        }

        public void sortRecipes() // Method to sort the recipes by name
        {
            if(Recipes.Count == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
            {
                Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                Console.WriteLine("Please add recipe details first !!!!");
                Console.ResetColor(); // Resets the colour text
                RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
            }
            Recipes.Sort((x, y) => x.recipeName.CompareTo(y.recipeName)); // Sort the recipes by name
            Console.WriteLine("Recipes have been sorted by name"); // Output the message that the recipes have been sorted.
        }

        public void selectRecipe() // Method to select a recipe
        {
            if(Recipes.Count == 0) // If there are no recipe details entered, the user will be prompted to enter recipe details first.
            {
                Console.ForegroundColor = ConsoleColor.Red; // Changes the colour of text
                Console.WriteLine("Please add recipe details first !!!!");
                Console.ResetColor(); // Resets the colour text
                RecipeAppMenu(); // Call the RecipeAppMenu method to display the menu again.
            }

            Console.WriteLine("Enter the number of the recipe you want to select:"); // Output the message to enter the number of the recipe to select.
            for (int i = 0; i < Recipes.Count; i++) // Loop to print the recipe names.
            {
                Console.WriteLine($"{i + 1}. {Recipes[i].recipeName}"); // Print the recipe number and the recipe name.
            }

            if (int.TryParse(Console.ReadLine(), out int recipeNumber) && recipeNumber >= 1 && recipeNumber <= Recipes.Count) // If the user enters a valid recipe number, the recipe details will be printed.
            {
                printRecipeDetails(Recipes[recipeNumber - 1]); // Call the printRecipeDetails method to print the recipe details.
            }
            else // If the user enters an invalid recipe number, they will be prompted to enter a new recipe number.
            {
                Console.WriteLine("Invalid selection"); // Output the message that the selection is invalid.
            }
        }
       
        //------------------------------------------End of method-----------------------------------------//
    }
}

