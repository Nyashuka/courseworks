namespace Information_system.Models
{
    public class Employee
    {
        public Employee(int id, string fullName, string phoneNumber)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; }
        public string FullName { get; }
        public string PhoneNumber {get;}
    }
}