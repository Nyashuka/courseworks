using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_of_vehicles
{
    public class GasStationDTO
    {
        public GasStationDTO()
        {
            CarFuels = new List<CarFuelDTO>();
            AviationFuels = new List<AviationFuelDTO>();
        }

        public List<CarFuelDTO> CarFuels { get; set; }
        public List<AviationFuelDTO> AviationFuels { get; set; }

        public void AddFuels(List<FuelType> fuels)
        {
            IDataConvertor<CarFuel, CarFuelDTO> carFuelConvertor = new CarFuelConvertor();
            IDataConvertor<AviationFuel, AviationFuelDTO> aviationFuelConvertor = new AviationFuelConvertor();

            foreach (var fuel in fuels)
            {
                if (fuel is CarFuel)
                    CarFuels.Add(carFuelConvertor.ConvertToDTO((CarFuel)fuel));
                else if (fuel is AviationFuel)
                    AviationFuels.Add(aviationFuelConvertor.ConvertToDTO((AviationFuel)fuel));
            }
        }

        public List<FuelType> GetFuels()
        {
            IDataConvertor<CarFuel, CarFuelDTO> carFuelConvertor = new CarFuelConvertor();
            IDataConvertor<AviationFuel, AviationFuelDTO> aviationFuelConvertor = new AviationFuelConvertor();

            List<FuelType> fuelTypes = new List<FuelType>();

            foreach (var item in CarFuels)
            {
                fuelTypes.Add(carFuelConvertor.ConvertToModel(item)); 
            }

            foreach (var item in AviationFuels)
            {
                fuelTypes.Add(aviationFuelConvertor.ConvertToModel(item));
            }

            return fuelTypes;
        }
    }
}
