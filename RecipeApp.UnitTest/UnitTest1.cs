using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp.Classes;
using System;
using System.Collections.Generic;

namespace RecipeApp.UnitTest
{
    [TestClass]
    public class RecipeMethodsTest // Class to test the RecipeMethods class.
    {

        [TestMethod] // Method to test the calculateCalories method.
        public void calculateCaloriesTest() // Method to test the calculateCalories method.
        {
            // Arrange
            var testRecipe = new Recipe // Create a new recipe object.
            {
                recipeName = "test", // Set the name of the recipe.

                ingredients = new List<Ingredient> // Initialize the ingredients list.
                {
                    new Ingredient("Milk", 1, "cup", 100, "Dairy"), // Add a new ingredient to the ingredients list.
                    new Ingredient("Banana", 1, "one", 89, "Fruit"), // Add a new ingredient to the ingredients list.
                }
            };

            RecipeMethods recipeMethods = new RecipeMethods(); // Create a new RecipeMethods object.

            // Act
            double totalCalories = recipeMethods.calculateCalories(testRecipe); // Call the calculateCalories method.

            // Assert
            Assert.AreEqual(189, totalCalories); // Check if the total calories are equal to 189.
        }
    }
}
