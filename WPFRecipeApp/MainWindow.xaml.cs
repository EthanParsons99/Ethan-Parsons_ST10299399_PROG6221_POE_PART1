using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        private Recipe selectedRecipeBackup;

        public MainWindow()
        {
            InitializeComponent();
            StoredRecipesListBox.ItemsSource = recipes;
        }

        public class Recipe
        {
            public string Name { get; set; }
            public ObservableCollection<string> Ingredients { get; set; }
            public ObservableCollection<string> Instructions { get; set; }
            public int Calories { get; set; }

            public Recipe()
            {
                Ingredients = new ObservableCollection<string>();
                Instructions = new ObservableCollection<string>();
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe newRecipe = new Recipe
            {
                Name = RecipeNameTextBox.Text,
                Ingredients = new ObservableCollection<string>(IngredientsListBox.Items.Cast<string>()),
                Instructions = new ObservableCollection<string>(InstructionsListBox.Items.Cast<string>())
            };

            // Calculate total calories
            newRecipe.Calories = CalculateTotalCalories(newRecipe);

            // Add the new recipe to the recipes collection
            recipes.Add(newRecipe);

            // Clear the input fields and reset UI
            ClearRecipeFields();
        }

        private int CalculateTotalCalories(Recipe recipe)
        {
            int totalCalories = 0;

            foreach (string ingredient in recipe.Ingredients)
            {
                // Example: "100 - ml water 0 calories"
                string[] parts = ingredient.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 4 && parts[3].ToLower() == "calories")
                {
                    if (int.TryParse(parts[2], out int calories))
                    {
                        totalCalories += calories;
                    }
                }
            }

            return totalCalories;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IngredientTextBox.Text))
            {
                string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content.ToString();
                string ingredient = $"{IngredientTextBox.Text} 0 calories"; // Example format

                IngredientsListBox.Items.Add(ingredient);
                IngredientTextBox.Clear();
            }
        }

        private void RemoveIngredient_Click(object sender, RoutedEventArgs e)
        {
            while (IngredientsListBox.SelectedItems.Count > 0)
            {
                IngredientsListBox.Items.Remove(IngredientsListBox.SelectedItems[0]);
            }
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                InstructionsListBox.Items.Add(StepTextBox.Text);
                StepTextBox.Clear();
            }
        }

        private void RemoveStep_Click(object sender, RoutedEventArgs e)
        {
            while (InstructionsListBox.SelectedItems.Count > 0)
            {
                InstructionsListBox.Items.Remove(InstructionsListBox.SelectedItems[0]);
            }
        }

        private void StoredRecipesListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)StoredRecipesListBox.SelectedItem;

            if (selectedRecipe != null)
            {
                selectedRecipeBackup = selectedRecipe;

                // Display details in RecipeDetailsPanel
                DetailsRecipeName.Text = selectedRecipe.Name;

                DetailsIngredientsListBox.ItemsSource = selectedRecipe.Ingredients;
                DetailsInstructionsListBox.ItemsSource = selectedRecipe.Instructions;

                // Show RecipeDetailsPanel
                ShowRecipeDetailsPanel();
            }
        }

        private void ShowRecipeDetailsPanel()
        {
            // Hide all action panels
            HidePanels();

            // Show RecipeDetailsPanel and BackToListButton
            RecipeDetailsPanel.Visibility = Visibility.Visible;
            BackToListButton.Visibility = Visibility.Visible;
        }

        private void HidePanels()
        {
            // Hide all panels
            RecipeDetailsPanel.Visibility = Visibility.Collapsed;
            AddRecipePanel.Visibility = Visibility.Collapsed;
            ScaleRecipePanel.Visibility = Visibility.Collapsed;
            ResetScalingPanel.Visibility = Visibility.Collapsed;
            ClearRecipePanel.Visibility = Visibility.Collapsed;
            FilterRecipesPanel.Visibility = Visibility.Collapsed;
        }

        private void BackToList_Click(object sender, RoutedEventArgs e)
        {
            // Clear details and show list view
            ClearRecipeFields();
            ShowListView();
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)StoredRecipesListBox.SelectedItem;
            if (selectedRecipe != null)
            {
                recipes.Remove(selectedRecipe);
                ClearRecipeFields();
            }
        }

        private void ClearRecipeFields()
        {
            RecipeNameTextBox.Clear();
            IngredientsListBox.Items.Clear();
            InstructionsListBox.Items.Clear();
        }

        private void ShowListView()
        {
            // Show the list view and hide other panels
            StoredRecipesListBox.Visibility = Visibility.Visible;
            ActionComboBox.Visibility = Visibility.Visible;
            BackToListButton.Visibility = Visibility.Collapsed;

            HidePanels();
        }

        private void ActionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            HidePanels(); // Hide all panels first

            switch (selectedItem.Content.ToString())
            {
                case "Add Recipe":
                    AddRecipePanel.Visibility = Visibility.Visible;
                    break;
                case "Scale Recipe":
                    ScaleRecipePanel.Visibility = Visibility.Visible;
                    break;
                case "Reset Scaling":
                    ResetScalingPanel.Visibility = Visibility.Visible;
                    break;
                case "Clear Recipe":
                    ClearRecipePanel.Visibility = Visibility.Visible;
                    break;
                case "Filter Recipes":
                    FilterRecipesPanel.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ScaleAmountTextBox.Text, out double scale))
            {
                Recipe selectedRecipe = (Recipe)StoredRecipesListBox.SelectedItem;

                if (selectedRecipe != null)
                {
                    ScaleIngredients(selectedRecipe, scale);
                    StoredRecipesListBox.Items.Refresh(); // Refresh list view
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid scaling factor.");
            }

            ScaleAmountTextBox.Clear();
        }

        private void ScaleIngredients(Recipe recipe, double scale)
        {
            ObservableCollection<string> scaledIngredients = new ObservableCollection<string>();

            foreach (string ingredient in recipe.Ingredients)
            {
                if (ingredient.Contains("-"))
                {
                    string[] parts = ingredient.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2 && double.TryParse(parts[0], out double amount))
                    {
                        amount *= scale;
                        scaledIngredients.Add($"{amount} - {parts[1]}");
                    }
                    else
                    {
                        scaledIngredients.Add(ingredient); // Add as is if format is not recognized
                    }
                }
                else
                {
                    scaledIngredients.Add(ingredient); // Add as is if no "-" found
                }
            }

            recipe.Ingredients = scaledIngredients;
        }

        private void ResetScaling_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)StoredRecipesListBox.SelectedItem;

            if (selectedRecipe != null)
            {
                // Restore original ingredients
                selectedRecipe.Ingredients = new ObservableCollection<string>(selectedRecipeBackup.Ingredients);
                StoredRecipesListBox.Items.Refresh(); // Refresh list view
            }
        }

        private void SortRecipes_Click(object sender, RoutedEventArgs e)
        {
            SortRecipes();
        }

        private void SortRecipes()
        {
            var sortedRecipes = new ObservableCollection<Recipe>(recipes.OrderBy(r => r.Name));
            recipes.Clear();

            foreach (var recipe in sortedRecipes)
            {
                recipes.Add(recipe);
            }

            StoredRecipesListBox.Items.Refresh(); // Refresh list view
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve filter criteria
            string filterIngredient = FilterIngredientTextBox.Text.Trim().ToLower();
            string filterFoodGroup = (FilterFoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            int.TryParse(FilterMaxCaloriesTextBox.Text.Trim(), out int filterMaxCalories);

            // Apply filters
            ObservableCollection<Recipe> filteredRecipes = new ObservableCollection<Recipe>();

            foreach (Recipe recipe in recipes)
            {
                bool ingredientMatch = string.IsNullOrEmpty(filterIngredient) ||
                                       recipe.Ingredients.Any(ingredient => ingredient.ToLower().Contains(filterIngredient));

                bool foodGroupMatch = string.IsNullOrEmpty(filterFoodGroup) ||
                                      recipe.Ingredients.Any(ingredient => ingredient.ToLower().Contains(filterFoodGroup.ToLower()));

                bool caloriesMatch = filterMaxCalories <= 0 || recipe.Calories <= filterMaxCalories;

                if (ingredientMatch && foodGroupMatch && caloriesMatch)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            // Update the list view with filtered recipes
            StoredRecipesListBox.ItemsSource = filteredRecipes;
        }

        private void ClearFilters_Click(object sender, RoutedEventArgs e)
        {
            // Clear all filter inputs
            FilterIngredientTextBox.Text = "";
            FilterFoodGroupComboBox.SelectedIndex = -1;
            FilterMaxCaloriesTextBox.Text = "";

            // Reset the list view to show all recipes
            StoredRecipesListBox.ItemsSource = recipes;
        }
    }
}
