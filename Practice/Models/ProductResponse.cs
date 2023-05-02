namespace Practice.Models
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public dynamic Attributes { get; set; }
    }
}
