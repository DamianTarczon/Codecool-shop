using System.Collections.Generic;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Identity;

namespace Codecool.CodecoolShop.Daos.Implementations;

public interface IOrderDao
{
    public List<Order> GetAll();
    public Order AddOrder(Order order);

    public void UpdateOrder(Order order);
    public List<Order> FindOrdersByUser(IdentityUser user);
}