namespace sale_of_vehicles
{
    public class BusDataConvertor : IDataConvertor<Bus, BusDTO>
    {
        public BusDTO ConvertToDTO(Bus model)
        {
            return new BusDTO(model.Id, model.Name, model.Model,model.Price,model.NumberOfSeats, 
                        (CarFuel)model.FuelType, (CarFunctionality)model.Functionality, model.MaxCapacityOfPeople);
        }

        public Bus ConvertToModel(BusDTO dto)
        {
            return new Bus(dto.Id, dto.Name, dto.Model, dto.Price, dto.NumberOfSeats,
                           dto.FuelType, dto.Functionality, dto.MaxCapacityOfPeople);
        }
    }
}