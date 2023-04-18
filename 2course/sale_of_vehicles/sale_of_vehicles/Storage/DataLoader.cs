using System.Collections.Generic;

namespace sale_of_vehicles
{
    public class DataLoader : IDataLoader
    {
        private readonly string  _pathFuelList = "";
        private readonly string  _pathToVehicleStorage = "";

        public DataLoader(string pathFuelList, string pathToVehicle)
        {
            _pathFuelList = pathFuelList;
            _pathToVehicleStorage = pathToVehicle;
        }

        public GasStation LoadFuelData()
        {
            try
            {
                Serializator<GasStationDTO> serializator = new Serializator<GasStationDTO>(_pathFuelList);

                GasStationDTO gasStationDTO = serializator.Deserialize();

                return new GasStation(gasStationDTO.GetFuels());
            }
            catch (System.Exception)
            {
                return new GasStation(new List<FuelType>());
            }
            
        }

        public List<Vehicle> LoadVehiclesData()
        {
            try
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                Serializator<VehicleStorageDTO> serializator = new Serializator<VehicleStorageDTO>(_pathToVehicleStorage);
                VehicleStorageDTO vehicleStorage = serializator.Deserialize();

                IDataConvertor<Bus, BusDTO> busAdapter = new BusDataConvertor();
                IDataConvertor<Truck, TruckDTO> truckAdapter = new TruckDataConvertor();
                IDataConvertor<PassengerPlane, PassengerPlaneDTO> passengerPlaneAdapter = new PassengerDataConvertor();
                IDataConvertor<TransportPlane, TransportPlaneDTO> transportPlaneAdapter = new TransportDataConvertor();

                foreach (var bus in vehicleStorage.Buses)
                {
                    vehicles.Add(busAdapter.ConvertToModel(bus));
                }

                foreach (var truck in vehicleStorage.Trucks)
                {
                    vehicles.Add(truckAdapter.ConvertToModel(truck));
                }

                foreach (var plane in vehicleStorage.PassengerPlanes)
                {
                    vehicles.Add(passengerPlaneAdapter.ConvertToModel(plane));
                }

                foreach (var plane in vehicleStorage.TransportPlanes)
                {
                    vehicles.Add(transportPlaneAdapter.ConvertToModel(plane));
                }

                return vehicles;
            }
            catch (System.Exception)
            {
                return new List<Vehicle>();
            }
        }

        public void SaveFuelData(GasStation fuelTypes)
        {
            GasStationDTO gasStationDTO = new GasStationDTO();

            gasStationDTO.AddFuels(fuelTypes.Fuels);

            Serializator<GasStationDTO> serializator = new Serializator<GasStationDTO>(_pathFuelList);

            serializator.Serialize(gasStationDTO);
        }

        public void SaveVehiclesData(List<Vehicle> vehicles)
        {            
            VehicleStorageDTO vehicleStorage = new VehicleStorageDTO();

            foreach (var vehicle in vehicles)
            {
                vehicleStorage.AddVehicle(vehicle);
            }

            Serializator<VehicleStorageDTO> serializator = new Serializator<VehicleStorageDTO>(_pathToVehicleStorage);

            serializator.Serialize(vehicleStorage);
        }
    }
}
