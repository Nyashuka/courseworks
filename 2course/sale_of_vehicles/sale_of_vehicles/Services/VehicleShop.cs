using System;
using System.Collections;
using System.Collections.Generic;

namespace sale_of_vehicles
{
    public class VehiclesShop
    {
        private List<Vehicle> _vehicleList;     

        public VehiclesShop(List<Vehicle> cars)
        {
            if (cars == null)
                throw new Exception("Car list can't be a null");

            _vehicleList = cars;
        }

        public List<Vehicle> VehicleList
        {
            get
            {
                return _vehicleList;
            }
            private set
            {
                _vehicleList = value;
            }
        }

        public void AddVehicle(Vehicle car)
        {
            VehicleList.Add(car);
        }

        public void RemoveVehicle(Vehicle car)
        {
            VehicleList.Remove(car);
        }

        public List<Vehicle> GetVehiclesByFilters(List<FilterCarsDelegate> filterCars)
        {
            List<Vehicle> list = new List<Vehicle>();

            foreach (var vehicle in VehicleList)
            {
                bool canToAdd = false;

                foreach(var method in filterCars)
                {
                    canToAdd = method(vehicle);
                    if (!canToAdd)
                        break;
                }

                if(canToAdd)
                    list.Add(vehicle);
            }

            return list;
        }

    }

}
