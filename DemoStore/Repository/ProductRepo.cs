using DemoStore.Models;
using Newtonsoft.Json;

namespace DemoStore.Repository
{
    public class ProductRepo : IProductRepo
    {
        EFDbContext _dbContext;
        public ProductRepo(EFDbContext dbContext) { 
          _dbContext = dbContext;
        }
        public Product GetProduct(int id)
        {
            Console.WriteLine("GetProduct: " + id);
            return _dbContext.Products.Find(id);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            Console.WriteLine("GetAllProducts");
            return _dbContext.Products;
        }

        public IEnumerable<Product> GetFilteredProducts(string? category = null, decimal? price = null)
        {
            IQueryable<Product> data = _dbContext.Products;
            
            if (category != null)
                data=   data.Where(prod => prod.Category == category);
            if (price != null)
                data = data.Where(prod => prod.Price > price);
           
            return data;
        }
        public int CreateProduct(Product newProduct)
        {
            Console.WriteLine("CreateProduct: "
            + JsonConvert.SerializeObject(newProduct));

            newProduct.Id = 0;
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            return newProduct.Id;
        }
        public void UpdateProduct(Product changedProduct)
        {
            Console.WriteLine("UpdateProduct : "
            + JsonConvert.SerializeObject(changedProduct));

            //_dbContext.Products.Update(changedProduct);
            //_dbContext.SaveChanges();

            //if (originalProduct == null)
            //{
               var originalProduct = _dbContext.Products.Find(changedProduct.Id);
            //}
            //else
            //{
            //    context.Products.Attach(originalProduct);
            //}
            originalProduct.Name = changedProduct.Name ?? String.Empty;
            originalProduct.Category = changedProduct.Category;
            originalProduct.Price = changedProduct.Price;
            _dbContext.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            Console.WriteLine("DeleteProduct: " + id);
            _dbContext.Remove(new Product { Id = id });
            _dbContext.SaveChanges();
        }

    }
}
