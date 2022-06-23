﻿using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations;

public interface IOrderDaoMemory
{
    public List<Order> GetAll();
    public void AddOrder(Order order);

    public void UpdateOrder(Order order);
}