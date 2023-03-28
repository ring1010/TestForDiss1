namespace webapi.Models
{
    public class Production
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PprodArea { get; set; }
        public int PlantsId { get; set; }
        public Plants Plant { get; set; }
    }
}
