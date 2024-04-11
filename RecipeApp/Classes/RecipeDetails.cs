using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Ethan Parsons
/// ST10299399
/// PROG6221
/// </summary>
 //-----------------------------------------=========------------------------------------//
namespace RecipeApp.Classes
{
    internal class RecipeDetails
    {
        public int numIngredients = 0;
        public int numSteps = 0;
        public string[] ingredients;
        public string[] steps;

        public void recipeIngredients()
        {
            Console.Write("Enter the name of recipe: ");
            string recipeName = Console.ReadLine();
            Console.WriteLine("Enter the number of ingredients: ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());
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
            printRecipe();
        }

        public void printRecipe()
        { 
            Console.WriteLine("Ingredients: ");
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine(ingredient);
            }
        }
    }
}
 //-----------------------------------------End of file------------------------------------//