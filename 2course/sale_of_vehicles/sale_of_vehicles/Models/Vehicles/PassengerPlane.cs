using sale_of_vehicles.Models.Abstract;
using System;

namespace sale_of_vehicles
{
    public class PassengerPlane : Plane, IInformationDetails
    {
        public PassengerPlane(Guid id, string name, string model, double price, int numberOfSeats, FuelType fuelType, IFunctionality functionality) :
                                base(id, name, model, price, numberOfSeats, fuelType, functionality)
        {

        }

        public string GetInformation()
        {
            return $"Type: Passenger Plane\n" +
                   $"Name: {Name}\n" +
                   $"Price: ${Price}\n" +
                   $"Number of seats: {NumberOfSeats}pcs.\n" +
                   $"Fuel type: Aviation's fuel: {FuelType.Name}\n" +
                   $"Functionality State: {(Functionality.IsNormalFunctionality() ? FunctionalyState.Good.ToString() : FunctionalyState.Bad.ToString())}";
        }
    }
}
