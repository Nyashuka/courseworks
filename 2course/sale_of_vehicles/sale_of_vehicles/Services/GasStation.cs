using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_of_vehicles
{
    public class GasStation
    {
        public List<FuelType> Fuels { get; private set; }

        public GasStation(List<FuelType> fuels)
        {
            Fuels = fuels;
        }

        public void AddFuel(FuelType obj)
        {
            Fuels.Add(obj);
        }

        public List<FuelType> GetCarFuels()
        {
            List<FuelType> fuels = new List<FuelType>();

            foreach (var fuel in Fuels)
            {
                if(fuel is CarFuel)
                {
                    fuels.Add((CarFuel)fuel);
                }
            }

            return fuels;
        }

        public List<FuelType> GetPlaneFuels()
        {
            List<FuelType> fuels = new List<FuelType>();

            foreach (var fuel in Fuels)
            {
                if (fuel is AviationFuel)
                {
                    fuels.Add((AviationFuel)fuel);
                }
            }

            return fuels;
        }

        
    }
}
