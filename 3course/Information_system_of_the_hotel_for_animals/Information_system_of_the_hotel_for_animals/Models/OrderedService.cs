namespace Information_system.Models
{
    public class OrderedService
    {
        public OrderedService(int id, int bookingId, int serviceId)
        {
            Id = id;
            BookingId = bookingId;
            ServiceId = serviceId;
        }

        public int Id { get; }
        public int BookingId { get; }
        public int ServiceId { get; }
    }
}