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
        private int scaleBy = 1;
        //-----------------------------------------=========------------------------------------//
        public void RecipeAppMenu()
        {   
            Console.WriteLine("Welcome to the Recipe App");
            Console.WriteLine("*****************************");

            Console.WriteLine("Please select an option from the menu below of what you would like to do: ");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Clear the recipe");
            Console.WriteLine("3. Scale the recipe");
            Console.WriteLine("4. Reset the qauntity of the recipe");
            Console.WriteLine("5. Print the recipe details");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
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
                    Console.WriteLine("Thank you for using our app.Exiting the Recipe App");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    RecipeAppMenu();
                    break;
            }
        }
        //-----------------------------------------=========------------------------------------//
        public void recipeIngredients()
        {
            Console.Write("Enter the name of recipe: ");
            string recipeName = Console.ReadLine();
            Console.Write("Enter the number of ingredients: ");
            numIngredients = Convert.ToInt32(Console.ReadLine());
            ingredients = new string[numIngredients];


            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter the name ingredient: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Enter the qauntity if ingrediant: ");
                string ingredientQuantity = Console.ReadLine(); 
                Console.Write("Enter the unit of measurement: ");
                string ingredientUnit = Console.ReadLine();
                ingredients[i] = $"{ingredientName} - {ingredientQuantity} {ingredientUnit}";
            }
        }
        //-----------------------------------------=========------------------------------------//
        public void recipeSteps()
        {
            Console.Write("Enter the number of steps for the recipe: ");
            numSteps = Convert.ToInt32(Console.ReadLine());
            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Enter the step: ");
                string step = Console.ReadLine();
                steps[i] = step;
            }
        }
        //-----------------------------------------=========------------------------------------//
        public void printRecipeDetails()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("Recipe Details: ");
            Console.WriteLine("Recipe Name: {0}", recipeName);
            Console.WriteLine("Ingredients: ");
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine("Steps: ");
            for(int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"Step {i + 1}: {steps[i]}");
            }
            Console.WriteLine("***********************************");
        }
        //-----------------------------------------=========------------------------------------//
        public int scaleRecipe()
        {
            if (numIngredients == 0)
            {
                Console.WriteLine("Please add recipe details first !!!!");
                RecipeAppMenu();
            }

            Console.WriteLine("Are you sure you want to scale recipe? (yes/no)");
            string scale = Console.ReadLine();
            if (scale == "yes")
            {
                Console.WriteLine("By how much should the ingrdients be scaled? : ");
                int scaleBy = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    string[] parts = ingredients[i].Split('-');
                    string qauntity = parts[1].Trim();
                    string[] qauntityParts = qauntity.Split(' ');
                    string qauntityValue = qauntityParts[0];
                    int newQauntity = Convert.ToInt32(qauntityValue) * scaleBy;
                    ingredients[i] = $"{parts[0]} - {newQauntity} {qauntityParts[1]}";
                }
                Console.WriteLine("Recipe has been scaled by {0}", scaleBy);
                printRecipeDetails();
                return scaleBy;
            }
            else if (scale == "no")
            {
                RecipeAppMenu();
            }
            return 1;
        }
         //-----------------------------------------=========------------------------------------//
        public void clearData()
        {
            Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
            string clear = Console.ReadLine();
            if (clear == "yes")
            {
                numIngredients = 0;
                numSteps = 0;
                ingredients = null;
                steps = null;
                Console.WriteLine("Recipe has been cleared");
                Console.WriteLine("Do you want to enter a new recipe? (yes/no)");
                string newRecipe = Console.ReadLine();
                if (newRecipe == "yes")
                {
                    recipeIngredients();
                    recipeSteps();
                    printRecipeDetails();
                    scaleRecipe();
                }
                else if (newRecipe == "no")
                {
                    RecipeAppMenu();
                }
            }
            else if (clear == "no")
            {
                RecipeAppMenu();
            }

        }
        //-----------------------------------------=========------------------------------------//
        public void resetQauntity(int scaleBy)
        {
            Console.WriteLine("Do you want to reset the qauntity of the recipe? (yes/no)");
            string reset = Console.ReadLine();
            if (reset == "yes")
            {
                for (int i = 0; i < numIngredients; i++)
                {
                    string[] parts = ingredients[i].Split('-');
                    string qauntity = parts[1].Trim();
                    string[] qauntityParts = qauntity.Split(' ');
                    string qauntityValue = qauntityParts[0];
                    int newQauntity = Convert.ToInt32(qauntityValue) / scaleBy;
                    ingredients[i] = $"{parts[0]} - {newQauntity} {qauntityParts[1]}";
                }
                Console.WriteLine("Recipe has been reset to original qauntity");
                printRecipeDetails();
            }
            else if (reset == "no")
            {
                RecipeAppMenu();
            }
        }
    }
}
 //-----------------------------------------End of file------------------------------------//