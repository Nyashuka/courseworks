using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Dish : DishBase
    {
        public double PricePerServing { get; private set; }
        public Weight WeightInOneServing { get; private set; }
        public HashSet<IngredientWeight> Recipe { get; private set; }  

        public Dish(Guid id, string name, double pricePerServing, Weight weightInOneServing) : base(id, name)
        {
            Recipe = new HashSet<IngredientWeight>();
            WeightInOneServing = weightInOneServing;
            PricePerServing = pricePerServing;
        }

        public Dish(Guid id, string name, double pricePerServing, Weight weightInOneServing, HashSet<IngredientWeight> recipe) : this(id, name, pricePerServing, weightInOneServing)
        {
            Recipe = recipe;
        }

        public void DeleteIngredient(IngredientWeight ingredient)
        {
            Recipe.Remove(ingredient);
        }

        public void ChangeWeightNeededIngredient(IngredientWeight ingredient)
        {
            if (Recipe.Contains(ingredient))
            {
                Recipe.Remove(ingredient);
                Recipe.Add(ingredient);
            }
        }

        public void AddIngredientInRecipe(IngredientWeight ingredient)
        {
            if(!Recipe.Contains(ingredient))
            {
                Recipe.Add(ingredient);
            }
        }

        public string RecipeToString()
        {
            string recipe = string.Empty;
            int counter = 0;

            foreach (var ingredient in Recipe)
            {
                recipe += $"{ingredient.Ingredient.Name} - {ingredient.Weight.Amount}гр.{(counter == Recipe.Count - 1 ? "" : "\n")}";
                counter++;
            }

            return recipe;
        }
    }
}
