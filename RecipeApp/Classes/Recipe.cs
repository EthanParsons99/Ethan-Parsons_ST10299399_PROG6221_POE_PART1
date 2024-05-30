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
    public class Recipe 
    {
        public string recipeName { get; set; } // Property to store the name of the recipe.
        public List<Ingredient> ingredients { get; set; } // Property to store the ingredients of the recipe.
        public List<string> Steps { get; set; } // Property to store the steps of the recipe.

        public Recipe()
        {
            ingredients = new List<Ingredient>(); // Initialize the ingredients list.
            Steps = new List<string>(); // Initialize the steps list.
        }
    }

    public class Ingredient
    {
        public string Name { get; set; } // Property to store the name of the ingredient.
        public double Quantity { get; set; } // Property to store the quantity of the ingredient.
        public string Unit { get; set; } // Property to store the unit of measurement of the ingredient.
        public double Calories { get; set; } // Property to store the calories of the ingredient.
        public string FoodGroup { get; set; } // Property to store the food group of the ingredient.

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name; // Initialize the name of the ingredient.
            Quantity = quantity; // Initialize the quantity of the ingredient.
            Unit = unit; // Initialize the unit of measurement of the ingredient.
            Calories = calories; // Initialize the calories of the ingredient.
            FoodGroup = foodGroup; // Initialize the food group of the ingredient.
        }

        public override string ToString()
        {
            return $"{Name} - {Quantity} {Unit} - {Calories} calories - {FoodGroup}"; // Return the string representation of the ingredient.
        }
    }
}
