using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_of_vehicles
{
    public class VehicleDTO
    {
        public VehicleDTO(Guid id, string name, string model, double price, int numberOfSeats)
        {
            Id = id;
            Name = name;
            Model = model;
            Price = price;
            NumberOfSeats = numberOfSeats;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
