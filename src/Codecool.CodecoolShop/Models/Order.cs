using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.DataProtection;

namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        protected DateTime _createdDate;
        public int Id { get; set; }
        public UserData UserData { get; set; }
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            private set{}
        }

        public PaymentStatusEnum PaymentStatus { get; set; }

        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        public Order(DateTime createdDate)
        {
            _createdDate = createdDate;
        }

        public void MakeOrderDetails(Dictionary<Product, int> orderedProducts)
        {
            foreach (var product in orderedProducts)
            {
                var singleOrderDetails = new OrderDetails(product.Key.Id, product.Key.Name, product.Key.DefaultPrice,
                    product.Value);
                OrderDetails.Add(singleOrderDetails);
            }
        }

    }
}
