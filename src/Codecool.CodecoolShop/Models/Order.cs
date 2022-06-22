using System;
using System.Collections.Generic;

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

        public Dictionary<Product,int> OrderedProducts { get; set; }

        public Order(DateTime createdDate)
        {
            _createdDate = createdDate;
        }

    }
}
