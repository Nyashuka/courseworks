namespace Information_system.Models
{
    public class Tenant
    {
        public Tenant(int id, string fullName, string phoneNumber)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }
    }
}