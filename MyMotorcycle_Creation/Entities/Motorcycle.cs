using MyMotorcycle_Creation.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMotorcycle_Creation.Entities
{
    public class Motorcycle : BaseModel
    {
        public string Brand { get; set; }       
        public string Model { get; set; }
        public string  ModelYar { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
