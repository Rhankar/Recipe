using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private readonly SelectRecipeViewModel _selectRecipeViewModel;
        private readonly RecipeCardViewModel _recipeCardViewModel;
        //private readonly CharacterEditingViewModel _characterEditingViewModel;
        //private readonly AddClassViewModel _addClassViewModel;
        //private readonly AddRaceViewModel _addRaceViewModel;


        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel { 
            get
            {
                return _currentViewModel;
            }
            set
            {
                _UpdateField(ref _currentViewModel, value);
                //if (_currentViewModel == value) return;

                //_currentViewModel = value;
                //OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {

            _selectRecipeViewModel = new SelectRecipeViewModel();
            _recipeCardViewModel = new RecipeCardViewModel();

            _selectRecipeViewModel.RecipeCardViewModel = _recipeCardViewModel;

            _selectRecipeViewModel.ShowRecipeCardViewCommand = new DelegateCommand(() => CurrentViewModel = _recipeCardViewModel);
            _recipeCardViewModel.ShowRecipeListCommand = new DelegateCommand(() => CurrentViewModel = _selectRecipeViewModel);

            CurrentViewModel = _selectRecipeViewModel;

            
            //_characterInfoViewModel = new CharacterInfoViewModel
            //{
            //    ShowCharacterEditingCommand = new DelegateCommand(() => CurrentViewModel = _characterEditingViewModel)
            //};
            //DNDDatabaseHandler.LoadClassesJSON();
            //DNDDatabaseHandler.LoadRacesJSON();

            //_characterEditingViewModel = new CharacterEditingViewModel();
            //_characterEditingViewModel.ShowCharacterInfoCommand = new DelegateCommand(() => CurrentViewModel = _characterInfoViewModel);

            //_addClassViewModel = new AddClassViewModel();
            //_addClassViewModel.ShowCharacterInfoCommand = new DelegateCommand(() => CurrentViewModel = _characterInfoViewModel);

            //_addRaceViewModel = new AddRaceViewModel();
            //_addRaceViewModel.ShowCharacterInfoCommand = new DelegateCommand(() => CurrentViewModel = _characterInfoViewModel);

            //_characterInfoViewModel = new CharacterInfoViewModel();
            //_characterInfoViewModel.ShowCharacterEditingCommand = new DelegateCommand(() => CurrentViewModel = _characterEditingViewModel);
            //_characterInfoViewModel.ShowAddClassCommand = new DelegateCommand(() => CurrentViewModel = _addClassViewModel);

            //_characterEditingViewModel.CharInfoViewModel = _characterInfoViewModel;
            //_addClassViewModel.CharInfoViewModel = _characterInfoViewModel;
            //_addRaceViewModel.CharInfoViewModel = _characterInfoViewModel;
            //_characterInfoViewModel.CharEditingViewModel = _characterEditingViewModel;
            //_characterInfoViewModel.AddClassViewModel = _addClassViewModel;
            //_characterInfoViewModel.AddRaceViewModel = _addRaceViewModel;

            ////_characterEditingViewModel = new CharacterEditingViewModel
            ////{
            ////    ShowCharacterInfoCommand = new DelegateCommand(() => CurrentViewModel = _characterInfoViewModel)
            ////};

            ////_homeViewModel = new HomeViewModel
            ////{
            ////    ShowSub1Command = new DelegateCommand(() => CurrentViewModel = _sub1ViewModel),
            ////    ShowSub2Command = new DelegateCommand(() => CurrentViewModel = _sub2ViewModel)
            ////};

            //CurrentViewModel = _characterInfoViewModel;

            //DNDClass.RemainingLevels = 20;
        }
    }
}
