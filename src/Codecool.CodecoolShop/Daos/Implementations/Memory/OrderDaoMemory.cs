using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations.Memory
{
    public class OrderDaoMemory : IOrderDao
    {
        private List<Order> _data = new List<Order>();
        private static OrderDaoMemory _instance = null;

        public static OrderDaoMemory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new OrderDaoMemory();
            }

            return _instance;
        }

        public List<Order> GetAll()
        {
            return _data;
        }

        public void AddOrder(Order order)
        {
            order.Id = _data.Count + 1;
           _data.Add(order); 
        }

        public void UpdateOrder(Order order)
        {
            var orderToUpdateId = _data.Where(x => x.Id == order.Id).FirstOrDefault().Id;
            _data[orderToUpdateId - 1] = order;
        }
    }
}
