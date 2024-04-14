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
            RecipeApp.Classes.RecipeDetails rd = new RecipeApp.Classes.RecipeDetails();
            rd.RecipeAppMenu();
        }
    }
}
