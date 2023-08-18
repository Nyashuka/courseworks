using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class IngredientAdapter : IAdapter<Ingredient, IngredientDTO>
    {
        public IngredientDTO ConvertToDTO(Ingredient model) => new IngredientDTO 
        { 
            Id = model.Id, 
            Name = model.Name, 
            PricePerOneKilogram = model.PricePerOneKilogram
        };

        public Ingredient ConvertToModel(IngredientDTO dto) => new Ingredient(dto.Id, dto.Name, dto.PricePerOneKilogram);
    }
}
