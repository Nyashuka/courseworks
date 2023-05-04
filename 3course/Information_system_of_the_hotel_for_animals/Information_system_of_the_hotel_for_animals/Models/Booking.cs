using System;

namespace Information_system.Models
{
    public class Booking
    {
        public Booking(int id, int roomId, int tenantId, double priceOfBooking, DateTime dateOfStart, DateTime dateOfEnd)
        {
            Id = id;
            RoomId = roomId;
            TenantId = tenantId;
            PriceOfBooking = priceOfBooking;
            DateOfStart = dateOfStart;
            DateOfEnd = dateOfEnd;
        }

        public int Id { get; }
        public int RoomId { get; }
        public int TenantId { get; }
        public double PriceOfBooking { get; }
        public DateTime DateOfStart { get; }
        public DateTime DateOfEnd { get; }
        
    }
}