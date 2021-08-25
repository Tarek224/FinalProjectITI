using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    public class Tags
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Tag_ID { get; set; }
        [Required, MaxLength(50)]
        public string Tag_Name { get; set; }
        public string Tag_Description { get; set; }

        public virtual ICollection<ProductTags> ProductTags { get; set; }

        public virtual ICollection<BlogTags> BlogTags { get; set; }
    }
}
