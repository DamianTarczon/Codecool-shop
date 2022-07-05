using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;


namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class CartDao : ICartDao
    {
        private Cart _data = new Cart();
        private static CartDao _instance = null;
        private readonly CodecoolShopContext _context;

        /*public CartDao(CodecoolShopContext context)
        {
            _context = context;
        }*/

        public static CartDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CartDao();
            }

            return _instance;
        }


        public Dictionary<Product,int> GetAll()
        {
            /*var itemList = _context.Carts.Include(x => x.Id == id).Select(x=>x.CartDetails);*/
            var productDict = new Dictionary<Product, int>();
            foreach (var product in _data.CartDetails)
            {
                if (productDict.ContainsKey(product))
                {
                    productDict[product]++;
                }
                else 
                    productDict.Add(product, 1);
            }
            return productDict;
        }

        public void IncreaseProduct(Product product)
        {
            _data.CartDetails.Add(product);
        }

        public void DecreaseProduct(Product product)
        {
            _data.CartDetails.Remove(product);

        }

        public void RemoveProduct(Product product)
        {
            while (_data.CartDetails.Contains(product))
            {
                _data.CartDetails.Remove(product);
            }
        }

        public void RemoveAllProducts()
        {
            _data.CartDetails.Clear();
        }
    }
}
