namespace Information_system.Models
{
    public class TenantAdditionInformation
    {
        public TenantAdditionInformation(int id, int tenantId, string breadOfAnimal, string infoAboutAnomalHealth, string infoAboutSpecialNeeds)
        {
            Id = id;
            TenantId = tenantId;
            BreadOfAnimal = breadOfAnimal;
            InfoAboutAnomalHealth = infoAboutAnomalHealth;
            InfoAboutSpecialNeeds = infoAboutSpecialNeeds;
        }

        public int Id { get; }
        public int TenantId { get; }
        public string BreadOfAnimal { get; }
        public string InfoAboutAnomalHealth { get; }
        public string InfoAboutSpecialNeeds { get; }
    }
}