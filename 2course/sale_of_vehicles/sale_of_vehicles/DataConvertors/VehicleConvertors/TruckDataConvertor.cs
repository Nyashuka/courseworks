namespace sale_of_vehicles
{
    public class TruckDataConvertor : IDataConvertor<Truck, TruckDTO>
    {
        public TruckDTO ConvertToDTO(Truck model)
        {
            return new TruckDTO(model.Id, model.Name, model.Model, model.Price, model.NumberOfSeats,
                                        (CarFuel)model.FuelType, (CarFunctionality)model.Functionality, model.MaxWeightOfCargo, model.CargoType);
        }

        public Truck ConvertToModel(TruckDTO dto)
        {
            return new Truck(dto.Id, dto.Name, dto.Model, dto.Price, dto.NumberOfSeats,
                                      dto.FuelType, dto.Functionality, dto.MaxWeightOfCargo, dto.CargoType);
        }
    }
}