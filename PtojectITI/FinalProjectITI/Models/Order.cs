using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    [Table("Order")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }
        [Required]
        public string Customer_ID { get; set; }
        public int? Shipping_ID { get; set; }
        public int? Payment_ID { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Order_Total { get; set; }
        public int Order_Status { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual IdentityUser Customer { get; set; }
        [ForeignKey("Shipping_ID")]
        public virtual Shipping Shipping { get; set; }
        [ForeignKey("Payment_ID")]
        public virtual Payment Payment { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
