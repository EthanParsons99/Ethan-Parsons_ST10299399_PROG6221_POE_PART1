using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>(); // Collection of recipes
        private Recipe selectedRecipeBackup; // Backup of the selected recipe

        public MainWindow()
        {
            InitializeComponent(); // Initialize the main window
            StoredRecipesListBox.ItemsSource = recipes; // Bind the list view to the recipes collection
        }

        public class Recipe // Recipe class with properties
        {
            public string Name { get; set; } // Recipe name
            public ObservableCollection<string> Ingredients { get; set; } // Ingredients list
            public ObservableCollection<string> Instructions { get; set; } // Instructions list
            public int Calories { get; set; } // Total calories

            public Recipe() // Constructor to initialize properties
            {
                Ingredients = new ObservableCollection<string>(); // Initialize ingredients list
                Instructions = new ObservableCollection<string>(); // Initialize instructions list
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e) // Add a new recipe
        {
            Recipe newRecipe = new Recipe // Create a new recipe object
            {
                Name = RecipeNameTextBox.Text, // Set the recipe name
                Ingredients = new ObservableCollection<string>(IngredientsListBox.Items.Cast<string>()), // Set the ingredients list
                Instructions = new ObservableCollection<string>(InstructionsListBox.Items.Cast<string>()) // Set the instructions list
            };


            newRecipe.Calories = CalculateTotalCalories(newRecipe); // Calculate total calories


            recipes.Add(newRecipe); // Add the new recipe to the collection


            ClearRecipeFields(); // Clear the recipe fields
        }

        private int CalculateTotalCalories(Recipe recipe) // Calculate total calories of a recipe
        {
            int totalCalories = 0; // Initialize total calories

            foreach (string ingredient in recipe.Ingredients) // Loop through each ingredient
            {

                string[] parts = ingredient.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries); // Split the ingredient into parts

                if (parts.Length >= 4 && parts[3].ToLower() == "calories") // Check if the ingredient has calories
                {
                    if (int.TryParse(parts[2], out int calories)) // Try to parse the calories
                    {
                        totalCalories += calories; // Add the calories to the total
                    }
                }
                {
                    if (int.TryParse(parts[2], out int calories)) // Try to parse the calories
                    {
                        totalCalories += calories; // Add the calories to the total
                    }
                }
            }

            return totalCalories; // Return the total calories
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e) // Add a new ingredient
        {
            if (!string.IsNullOrWhiteSpace(IngredientTextBox.Text)) // Check if the ingredient text box is not empty
            {
                string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content.ToString(); // Get the selected food group
                string ingredient = $"{IngredientTextBox.Text} 0 calories"; // Create the ingredient string

                IngredientsListBox.Items.Add(ingredient); // Add the ingredient to the list
                IngredientTextBox.Clear(); // Clear the ingredient text box
            }
            {
                string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content.ToString(); // Get the selected food group
                string ingredient = $"{IngredientTextBox.Text} 0 calories"; // Create the ingredient string

                IngredientsListBox.Items.Add(ingredient); // Add the ingredient to the list
                IngredientTextBox.Clear(); // Clear the ingredient text box
            }
        }

        private void RemoveIngredient_Click(object sender, RoutedEventArgs e) // Remove selected ingredients
        {
            while (IngredientsListBox.SelectedItems.Count > 0) // Loop through each selected ingredient
            {
                IngredientsListBox.Items.Remove(IngredientsListBox.SelectedItems[0]); // Remove the ingredient from the list
            }
            {
                IngredientsListBox.Items.Remove(IngredientsListBox.SelectedItems[0]); // Remove the ingredient from the list
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e) // Add a new step
        {
            if (!string.IsNullOrWhiteSpace(StepTextBox.Text)) // Check if the step text box is not empty
            {
                InstructionsListBox.Items.Add(StepTextBox.Text); // Add the step to the list
                StepTextBox.Clear(); // Clear the step text box
            }
        }

        private void RemoveStep_Click(object sender, RoutedEventArgs e) // Remove selected steps
        {
            while (InstructionsListBox.SelectedItems.Count > 0) // Loop through each selected step
            {
                InstructionsListBox.Items.Remove(InstructionsListBox.SelectedItems[0]); // Remove the step from the list
            }
            {
                InstructionsListBox.Items.Remove(InstructionsListBox.SelectedItems[0]); // Remove the step from the list
            }
        }

        private void StoredRecipesListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) // Show recipe details on double click
        {
            Recipe selectedRecipe = (Recipe)StoredRecipesListBox.SelectedItem; // Get the selected recipe

            if (selectedRecipe != null) // Check if a recipe is selected
            {
                selectedRecipeBackup = selectedRecipe; // Backup the selected recipe

                DetailsRecipeName.Text = selectedRecipe.Name; // Set the recipe name

                DetailsIngredientsListBox.ItemsSource = selectedRecipe.Ingredients; // Set the ingredients list
                DetailsInstructionsListBox.ItemsSource = selectedRecipe.Instructions; // Set the instructions list

                ShowRecipeDetailsPanel(); // Show the recipe details panel
            }
        }

        private void ShowRecipeDetailsPanel() // Show the recipe details panel
        {
            HidePanels(); // Hide all panels

            RecipeDetailsPanel.Visibility = Visibility.Visible; // Show the recipe details panel
            BackToListButton.Visibility = Visibility.Visible; // Show the back to list button
        }

        private void HidePanels() // Hide all panels
        {
            RecipeDetailsPanel.Visibility = Visibility.Collapsed; // Hide the recipe details panel
            AddRecipePanel.Visibility = Visibility.Collapsed; // Hide the add recipe panel
            ScaleRecipePanel.Visibility = Visibility.Collapsed; // Hide the scale recipe panel
            ResetScalingPanel.Visibility = Visibility.Collapsed; // Hide the reset scaling panel
            ClearRecipePanel.Visibility = Visibility.Collapsed; // Hide the clear recipe panel
            FilterRecipesPanel.Visibility = Visibility.Collapsed; // Hide the filter recipes panel
        }

        private void BackToList_Click(object sender, RoutedEventArgs e) // Go back to the list view
        {
            ClearRecipeFields(); // Clear the recipe fields
            ShowListView(); // Show the list view
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e) // Clear the recipe fields
        {
            Recipe selectedRecipe = (Recipe)StoredRecipesListBox.SelectedItem; // Get the selected recipe
            if (selectedRecipe != null) // Check if a recipe is selected
            {
                recipes.Remove(selectedRecipe); // Remove the selected recipe
                ClearRecipeFields(); // Clear the recipe fields
            }
        }

        private void ClearRecipeFields() // Clear the recipe fields
        {
            RecipeNameTextBox.Clear(); // Clear the recipe name text box
            IngredientsListBox.Items.Clear(); // Clear the ingredients list box
            InstructionsListBox.Items.Clear(); // Clear the instructions list box
        }

        private void ShowListView() // Show the list view
        {
            StoredRecipesListBox.Visibility = Visibility.Visible; // Show the list view
            ActionComboBox.Visibility = Visibility.Visible; // Show the action combo box
            BackToListButton.Visibility = Visibility.Collapsed; // Hide the back to list button

            HidePanels(); // Hide all panels
        }

        private void ActionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Show the selected panel
        {
            ComboBox comboBox = (ComboBox)sender; // Get the selected combo box
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem; // Get the selected item

            HidePanels(); // Hide all panels

            switch (selectedItem.Content.ToString()) // Show the selected panel
            {
                case "Add Recipe": // Add recipe panel
                    AddRecipePanel.Visibility = Visibility.Visible; // Show the add recipe panel
                    break; // Break the switch statement
                case "Scale Recipe":
                    ScaleRecipePanel.Visibility = Visibility.Visible; // Show the scale recipe panel
                    break;
                case "Reset Scaling":
                    ResetScalingPanel.Visibility = Visibility.Visible; // Show the reset scaling panel
                    break;
                case "Clear Recipe":
                    ClearRecipePanel.Visibility = Visibility.Visible; // Show the clear recipe panel
                    break;
                case "Filter Recipes":
                    FilterRecipesPanel.Visibility = Visibility.Visible; // Show the filter recipes panel
                    break;
                default: // Default case
                    break;
            }
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e) // Scale the selected recipe
        {
            if (double.TryParse(ScaleAmountTextBox.Text, out double scale)) // Check if the scale amount is a valid number
            {
                Recipe selectedRecipe = (Recipe)StoredRecipesListBox.SelectedItem; // Get the selected recipe

                if (selectedRecipe != null) // Check if a recipe is selected
                {
                    ScaleIngredients(selectedRecipe, scale); // Scale the ingredients
                    StoredRecipesListBox.Items.Refresh(); // Refresh list view
                }
            }
            else // Invalid scale amount
            {
                MessageBox.Show("Please enter a valid scaling factor."); // Show an error message
            }

            ScaleAmountTextBox.Clear(); // Clear the scale amount text box
        }

        private void ScaleIngredients(Recipe recipe, double scale) // Scale the ingredients of a recipe
        {
            ObservableCollection<string> scaledIngredients = new ObservableCollection<string>(); // Initialize scaled ingredients list

            foreach (string ingredient in recipe.Ingredients) // Loop through each ingredient
            {
                if (ingredient.Contains("-")) // Check if the ingredient contains a dash
                {
                    string[] parts = ingredient.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries); // Split the ingredient into parts
                    if (parts.Length == 2 && double.TryParse(parts[0], out double amount)) // Check if the ingredient has two parts and the first part is a number
                    {
                        amount *= scale; // Scale the amount
                        scaledIngredients.Add($"{amount} - {parts[1]}"); // Add the scaled ingredient
                    }
                    else // Invalid format
                    {
                        scaledIngredients.Add(ingredient); // Add as is if invalid format
                    }
                }
                else // No dash found
                {
                    scaledIngredients.Add(ingredient); // Add as is if no dash found
                }
            }

            recipe.Ingredients = scaledIngredients; // Update the ingredients list
        }

        private void ResetScaling_Click(object sender, RoutedEventArgs e) // Reset the scaling of the selected recipe
        {
            Recipe selectedRecipe = (Recipe)StoredRecipesListBox.SelectedItem; // Get the selected recipe

            if (selectedRecipe != null) // Check if a recipe is selected
            {

                selectedRecipe.Ingredients = new ObservableCollection<string>(selectedRecipeBackup.Ingredients); // Reset the ingredients
                StoredRecipesListBox.Items.Refresh(); // Refresh list view
            }
        }

        private void SortRecipes_Click(object sender, RoutedEventArgs e) // Sort the recipes by name
        {
            SortRecipes(); // Sort the recipes
        }

        private void SortRecipes() // Sort the recipes by name
        {
            var sortedRecipes = new ObservableCollection<Recipe>(recipes.OrderBy(r => r.Name)); // Sort the recipes by name
            recipes.Clear(); // Clear the recipes collection

            foreach (var recipe in sortedRecipes) // Loop through each sorted recipe
            {
                recipes.Add(recipe); // Add the recipe to the collection
            }

            StoredRecipesListBox.Items.Refresh(); // Refresh list view
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e) // Apply filters to the recipes
        {
            string filterIngredient = FilterIngredientTextBox.Text.Trim().ToLower(); // Get the filter ingredient
            string filterFoodGroup = (FilterFoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(); // Get the filter food group
            int.TryParse(FilterMaxCaloriesTextBox.Text.Trim(), out int filterMaxCalories); // Get the filter max calories

            ObservableCollection<Recipe> filteredRecipes = new ObservableCollection<Recipe>(); // Initialize filtered recipes collection

            foreach (Recipe recipe in recipes) // Loop through each recipe
            {
                bool ingredientMatch = string.IsNullOrEmpty(filterIngredient) || // Check if the ingredient matches the filter
                                       recipe.Ingredients.Any(ingredient => ingredient.ToLower().Contains(filterIngredient)); // Check if the ingredient matches the filter

                bool foodGroupMatch = string.IsNullOrEmpty(filterFoodGroup) ||
                                      recipe.Ingredients.Any(ingredient => ingredient.ToLower().Contains(filterFoodGroup.ToLower())); // Check if the food group matches the filter

                bool caloriesMatch = filterMaxCalories <= 0 || recipe.Calories <= filterMaxCalories; // Check if the calories match the filter

                if (ingredientMatch && foodGroupMatch && caloriesMatch) // Check if all filters match
                {
                    filteredRecipes.Add(recipe); // Add the recipe to the filtered collection
                }
            }
            StoredRecipesListBox.ItemsSource = filteredRecipes; // Update the list view to show the filtered recipes
        }

        private void ClearFilters_Click(object sender, RoutedEventArgs e) // Clear the filters
        {
            FilterIngredientTextBox.Text = ""; // Clear the filter ingredient text box
            FilterFoodGroupComboBox.SelectedIndex = -1; // Clear the filter food group combo box
            FilterMaxCaloriesTextBox.Text = ""; // Clear the filter max calories text box

            StoredRecipesListBox.ItemsSource = recipes; 
        }
    }
}
