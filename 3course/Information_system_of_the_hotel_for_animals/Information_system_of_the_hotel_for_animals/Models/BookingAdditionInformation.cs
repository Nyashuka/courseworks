namespace Information_system.Models
{
    public class BookingAdditionInformation
    {
        public BookingAdditionInformation(int id, int bookingId, string breadOfAnimal, string infoAboutAnimalHealth, string infoAboutSpecialNeeds)
        {
            Id = id;
            BookingId = bookingId;
            BreadOfAnimal = breadOfAnimal;
            InfoAboutAnimalHealth = infoAboutAnimalHealth;
            InfoAboutSpecialNeeds = infoAboutSpecialNeeds;
        }

        public int Id { get; }
        public int BookingId { get; }
        public string BreadOfAnimal { get; }
        public string InfoAboutAnimalHealth { get; }
        public string InfoAboutSpecialNeeds { get; }
    }
}