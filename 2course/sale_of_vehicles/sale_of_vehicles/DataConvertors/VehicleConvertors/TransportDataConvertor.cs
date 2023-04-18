namespace sale_of_vehicles
{
    public class TransportDataConvertor : IDataConvertor<TransportPlane, TransportPlaneDTO>
    {
        public TransportPlaneDTO ConvertToDTO(TransportPlane model)
        {
            return new TransportPlaneDTO(model.Id, model.Name, model.Model, model.Price, model.NumberOfSeats,
                                        (AviationFuel)model.FuelType, (PlaneFunctionality)model.Functionality, model.MaxWeightOfCargo, model.CargoType);
        }

        public TransportPlane ConvertToModel(TransportPlaneDTO dto)
        {
            return new TransportPlane(dto.Id, dto.Name, dto.Model, dto.Price, dto.NumberOfSeats,
                                      dto.FuelType, dto.Functionality, dto.MaxWeightOfCargo, dto.CargoType);
        }
    }
}