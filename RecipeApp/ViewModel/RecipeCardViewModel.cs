using RecipeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeApp.ViewModel
{
    public class RecipeCardViewModel : ViewModelBase
    {
        public Recipe Recipe { get; set; }

        private ICommand _showRecipeListCommand;
        public ICommand ShowRecipeListCommand
        {
            get => _showRecipeListCommand;
            set
            {
                _UpdateField(ref _showRecipeListCommand, value);
            }
        }

    }
}
