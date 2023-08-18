using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class IngredientWeightAdapter : IAdapter<IngredientWeight, IngredientWeightDTO>
    {
        public IngredientWeightDTO ConvertToDTO(IngredientWeight model)
        {
            IAdapter<Ingredient, IngredientDTO> ingredientAdapter = new IngredientAdapter();
            IAdapter<Weight, WeightDTO> weightAdapter = new WeightAdapter();

            return new IngredientWeightDTO()
            {
                Ingredient = ingredientAdapter.ConvertToDTO(model.Ingredient),
                Weight = weightAdapter.ConvertToDTO(model.Weight)
            };
        }

        public IngredientWeight ConvertToModel(IngredientWeightDTO dto)
        {
            IAdapter<Ingredient, IngredientDTO> ingredientAdapter = new IngredientAdapter();
            IAdapter<Weight, WeightDTO> weightAdapter = new WeightAdapter();

            return new IngredientWeight(ingredientAdapter.ConvertToModel(dto.Ingredient),
                                        weightAdapter.ConvertToModel(dto.Weight));
        }
    }
}
