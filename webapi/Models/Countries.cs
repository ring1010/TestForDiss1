using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("countries")]
    public class Countries
    {
        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; } = "";
        public string Description { get; set; }
        public string Currency   { get; set; }
        public int RegionsId { get; set; }
        public virtual Regions Regions { get; set; }
        public List<Plants> Plants { get; set; }
    }
}
