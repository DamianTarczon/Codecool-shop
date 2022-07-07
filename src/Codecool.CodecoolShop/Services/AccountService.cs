using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Identity;

namespace Codecool.CodecoolShop.Services
{
    public class AccountService
    {
        private IOrderDao _orderDao;
        public AccountService(IOrderDao orderDao)
        {
            _orderDao = orderDao;
        }
        public List<Order> FindUserOrders(IdentityUser user)
        {
            return _orderDao.FindOrdersByUser(user);
        }
    }
}
