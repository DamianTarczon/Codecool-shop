using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Codecool.CodecoolShop.Models
{
    public class Product : BaseModel
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Currency { get; set; }
        [Required]
        [Column(TypeName = "decimal(20,2)")]
        public decimal DefaultPrice { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        [ForeignKey(nameof(ProductCategoryId))]
        public ProductCategory ProductCategory { get; set; }

        [Required]
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }


    }
}
