using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_of_vehicles
{
    public class BusDTO
    {
        public BusDTO(Guid id, string name, string model, double price, int numberOfSeats, CarFuel fuelType, CarFunctionality functionality, int maxCapacityOfPeople)
        {
            Id = id;
            Name = name;
            Model = model;
            Price = price;
            NumberOfSeats = numberOfSeats;
            FuelType = fuelType;
            Functionality = functionality;
            MaxCapacityOfPeople = maxCapacityOfPeople;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int NumberOfSeats { get; set; }
        public CarFuel FuelType { get; set; }
        public CarFunctionality Functionality { get; set; }
        public int MaxCapacityOfPeople { get; set; }



    }
}
