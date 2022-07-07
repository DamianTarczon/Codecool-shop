using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Identity;
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

        public List<Order> FindOrdersByUser(IdentityUser user)
        {
            return _context.Orders.Include(x => x.ProductsDetails).Where(x => x.UserEmail == user.Email).ToList();
        }
        public List<Order> GetAll()
        {
            return _context.Orders.Include(x => x.ProductsDetails).Include(x=>x.UserData).ToList();
            
        }

        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            order = _context.Orders.OrderByDescending(x => x.Id).First();
            return order;
        }


        public void UpdateOrder(Order order)
        {
            _context.Orders.FirstOrDefault(x => x.Id == order.Id).PaymentStatus = order.PaymentStatus;
            _context.Orders.FirstOrDefault(x => x.Id == order.Id).UserEmail = order.UserEmail;
            _context.SaveChanges();
        }
    }
}
