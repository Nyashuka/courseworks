using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class WeightAdapter : IAdapter<Weight, WeightDTO>
    {
        public WeightDTO ConvertToDTO(Weight model) => new WeightDTO() { Amount = model.Amount, Unit = model.Unit };

        public Weight ConvertToModel(WeightDTO dto) => new Weight(dto.Amount, dto.Unit);
    }
}
