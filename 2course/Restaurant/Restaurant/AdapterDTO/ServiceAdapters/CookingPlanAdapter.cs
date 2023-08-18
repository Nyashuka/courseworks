using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class CookingPlanAdapter : IAdapter<CookingPlan, CookingPlanDTO>
    {
        public CookingPlanDTO ConvertToDTO(CookingPlan model)
        {
            IAdapter<Order, OrderDTO> adapter = new OrderAdapter();

            CookingPlanDTO cookingPlanDTO = new CookingPlanDTO();

            foreach (var order in model.Orders)
            {
                cookingPlanDTO.Orders.Add(adapter.ConvertToDTO(order));
            }

            return cookingPlanDTO;
        }

        public CookingPlan ConvertToModel(CookingPlanDTO dto)
        {
            IAdapter<Order, OrderDTO> adapter = new OrderAdapter();

            CookingPlan cookingPlan = new CookingPlan();

            foreach (var order in dto.Orders)
            {
                cookingPlan.AddOrder(adapter.ConvertToModel(order));
            }

            return cookingPlan;
        }
    }
}
