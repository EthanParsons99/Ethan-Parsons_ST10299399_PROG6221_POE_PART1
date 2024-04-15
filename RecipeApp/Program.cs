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
/// <summary>
/// This is my main class that will be used run the RecipeApp. 
/// It will call the RecipeDetails class to run the RecipeAppMenu method.
/// </summary> 
namespace RecipeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeApp.Classes.RecipeDetails rd = new RecipeApp.Classes.RecipeDetails(); //Creating an object of the RecipeDetails class
            rd.RecipeAppMenu(); //Calling the RecipeAppMenu method from the RecipeDetails class
        }
    }
}
