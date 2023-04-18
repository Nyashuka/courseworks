using System;

namespace sale_of_vehicles
{
    public class TransportPlaneDTO
    {
        public TransportPlaneDTO(Guid id, string name, string model, double price, int numberOfSeats, AviationFuel fuelType, PlaneFunctionality functionality, double maxWeightOfCargo, TypeOfCargo cargoType)
        {
            Id = id;
            Name = name;
            Model = model;
            Price = price;
            NumberOfSeats = numberOfSeats;
            FuelType = fuelType;
            Functionality = functionality;
            MaxWeightOfCargo = maxWeightOfCargo;
            CargoType = cargoType;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int NumberOfSeats { get; set; }
        public AviationFuel FuelType { get; set; }
        public PlaneFunctionality Functionality { get; set; }
        public double MaxWeightOfCargo { get; set; }
        public TypeOfCargo CargoType { get; set; }
    }
}