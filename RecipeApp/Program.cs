using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scaleBy = 2;
            RecipeApp.Classes.RecipeDetails rd = new RecipeApp.Classes.RecipeDetails();
            rd.recipeIngredients();
            rd.recipeSteps();
            rd.printRecipeDetails();
            rd.scaleRecipe();
            rd.resetQauntity(scaleBy);
            rd.clearData();
        }
    }
}
