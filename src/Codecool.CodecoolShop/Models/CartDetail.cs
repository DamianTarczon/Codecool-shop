using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class CartDetail
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }

        public int Quantity { get; set; }
    }
}
