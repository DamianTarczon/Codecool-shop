using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Dictionary<Product, int> ListOfProducts { get; set; }

        /*public ICollection<ProductDetails> ListOfProducts { get; set; }*/

        public List<OrderDetails> ProductsDetails { get; set; }

        public Cart()
        {
            ListOfProducts = new Dictionary<Product, int>();
        }

        public void MakeProductsDetails(Dictionary<Product, int> orderedProducts)
        {
            ProductsDetails = new List<OrderDetails>();
            foreach (var product in orderedProducts)
            {
                var singleOrderDetails = new OrderDetails(product.Key.Id, product.Key.Name, product.Key.DefaultPrice,
                    product.Value);
                ProductsDetails.Add(singleOrderDetails);
            }
        }
    }
}
