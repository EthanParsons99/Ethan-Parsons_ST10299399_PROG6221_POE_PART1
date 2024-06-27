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

        private int CalculateTotalCalories(Recipe recipe)
        {
            int totalCalories = 0;


        }

    }

}