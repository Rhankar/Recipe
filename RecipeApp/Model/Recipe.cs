using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Model
{
    public class Recipe
    {
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public int NumberPeopleServed { get; set; }
        public RecipeDifficulty Difficulty { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public List<string> PreparationSteps { get; set; }
    }

    public class RecipeIngredient
    {
        public string Name { get; set; }
        public string Quantity { get; set; }

        public override string ToString()
        {
            return Quantity + " " + Name;
        }
    }

    public enum MealType
    {
        Breakfast,
        Lunch,
        Supper,
        Snack,
    }

    public enum RecipeDifficulty
    {
        Beginner,
        Intermediate,
        Advanced,
    }
}
