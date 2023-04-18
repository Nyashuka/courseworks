using sale_of_vehicles.Models.Abstract;
using System;

namespace sale_of_vehicles
{
    public class TransportPlane : Plane, IInformationDetails
    {
        public TransportPlane(Guid id, string name, string model, double price, int numberOfSeats, FuelType fuelType,
                               IFunctionality functionality, double maxWeightOfCargo, TypeOfCargo cargoType)
                              : base(id, name, model, price, numberOfSeats, fuelType, functionality)
        {
            MaxWeightOfCargo = maxWeightOfCargo;
            CargoType = cargoType;
        }

        public double MaxWeightOfCargo { get; private set; }
        public TypeOfCargo CargoType { get; private set; }

        public string GetInformation()
        {
            return $"Type: TransportPlane\n" +
                   $"Name: {Name}\n" +
                   $"Price: ${Price}\n" +
                   $"Number of seats: {NumberOfSeats}pcs.\n" +
                   $"Fuel type: Car's fuel: {FuelType.Name}\n" +
                   $"Type of Cargo: {CargoType}\n" +
                   $"Max Weight Of Cargo: {MaxWeightOfCargo}kg.\n" +
                   $"Functionality State: {(Functionality.IsNormalFunctionality() ? FunctionalyState.Good.ToString() : FunctionalyState.Bad.ToString())}";
        }
    }
}
