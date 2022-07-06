using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Daos.Implementations.Database
{
    public class OrderDaoDb : IOrderDao
    {
        private readonly CodecoolShopContext _context;

        public OrderDaoDb()
        {
            DbContextOptions<CodecoolShopContext> options = new DbContextOptions<CodecoolShopContext>();
            _context = new CodecoolShopContext(options);
        }

        public List<Order> GetAll()
        {
            return _context.Orders.Include(x => x.ProductsDetails).Include(x=>x.UserData).ToList();
            
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            var orderToChange = _context.Orders.Where(x => x.Id == order.Id).FirstOrDefault();
            orderToChange = order;
            _context.SaveChanges();
        }
    }
}
