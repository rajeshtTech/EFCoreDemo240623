using DemoStore.Models;
using DemoStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private IProductRepo _prodRepo;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger, IProductRepo prodRepo)
        {
            _logger = logger;
            _prodRepo = prodRepo;
        }

        [HttpGet("GetProduct")]
        public Product Get(int prodId)
        {
            return _prodRepo.GetProduct(prodId);
        }

        [HttpGet("GetAllProducts")]
        public IEnumerable<Product> GetAllProducts()
        {
            return _prodRepo.GetAllProducts();
        }

        [HttpGet("GetFilteredProducts")]
        public IEnumerable<Product> GetFilteredProducts(string? category = null, decimal? price = null)
        {
            return _prodRepo.GetFilteredProducts(category, price);
        }

        [HttpPut()]
        public int Create(Product newProduct) {
            return _prodRepo.CreateProduct(newProduct);
        }

        [HttpPost()]
        public void Update(Product newProduct)
        {
             _prodRepo.UpdateProduct(newProduct);
        }


        [HttpDelete()]
        public void DeleteProduct(int id) => _prodRepo.DeleteProduct(id);
    }
}