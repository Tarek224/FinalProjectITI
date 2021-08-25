using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetails_ID { get; set; }
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        [Range(1,20)]
        public int Product_Quantity { get; set; }
        public Color Product_Color { get; set; }
        public Size? Product_Size { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total_price { get; set; }

        [ForeignKey("Order_ID")]
        public virtual Order Order { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
    }
}
