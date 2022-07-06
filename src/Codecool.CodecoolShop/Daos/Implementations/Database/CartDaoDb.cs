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

        public Cart AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            cart.Id = _context.Carts.OrderByDescending(x => x.Id).Select(x => x.Id).First();
            return cart;

        }

        public Dictionary<Product, int> GetAll(int id)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.Id == id);
            var productsList = _context.CartDetails.Where(x => x.Cart == cart).Include(x=>x.Product);
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

        public Cart IncreaseProduct(Product product, int id)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.Id == id);
            var cartDetails = _context.CartDetails.Include(x => x.Product)
                .Where(x => x.Cart == cart);
            var productDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            var newCartDetails = new CartDetail() {Cart = cart, Product = productDb, Quantity = 1};
            if (cartDetails.Select(x => x.Product).ToList().Contains(productDb))
            {
                _context.CartDetails.Include(x=>x.Cart).Where(x=>x.Cart==cart).Where(x => x.Product == productDb).FirstOrDefault().Quantity++;
                _context.SaveChanges();
            }
            else
            {
                _context.CartDetails.Add(newCartDetails);
                _context.SaveChanges();
            }

            return cart;

        }

        public Cart? DecreaseProduct(Product product, int Id)
        {

            var productDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            Cart cart = _context.Carts.FirstOrDefault(x => x.Id == Id);
            var cartDetails = _context.Carts.Where(x=>x.Id==Id).SelectMany(x => x.CartDetails).Include(x=>x.Product).ToList();
            foreach (var cartDetail in cartDetails)
            {
                if (cartDetail.Product == productDb)
                {
                    cartDetail.Quantity--;
                    if (cartDetail.Quantity == 0)
                    {
                        cart = RemoveProduct(productDb, Id);
                        return cart;
                    }
                    break;
                }
            }
            _context.SaveChanges();
            return cart;
            
        }

        public Cart RemoveProduct(Product product, int id)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.Id == id);
            var cartDetails = _context.CartDetails.Include(x => x.Product)
                .Where(x => x.Cart == cart).ToList();
            var productDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            _context.CartDetails.Remove(_context.CartDetails.Include(x => x.Cart).Include(x => x.Product)
                .Where(x => x.Cart.Id == id).Where(x => x.Product == productDb).FirstOrDefault());
            _context.SaveChanges();
            return cart;

        }

        public Cart RemoveAllProducts(int id)
        {
            _context.CartDetails.Include(x=>x.Cart).Where(x=>x.Cart.Id==id).ToList().Clear();
            _context.SaveChanges();
            return _context.Carts.FirstOrDefault(x=>x.Id==id);
        }
    }
}
