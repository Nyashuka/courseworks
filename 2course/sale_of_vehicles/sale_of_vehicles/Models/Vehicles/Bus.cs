using sale_of_vehicles.Models.Abstract;
using System;

namespace sale_of_vehicles
{
    public class Bus : Car, IInformationDetails
    {
        public Bus(Guid id, string name, string model, double price, int numberOfSeats, FuelType fuelType, IFunctionality functionality, int maxCapacityOfPeople)
                    : base(id, name, model, price, numberOfSeats, fuelType, functionality)
        {
            MaxCapacityOfPeople = maxCapacityOfPeople;
        }

        public int MaxCapacityOfPeople { get; private set; }

        public string GetInformation()
        {
            return $"Type: Bus\n" +
                   $"Name: {Name}\n" +
                   $"Price: ${Price}\n" +
                   $"Number of seats: {NumberOfSeats}pcs.\n" +
                   $"Max capacity of people: {MaxCapacityOfPeople}pcs.\n" +
                   $"Fuel type: Car's fuel: {FuelType.Name}\n" +
                   $"Functionality State: {(Functionality.IsNormalFunctionality() ? FunctionalyState.Good.ToString() : FunctionalyState.Bad.ToString())}";
        }
    }
}