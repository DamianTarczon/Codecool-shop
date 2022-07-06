using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations.Memory
{
    public class CartDaoMemory : ICartDao
    {
        private List<Cart> _data = new List<Cart>();
        private static CartDaoMemory _instance = null;

        public static CartDaoMemory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CartDaoMemory();
            }

            return _instance;
        }

        public Cart AddCart(Cart cart)
        {
            cart.Id = _data.Count + 1;
            _data.Add(cart);
            return cart;
        }

        public Dictionary<Product,int> GetAll(int id)
        {
            var productDict = new Dictionary<Product, int>();
            var cart = _data.Where(x => x.Id == id).FirstOrDefault();
            foreach (var cartDetail in cart.CartDetails)
            {
                if (productDict.ContainsKey(cartDetail.Product))
                {
                    productDict[cartDetail.Product] = cartDetail.Quantity;
                }
                else 
                    productDict.Add(cartDetail.Product, cartDetail.Quantity);
            }
            return productDict;
        }

        public Cart IncreaseProduct(Product product, int id)
        {
            var cart = _data.Where(x => x.Id == id).FirstOrDefault();
            CartDetail cartDetail = new CartDetail() {Cart = cart, Id = id, Product = product, Quantity = 1 };
            if (cart.CartDetails.Count == 0)
            {
                cart.CartDetails.Add(cartDetail);
            }
            else if (cart.CartDetails.Where(x => x.Product == product).SingleOrDefault()==null)
            { cart.CartDetails.Add(cartDetail); }
            else
            cart.CartDetails.Where(x => x.Product == product).SingleOrDefault().Quantity++;

            return cart;
        }

        public Cart DecreaseProduct(Product product, int id)
        {
            var cart = _data.Where(x => x.Id == id).FirstOrDefault();
            cart.CartDetails.Where(x => x.Product == product).FirstOrDefault().Quantity--;
            return cart;

        }

        public Cart RemoveProduct(Product product, int id)
        {
            var cart = _data.Where(x => x.Id == id).FirstOrDefault();
            cart.CartDetails.Remove(cart.CartDetails.Where(x => x.Product == product).FirstOrDefault());
            return cart;
        }

        public Cart RemoveAllProducts(int id)
        {
            var cart = _data.Where(x => x.Id == id).FirstOrDefault();
            cart.CartDetails.Clear();
            return cart;
        }
    }
}
