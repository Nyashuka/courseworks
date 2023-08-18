using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class DishAdapter : IAdapter<Dish, DishDTO>
    {
        public DishDTO ConvertToDTO(Dish model)
        {
            IAdapter<Weight, WeightDTO> adapterWeight = new WeightAdapter();
            IAdapter<IngredientWeight, IngredientWeightDTO> recipeAdapter = new IngredientWeightAdapter();

            DishDTO dto = new DishDTO();

            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.WeightInOneServing = adapterWeight.ConvertToDTO(model.WeightInOneServing);
            dto.PricePerServing = model.PricePerServing;

            foreach(var item in model.Recipe)
            {
                dto.Recipe.Add(recipeAdapter.ConvertToDTO(item));
            }

            return dto;
        }

        public Dish ConvertToModel(DishDTO dto)
        {
            IAdapter<Weight, WeightDTO> adapterWeight = new WeightAdapter();
            IAdapter<IngredientWeight, IngredientWeightDTO> recipeAdapter = new IngredientWeightAdapter();

            Dish model = new Dish(dto.Id, dto.Name, dto.PricePerServing, adapterWeight.ConvertToModel(dto.WeightInOneServing));       

            foreach (var item in dto.Recipe)
            {
                model.AddIngredientInRecipe(recipeAdapter.ConvertToModel(item));
            }

            return model;
        }
    }
}
