using System;

namespace sale_of_vehicles
{
    public class PassengerPlaneDTO : VehicleDTO
    {
        public PassengerPlaneDTO(Guid id, string name, string model, double price, int numberOfSeats, AviationFuel fuelType, PlaneFunctionality functionality) : base(id, name, model, price, numberOfSeats)
        {
            FuelType = fuelType;
            Functionality = functionality;
        }

        public AviationFuel FuelType { get; set; }
        public PlaneFunctionality Functionality { get; set; }
    }
}