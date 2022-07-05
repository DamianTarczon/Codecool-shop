namespace Codecool.CodecoolShop.Models
{
    public class CartDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public CartDetails(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
    }
}
