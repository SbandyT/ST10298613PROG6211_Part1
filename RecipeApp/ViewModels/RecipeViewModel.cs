using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using RecipeApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OxyPlot;
using OxyPlot.Series;
using System.Linq;

namespace RecipeApp.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        // Observable collection to hold multiple recipes
        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();

        // Selected recipe from the list
        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set => SetProperty(ref _selectedRecipe, value);
        }

        // Command for adding a new recipe
        public ICommand AddRecipeCommand { get; }

        // Command for removing the selected recipe
        public ICommand RemoveRecipeCommand { get; }

        // Plot model for the food group pie chart
        private PlotModel _foodGroupPieModel;
        public PlotModel FoodGroupPieModel
        {
            get => _foodGroupPieModel;
            set => SetProperty(ref _foodGroupPieModel, value);
        }

        // Constructor to initialize commands and the pie chart model
        public RecipeViewModel()
        {
            AddRecipeCommand = new RelayCommand(AddRecipe);
            RemoveRecipeCommand = new RelayCommand(RemoveRecipe);
            FoodGroupPieModel = new PlotModel { Title = "Food Group Distribution" };
        }

        // ---------------------------- AddRecipe Method ----------------------------
        // Method to add a new recipe to the collection
        private void AddRecipe()
        {
            Recipes.Add(new Recipe { Name = "New Recipe" });
            UpdateFoodGroupPieChart();
        }

        // ---------------------------- RemoveRecipe Method ----------------------------
        // Method to remove the selected recipe from the collection
        private void RemoveRecipe()
        {
            if (SelectedRecipe != null)
            {
                Recipes.Remove(SelectedRecipe);
                UpdateFoodGroupPieChart();
            }
        }

        // ---------------------------- UpdateFoodGroupPieChart Method ----------------------------
        // Method to update the pie chart showing the distribution of food groups
        private void UpdateFoodGroupPieChart()
        {
            FoodGroupPieModel.Series.Clear();
            var pieSeries = new PieSeries();
            var foodGroups = Recipes.SelectMany(r => r.Ingredients).GroupBy(i => i.FoodGroup);

            foreach (var group in foodGroups)
            {
                pieSeries.Slices.Add(new PieSlice(group.Key, group.Sum(i => i.Calories)));
            }

            FoodGroupPieModel.Series.Add(pieSeries);
            FoodGroupPieModel.InvalidatePlot(true);
        }
    }
}

