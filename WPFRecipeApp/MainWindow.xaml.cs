using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Collections.ObjectModel;


namespace WPFRecipeApp
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
            public ObservableCollection<string> Steps { get; set; }

            public int Calories { get; set; }   

            public Recipe()
            {

               Ingredients = new ObservableCollection<string>();
                Steps = new ObservableCollection<string>();
            }
        }


        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe newRecipe = new Recipe
            {
                Name = RecipeNameTextBox.Text,
                Ingredients = new ObservableCollection<string>(IngredientsListBox.Items.Cast<string>()),
                Steps = new ObservableCollection<string>(StepsListBox.Items.Cast<string>())
            };

            newRecipe.Calories = CalculateTotalCalories(newRecipe);

            recipes.Add(newRecipe);

            ClearRecipePanel();

        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
           if (!string.IsNullOrWhiteSpace(IngredientTextBox.Text))
            {
                string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content.ToString();
                string ingredient = $"{IngredientTextBox.Text} 0 calories";
                IngredientsListBox.Items.Add(IngredientTextBox.Text);
                IngredientTextBox.Clear();
            }
        }

        private void RemoveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            while (IngredientsListBox.SelectedItems.Count > 0)
            {
                IngredientsListBox.Items.Remove(IngredientsListBox.SelectedItems[0]);
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                StepsListBox.Items.Add(StepTextBox.Text);
                StepTextBox.Clear();
            }
        }

        private void RemoveStepButton_Click(object sender, RoutedEventArgs e)
        {
            while (StepsListBox.SelectedItems.Count > 0)
            {
                StepsListBox.Items.Remove(StepsListBox.SelectedItems[0]);
            }
        }

        private int CalculateTotalCalories(Recipe recipe)
        {
            int totalCalories = 0;

            foreach (string ingredient in recipe.Ingredients)
            {
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




    }

}