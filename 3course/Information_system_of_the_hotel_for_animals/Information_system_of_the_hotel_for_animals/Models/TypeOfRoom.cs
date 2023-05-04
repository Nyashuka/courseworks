namespace Information_system.Models
{
    public class TypeOfRoom
    {
        public TypeOfRoom(int id, string titleOfType, double areaOfRoom, double pricePerDay)
        {
            Id = id;
            TitleOfType = titleOfType;
            AreaOfRoom = areaOfRoom;
            PricePerDay = pricePerDay;
        }

        public int Id { get; }
        public string TitleOfType { get; }
        public double AreaOfRoom { get; }
        public double PricePerDay { get; }
    }
}