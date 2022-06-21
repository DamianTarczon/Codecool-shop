using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos
{
    public interface ICartDao
    {
        public void AddProduct(Product product);
        public void RemoveProduct(Product product);
        public void RemoveAllProducts(Product product);

    }
}
