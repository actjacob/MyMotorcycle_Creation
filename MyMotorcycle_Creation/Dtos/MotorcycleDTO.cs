using System.ComponentModel.DataAnnotations.Schema;

namespace MyMotorcycle_Creation.Dtos
{
    public class MotorcycleDTO
    {

        public string Brand { get; set; }
        public string Model { get; set; }
        public string ModelYar { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
    }
}
