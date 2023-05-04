namespace Information_system.Models
{
    public class OrderedService
    {
        public OrderedService(int id, int tenantId, int serviceId)
        {
            Id = id;
            TenantId = tenantId;
            ServiceId = serviceId;
        }

        public int Id { get; }
        public int TenantId { get; }
        public int ServiceId { get; }
    }
}