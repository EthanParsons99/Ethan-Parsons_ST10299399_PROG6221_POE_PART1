using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp.Classes;
using System;
using System.Collections.Generic;

namespace RecipeApp.UnitTest
{
    [TestClass]
    public class RecipeMethodsTest
    {

        [TestMethod]
        public void calculateCaloriesTest()
        {
            // Arrange
            var testRecipe = new Recipe
            {
                recipeName = "test",

                ingredients = new List<Ingredient>
                {
                    new Ingredient("Milk", 1, "cup", 100, "Dairy"),
                    new Ingredient("Banana", 1, "one", 89, "Fruit"),
                }
            };

            RecipeMethods recipeMethods = new RecipeMethods();

            // Act
            double totalCalories = recipeMethods.calculateCalories(testRecipe);

            // Assert
            Assert.AreEqual(189, totalCalories);
        }
    }
}
