using DemoStore.Models;

namespace DemoStore.Repository
{
    public interface IProductRepo
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetFilteredProducts(string? category = null, decimal? price = null);
        int CreateProduct(Product newProduct);
        void UpdateProduct(Product changedProduct);
        void DeleteProduct(int id);
    }
}
