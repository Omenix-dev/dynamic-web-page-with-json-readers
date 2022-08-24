using Ecommerce.Enum;

namespace Ecommerce.Model
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public decimal Price { get; set; }
        public Availability Availability { get; set; }
        public Categories Category { get; set; }
        public bool Shipping { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public Ratings Rating { get; set; }
    }
}
