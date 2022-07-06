using System.Collections.Generic;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos
{
    public interface ICartDao
    {
        public Dictionary<Product, int> GetAll(int id);

        public Cart AddCart(Cart cart);
        public Cart IncreaseProduct(Product product, int id);
        public Cart? DecreaseProduct(Product product, int id);
        public Cart RemoveProduct(Product product, int id);
        public Cart RemoveAllProducts(int id);
    }
}
