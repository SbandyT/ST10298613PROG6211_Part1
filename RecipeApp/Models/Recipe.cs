using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipeApp.Models
{
    public class Recipe : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<Ingredient> _ingredients;
        private ObservableCollection<string> _steps;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get => _ingredients;
            set { _ingredients = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Steps
        {
            get => _steps;
            set { _steps = value; OnPropertyChanged(); }
        }

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Steps = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
    

