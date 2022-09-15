using ProductManager.Models;
 
namespace ProductManager.Services
{
    public interface IProductService
    {
       List<Product> GetProducts();
       Product? GetProductById (int id);
       void CreateProduct (Product product);
       void UpdateProduct(Product product);
       void deleteProduct(int id);
       List<Category> GetCategories();


    }
}
