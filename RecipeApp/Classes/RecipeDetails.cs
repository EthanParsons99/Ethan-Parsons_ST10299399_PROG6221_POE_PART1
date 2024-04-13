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
        public int numIngredients = 0;
        public int numSteps = 0;
        public string[] ingredients;
        public string[] steps;
 //-----------------------------------------=========------------------------------------//
        public void recipeIngredients()
        {
            Console.Write("Enter the name of recipe: ");
            string recipeName = Console.ReadLine();
            Console.WriteLine("Enter the number of ingredients: ");
            numIngredients = Convert.ToInt32(Console.ReadLine());
            ingredients = new string[numIngredients];


            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("Enter the name ingredient: ");
                string ingredientName = Console.ReadLine();
                Console.WriteLine("Enter the qauntity if ingrediant: ");
                string ingredientQuantity = Console.ReadLine(); 
                Console.WriteLine("Enter the unit of measurement: ");
                string ingredientUnit = Console.ReadLine();
                ingredients[i] = $"{ingredientName} - {ingredientQuantity} {ingredientUnit}";
            }
            Console.WriteLine($"Recipe: {recipeName}");
        }
        //-----------------------------------------=========------------------------------------//
        public void recipeSteps()
        {
            Console.WriteLine("Enter the number of steps for the recipe: ");
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
            Console.WriteLine("Recipe Details: ");
            Console.WriteLine("Ingredients: ");
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine("Steps: ");
            foreach (string step in steps)
            {
                Console.WriteLine(step);
            }
        }
        //-----------------------------------------=========------------------------------------//
        public void scaleRecipe()
        {
            Console.WriteLine("Do you want to scale the recipe? (yes/no)");
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
            }
        }
         //-----------------------------------------=========------------------------------------//
        public void clearData()
        {
            Console.WriteLine("Do you want to clear the recipe? (yes/no)");
            string clear = Console.ReadLine();
            if (clear == "yes")
            {
                numIngredients = 0;
                numSteps = 0;
                ingredients = null;
                steps = null;
            }
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
        }
    }
}
 //-----------------------------------------End of file------------------------------------//