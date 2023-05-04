namespace Information_system.Models
{
    public class TypeOfService
    {
        public TypeOfService(int id, string titleOfServiceType)
        {
            Id = id;
            TitleOfServiceType = titleOfServiceType;
        }

        public int Id { get; }
        public string TitleOfServiceType { get; }
    }
}