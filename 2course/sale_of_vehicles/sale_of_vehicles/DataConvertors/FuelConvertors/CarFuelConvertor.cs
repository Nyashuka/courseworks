namespace sale_of_vehicles
{
    public class CarFuelConvertor : IDataConvertor<CarFuel, CarFuelDTO>
    {
        public CarFuelDTO ConvertToDTO(CarFuel model)
        {
            return new CarFuelDTO(model.Id, model.Name);
        }

        public CarFuel ConvertToModel(CarFuelDTO dto)
        {
            return new CarFuel(dto.Id, dto.Name);
        }
    }
}