using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class CartDao : ICartDao
    {
        private Cart _cart = new Cart();
        private static CartDao instance = null;

        public CartDao()
        {
        }

        public static CartDao GetInstance()
        {
            if (instance == null)
            {
                instance = new CartDao();
            }

            return instance;
        }

        public void AddProduct(Product product)
        {
            if (_cart.ListOfProducts.ContainsKey(product))
            {
                _cart.ListOfProducts[product] += 1;
            }
            else
            {
                _cart.ListOfProducts.Add(product, 1);
            }
        }

        public void RemoveProduct(Product product)
        {
            if (_cart.ListOfProducts[product] > 1)
            {
                _cart.ListOfProducts[product] -= 1;
            }
            else
            {
                _cart.ListOfProducts.Remove(product);
            }

        }

        public void RemoveAllProducts(Product product)
        {
            _cart.ListOfProducts.Remove(product);
        }
    }
}
