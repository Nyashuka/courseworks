using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class StorageAdapter : IAdapter<Storage, StorageDTO>
    {
        public StorageDTO ConvertToDTO(Storage model)
        {
            IAdapter<Dish, DishDTO> dishAdapter = new DishAdapter();
            IAdapter<IngredientWeight, IngredientWeightDTO> recipeAdapter = new IngredientWeightAdapter();

            StorageDTO storageDTO = new StorageDTO();

            foreach (var item in model.Ingredients)
            {
                storageDTO.Ingredients.Add(recipeAdapter.ConvertToDTO(item));
            }

            foreach (var item in model.Menu)
            {
                storageDTO.Menu.Add(dishAdapter.ConvertToDTO(item));
            }

            return storageDTO;
        }

        public Storage ConvertToModel(StorageDTO dto)
        {
            IAdapter<Dish, DishDTO> dishAdapter = new DishAdapter();
            IAdapter<IngredientWeight, IngredientWeightDTO> recipeAdapter = new IngredientWeightAdapter();

            Storage storage = new Storage();

            foreach (var item in dto.Ingredients)
            {
                storage.Ingredients.Add(recipeAdapter.ConvertToModel(item));
            }

            foreach(var dish in dto.Menu)
            {
                storage.Menu.Add(dishAdapter.ConvertToModel(dish));
            }

            return storage;
        }
    }
}
