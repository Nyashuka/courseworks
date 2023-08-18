using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderAdapter : IAdapter<Order, OrderDTO>
    {
        public OrderDTO ConvertToDTO(Order model)
        {
            IAdapter<DateTimeContainer, DateTimeContainerDTO> dateTimeAdapter = new DateTimeContainerAdapter();
            IAdapter<DishCount, DishCountDTO> dishCountAdapter = new DishCountAdapter();

            OrderDTO dto = new OrderDTO();

            dto.Date = dateTimeAdapter.ConvertToDTO(model.Date);

            foreach(var dish in model.Dishes)
            {
                dto.Dishes.Add(dishCountAdapter.ConvertToDTO(dish));
            }

            return dto;
        }

        public Order ConvertToModel(OrderDTO dto)
        {
            IAdapter<DateTimeContainer, DateTimeContainerDTO> dateTimeAdapter = new DateTimeContainerAdapter();
            IAdapter<DishCount, DishCountDTO> dishCountAdapter = new DishCountAdapter();

            Order model = new Order(dateTimeAdapter.ConvertToModel(dto.Date));

            foreach (var dish in dto.Dishes)
            {
                model.AddDish(dishCountAdapter.ConvertToModel(dish));
            }

            return model;
        }
    }
}
