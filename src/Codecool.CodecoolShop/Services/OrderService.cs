using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class OrderService
    {
        private readonly IOrderDaoMemory _orderDao;

        public OrderService(IOrderDaoMemory orderDao)
        {
            _orderDao = orderDao;
        }

        public Order GetOrder(int Id)
        {
            return _orderDao.GetAll().Where(x => x.Id == Id).FirstOrDefault();
        }

        public void AddOrder(Order order)
        {
            _orderDao.AddOrder(order);
        }
    }
}
