namespace Restaurant
{
    public class DishCountAdapter : IAdapter<DishCount, DishCountDTO>
    {
        public DishCountDTO ConvertToDTO(DishCount model)
        {
            IAdapter<Dish, DishDTO> adapter = new DishAdapter();

            return new DishCountDTO() { Dish = adapter.ConvertToDTO(model.Dish), Count = model.Count };
        }

        public DishCount ConvertToModel(DishCountDTO dto)
        {
            IAdapter<Dish, DishDTO> adapter = new DishAdapter();

            return new DishCount(adapter.ConvertToModel(dto.Dish), dto.Count);
        }
    }
}