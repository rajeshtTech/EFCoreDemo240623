namespace DemoStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
       // [HasDbType()]
        public decimal Price { get; set; }
  
    }
}
