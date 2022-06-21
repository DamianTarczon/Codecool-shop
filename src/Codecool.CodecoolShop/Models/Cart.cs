using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class Cart
    {
        public Dictionary<Product, int> ListOfProducts { get; set; } = new Dictionary<Product, int>();
    }
}
