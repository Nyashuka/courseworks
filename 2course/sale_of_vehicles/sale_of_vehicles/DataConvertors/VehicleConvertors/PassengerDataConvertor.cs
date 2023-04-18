namespace sale_of_vehicles
{
    public class PassengerDataConvertor : IDataConvertor<PassengerPlane, PassengerPlaneDTO>
    {
        public PassengerPlaneDTO ConvertToDTO(PassengerPlane model)
        {
            return new PassengerPlaneDTO(model.Id, model.Name, model.Model, model.Price, model.NumberOfSeats,
                                        (AviationFuel)model.FuelType, (PlaneFunctionality)model.Functionality);
        }

        public PassengerPlane ConvertToModel(PassengerPlaneDTO dto)
        {
            return new PassengerPlane(dto.Id, dto.Name, dto.Model, dto.Price, dto.NumberOfSeats,
                                      dto.FuelType, dto.Functionality);
        }
    }
}