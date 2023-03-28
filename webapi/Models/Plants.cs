using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("plats")]
    public class Plants
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
       
        public  int CountryId { get; set; }
        public Countries Country { get; set; }
        public string Description { get; set; } = string.Empty;
        public int TimeZone { get; set; }
        public List<Production> Productions { get; set; }


    }
}
