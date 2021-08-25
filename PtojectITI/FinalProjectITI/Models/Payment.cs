using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    public enum PaymentMethod
    {
        HandCash = 0,
        Paypal = 1,
    }
    [Table("Payment")]
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Payment_ID { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
