using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    public enum Size
    {
        size_XL = 0,
        size_L = 1,
        size_S = 2,
        size_M = 4
    }
    public enum Color 
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Yellow = 4,
        Black = 8,
        White = 16
    }

    [Table("Product")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }
        [Required, MaxLength(50)]
        public string Product_Name { get; set; }
        public int? Category_ID { get; set; }
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Product_Price { get; set; }
        public int? Images_ID { get; set; }
        [Required]
        public Size? Product_Size { get; set; }
        public Color Product_Color { get; set; }

        [Column(TypeName = "date")]
        public DateTime Adding_Date { get; set; }
        public int Popularity { get; set; }
        public int Stored_Quantity { get; set; }

        [ForeignKey("Images_ID")]
        public virtual Images Images { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductTags> ProductTags{ get; set; } 
        public virtual ICollection<UserWishList> UserWishLists { get; set; }
    }
}
