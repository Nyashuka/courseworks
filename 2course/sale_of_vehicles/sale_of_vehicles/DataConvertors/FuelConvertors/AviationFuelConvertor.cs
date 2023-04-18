namespace sale_of_vehicles
{
    public class AviationFuelConvertor : IDataConvertor<AviationFuel, AviationFuelDTO>
    {
        public AviationFuelDTO ConvertToDTO(AviationFuel model)
        {
            return new AviationFuelDTO(model.Id, model.Name);
        }

        public AviationFuel ConvertToModel(AviationFuelDTO dto)
        {
            return new AviationFuel(dto.Id, dto.Name);
        }
    }
}