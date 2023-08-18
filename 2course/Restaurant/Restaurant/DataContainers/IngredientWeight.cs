using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class IngredientWeight : IEquatable<IngredientWeight>
    {  
        public Ingredient Ingredient { get; private set; }

        public Weight Weight { get; private set; }

        public IngredientWeight(Ingredient ingredient, Weight weight)
        {
            Ingredient = ingredient;
            Weight = weight;
        }

        public void DecreaseWeight(Weight weight)
        {
            Weight newWeight = Weight;

            newWeight.DecreaseWeight(weight);

            Weight = newWeight;
        }

        public void IncreaseWeight(Weight weight)
        {
            Weight newWeight = Weight;

            newWeight.IncreaseWeight(weight);

            Weight = newWeight;
        }

        public bool Equals(IngredientWeight? other)
        {
            if (other == null)
                return false;

            return Ingredient.Id.Equals(other.Ingredient.Id);
        }

        public override int GetHashCode()
        {
            return Ingredient.Id.GetHashCode();
        }
    }
}
