using Task14.Core;

namespace Task14.Services
{
    public class ProductService
    {
        [AuditLog("Creates a new product")]
        public void CreateProduct(Product product)
        {
            Console.WriteLine($"Product created: {product.Name}");
        }

        [AuditLog("Deletes a product")]
        public void DeleteProduct(int id)
        {
            Console.WriteLine($"Product deleted: {id}");
        }

        public void GetProduct(int id)
        {
            Console.WriteLine($"Getting product: {id}");
        }
    }
}