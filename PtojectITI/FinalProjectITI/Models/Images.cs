using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    public class Images
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Images_ID { get; set; }
        [Required , MaxLength(50)]
        public string Image1 { get; set; }
        [Required, MaxLength(50)]
        public string Image2 { get; set; }
        [Required, MaxLength(50)]
        public string Image3 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
