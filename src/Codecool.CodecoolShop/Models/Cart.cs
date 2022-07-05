using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public List<Product> CartDetails { get; set; } = new List<Product>();

    }
}
