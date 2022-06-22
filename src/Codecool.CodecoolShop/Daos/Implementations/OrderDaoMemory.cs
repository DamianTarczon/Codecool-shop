using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class OrderDaoMemory : IOrderDaoMemory
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
    }
}
