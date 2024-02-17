using MiageCorp.AwesomeShop.ProductApi.Models;

namespace MiageCorp.AwesomeShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 1",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 20d },
            new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 12d },
            new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 3",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 99.99d },
            new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 4",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 5d },
            new Product() { Id = Guid.NewGuid().ToString(), Label = "Produit 5",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Price = 55.55d }
        };

        public Product AddProduct(Product product)
        {
            var p = GetProductById(product.Id);
            if (p == null)
            {
                p = new Product()
                {
                    Label = product.Label,
                    Description = product.Description,
                    Price = product.Price
                };
                _products.Add(p);
            }
            else
            {
                UpdateProduct(p.Id, product);
                return product;
            }
            return p;

        }

        public void DeleteProduct(string id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public Product? GetProductById(string id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void UpdateProduct(string id, Product product)
        {
            var p = GetProductById(id);
            p.Label = product.Label;
            p.Description = product.Description;
            p.Price = product.Price;
        }
    }
}
