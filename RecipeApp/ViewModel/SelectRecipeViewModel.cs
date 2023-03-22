using Newtonsoft.Json;
using RecipeApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RecipeApp.ViewModel
{
    public class SelectRecipeViewModel : ViewModelBase
    {
        public static readonly string SvcIP = "www.themealdb.com/api/json/v1/1/random.php";

        public ObservableCollection<Recipe> Recipes { get; set; }

        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get
            {
                return _selectedRecipe;
            }
            set
            {
                _UpdateField(ref _selectedRecipe, value);
            }
        }

        public Recipe RandomRecipe { get; set; }

        public RecipeCardViewModel RecipeCardViewModel { get; set; }

        private ICommand _showRecipeCardViewCommand;
        public ICommand ShowRecipeCardViewCommand
        {
            get => _showRecipeCardViewCommand;
            set
            {
                _UpdateField(ref _showRecipeCardViewCommand, value);
            }
        }

        private ICommand _showRecipeCardCommand;
        public ICommand ShowRecipeCardCommand
        {
            get => _showRecipeCardCommand;
            set
            {
                _UpdateField(ref _showRecipeCardCommand, value);
            }
        }


        public void GoToRecipeView()
        {
            if (ShowRecipeCardViewCommand.CanExecute(null) && !ReferenceEquals(SelectedRecipe, null))
            {
                RecipeCardViewModel.Recipe = SelectedRecipe;

                ShowRecipeCardViewCommand.Execute(null);
            }
        }

        public SelectRecipeViewModel()
        {
            ShowRecipeCardCommand = new DelegateCommand(GoToRecipeView);

            Recipes = new ObservableCollection<Recipe>();

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string jsonPath = Path.Combine(basePath, "recipes.json");

            if (!File.Exists(jsonPath))
            {
                Console.WriteLine("JSON does not exist");
                //return new ObservableCollection<DNDClassInfo>();
                return;
            }

            string jsonContent = File.ReadAllText(jsonPath);
            Recipes = JsonConvert.DeserializeObject<ObservableCollection<Recipe>>(jsonContent);

            if (ReferenceEquals(Recipes, null))
            {
                Console.WriteLine("JSON deserialization failed");
                //return new ObservableCollection<DNDClassInfo>();
                return;
            }

            if (Recipes.Count > 0)
            {
                SelectedRecipe = Recipes[0];
            }
        }
    }
}
