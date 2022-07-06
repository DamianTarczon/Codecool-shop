using System.Collections.Generic;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos
{
    public interface ICartDao
    {
        public Dictionary<Product, int> GetAll(int id);

        public Cart AddCart(Cart cart);
        public void IncreaseProduct(Product product, int id);
        public void DecreaseProduct(Product product, int id);
        public void RemoveProduct(Product product, int id);
        public void RemoveAllProducts(int id);
    }
}
