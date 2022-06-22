using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ViewModel
    { 
        public Dictionary<Product,int> ProductsInCart { get; set; }
        public List<Product> Products { get; set; }
    }
}
