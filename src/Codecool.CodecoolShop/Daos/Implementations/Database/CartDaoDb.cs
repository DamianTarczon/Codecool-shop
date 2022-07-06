using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Codecool.CodecoolShop.Daos.Implementations.Database
{
    public class CartDaoDb : ICartDao
    {
        private readonly CodecoolShopContext _context;

        public CartDaoDb()
        {
            DbContextOptions<CodecoolShopContext> options = new DbContextOptions<CodecoolShopContext>();
            _context = new CodecoolShopContext(options);
        }
        public Dictionary<Product, int> GetAll(int id)
        {
            var productsList = _context.Carts.Where(x => x.Id == id).Select(x => x.CartDetails).FirstOrDefault();
            var productDict = new Dictionary<Product, int>();
            foreach (var cartDetail in productsList)
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

        public void IncreaseProduct(Product product, int id)
        {

            CartDetail cartDetail = new CartDetail() { Cart = _data, Product = product, Quantity = 1 };

            if (_data.CartDetails.Count == 0)
            {
                _data.CartDetails.Add(cartDetail);
            }
            else if (_data.CartDetails.Where(x => x.Product == product).SingleOrDefault() == null)
            { _data.CartDetails.Add(cartDetail); }
            else
                _data.CartDetails.Where(x => x.Product == product).SingleOrDefault().Quantity++;
        }
        public void DecreaseProduct(Product product);
        public void RemoveProduct(Product product);
        public void RemoveAllProducts();
    }
}
