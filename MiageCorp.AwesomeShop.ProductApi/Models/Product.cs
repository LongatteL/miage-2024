namespace MiageCorp.AwesomeShop.ProductApi.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
