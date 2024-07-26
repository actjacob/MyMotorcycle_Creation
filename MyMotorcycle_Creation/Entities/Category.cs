using MyMotorcycle_Creation.Model;

namespace MyMotorcycle_Creation.Entities
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; } = string.Empty;
        public int MotorcycleCount { get; set; }

        public  List<Motorcycle> Motorcycles { get; set; }
    }
}
