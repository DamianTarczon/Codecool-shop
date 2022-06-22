using System.Collections.Generic;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos
{
    public interface ICartDao
    {
        public Dictionary<Product, int> GetAll();
        public void AddProduct(Product product);
        public void RemoveProduct(Product product);
        public void RemoveAllProducts(Product product);

    }
}
