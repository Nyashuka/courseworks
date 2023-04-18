using System;

namespace sale_of_vehicles
{
    public class Car : Vehicle
    {
        public Car(Guid id, string name, string model, double price, int numberOfSeats, FuelType fuelType, IFunctionality functionality)
                   : base(id, name, model, price, numberOfSeats, fuelType, functionality)
        {

        }

        public override bool CheckFunctionality()
        {
            return Functionality.IsNormalFunctionality();
        }
    }
}
