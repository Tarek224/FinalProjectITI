using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    public class ProductTags
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductTags_ID { get; set; }
        public int? Product_ID { get; set; }
        public int? Tag_ID { get; set; }

        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

        [ForeignKey("Tag_ID")]
        public virtual Tags Tags { get; set; }
    }
}
