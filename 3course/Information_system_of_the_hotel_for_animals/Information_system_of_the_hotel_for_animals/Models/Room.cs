namespace Information_system.Models
{
    public class Room
    {
        public Room(int id, int typeOfRoomId, int numberOfRoom)
        {
            Id = id;
            TypeOfRoomId = typeOfRoomId;
            NumberOfRoom = numberOfRoom;
        }

        public int Id { get; }
        public int TypeOfRoomId { get; }
        public int NumberOfRoom { get; }
    }
}