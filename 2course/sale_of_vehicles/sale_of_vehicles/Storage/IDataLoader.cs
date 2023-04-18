using System.Collections.Generic;


namespace sale_of_vehicles
{
    public interface IDataLoader
    {
        void SaveFuelData(GasStation fuelTypes);
        GasStation LoadFuelData();

        void SaveVehiclesData(List<Vehicle> vehicles);
        List<Vehicle> LoadVehiclesData(); 

    }
}
