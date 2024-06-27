using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RecipeApp.Models
{
    public class Ingredient : INotifyPropertyChanged
    {
        private string _name;
        private double _quantity;
        private string _unit;
        private double _calories;
        private string _foodGroup;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public double Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(); }
        }

        public string Unit
        {
            get => _unit;
            set { _unit = value; OnPropertyChanged(); }
        }

        public double Calories
        {
            get => _calories;
            set { _calories = value; OnPropertyChanged(); }
        }

        public string FoodGroup
        {
            get => _foodGroup;
            set { _foodGroup = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}

