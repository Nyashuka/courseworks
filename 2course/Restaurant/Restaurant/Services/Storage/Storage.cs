using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Storage : IStorage
    {
        public HashSet<IngredientWeight> Ingredients { get; private set; }
        public List<Dish> Menu = new List<Dish>();

        public Storage()
        {
            Ingredients = new HashSet<IngredientWeight>();
        }

        public Storage(HashSet<IngredientWeight> ingredients)
        {
            Ingredients = ingredients;
        }

        public int GetCountDishCanCook(HashSet<IngredientWeight> ingredientsList)
        {
            int totalCount = 0;

            foreach (var neenedIngredient in ingredientsList)
            {
                if (!Ingredients.Contains(neenedIngredient))
                {
                    return 0;
                }

                IngredientWeight? ingredient1;
                IngredientWeight? ingredient2;
                
                int count = 0;

                if (Ingredients.TryGetValue(neenedIngredient, out ingredient1) && 
                    ingredientsList.TryGetValue(neenedIngredient, out ingredient2))
                {
                    count = Convert.ToInt32(Math.Floor(ingredient1.Weight.Amount / ingredient2.Weight.Amount));
                }                     

                if (count <= 0)
                    return 0;

                if (totalCount == 0)
                    totalCount = count;
                else
                    totalCount = count < totalCount ? count : totalCount;  
            }

            return totalCount;
        }

        public void DecreaseIngredients(HashSet<IngredientWeight> recipe)
        {
            foreach (var currentIngredient in recipe)
            {
                IngredientWeight? ingredient;          
                
                if (Ingredients.TryGetValue(currentIngredient, out ingredient))
                {
                    ingredient.DecreaseWeight(currentIngredient.Weight);
                }
            }
            
        }

        public void IncreaseIngredients(HashSet<IngredientWeight> recipe)
        {
            foreach (var currentIngredient in recipe)
            {
                IngredientWeight? ingredient;
                if (Ingredients.TryGetValue(currentIngredient, out ingredient))
                {
                    ingredient.IncreaseWeight(currentIngredient.Weight);
                }
            }
        }


    }
}
