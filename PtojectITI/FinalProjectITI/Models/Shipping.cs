using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    [Table("Shipping")]
    public class Shipping
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Shipping_ID { get; set; }
        [Required, EmailAddress , Display(Name ="Email")]
        public string Shipper_Email { get; set; }
        [Required, MaxLength(50) , Display(Name = "Name")]
        public string Shipper_Name { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        public int? Postal_Code { get; set; }
        public long Phone { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
