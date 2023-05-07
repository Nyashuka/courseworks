namespace Information_system.Models
{
    public class Service
    {
        public Service(int id, int typeOfServiceId, int? employeeId, string titleOfService, double pricePerDay)
        {
            Id = id;
            TypeOfServiceId = typeOfServiceId;
            EmployeeId = employeeId;
            TitleOfService = titleOfService;
            PricePerDay = pricePerDay; 
        }

        public int Id { get; }
        public int TypeOfServiceId { get; }
        public int? EmployeeId { get; }
        public string TitleOfService { get; }
        public double PricePerDay { get; }
    }
}