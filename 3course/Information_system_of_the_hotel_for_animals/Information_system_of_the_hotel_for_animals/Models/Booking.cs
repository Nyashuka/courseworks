using System;

namespace Information_system.Models
{
    public class Booking
    {
        public Booking(int id, int roomId, string tenantFullName, string tenantPhoneNumber, double priceOfBooking, DateTime dateOfStart, DateTime dateOfEnd)
        {
            Id = id;
            RoomId = roomId;
            TenantFullName = tenantFullName;
            TenantPhoneNumber = tenantPhoneNumber;
            PriceOfBooking = priceOfBooking;
            DateOfStart = dateOfStart;
            DateOfEnd = dateOfEnd;
        }

        public int Id { get; }
        public int RoomId { get; }
        public string TenantFullName { get; }
        public string TenantPhoneNumber { get; }
        public double PriceOfBooking { get; }
        public DateTime DateOfStart { get; }
        public DateTime DateOfEnd { get; }
        
    }
}