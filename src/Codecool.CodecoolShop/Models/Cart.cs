using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Codecool.CodecoolShop.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public List<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    }
}
