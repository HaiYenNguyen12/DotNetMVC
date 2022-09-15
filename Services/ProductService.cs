using ProductManager.Models;
using Microsoft.EntityFrameworkCore;
 
namespace ProductManager.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void deleteProduct(int id)
        {
            var existProduct = GetProductById(id);
            if (existProduct == null) return;
            _context.Products.Remove(existProduct);
            _context.SaveChanges();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p=>p.Id == id);

        }

        public List<Product> GetProducts()
        {
            return _context.Products
            .Include(x => x.Category)
            .ToList();
        }

        public void UpdateProduct(Product product)
        {
            var existProduct = GetProductById(product.Id);
            if(existProduct == null) return;
            existProduct.Name = product.Name;
            existProduct.Price = product.Price;
            existProduct.Quantity = product.Quantity;
            existProduct.Slug = product.Slug;
            existProduct.CategoryId = product.CategoryId;
            _context.Update(existProduct);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
