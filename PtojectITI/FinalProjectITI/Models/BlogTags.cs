using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    public class BlogTags
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogTags_ID { get; set; }
        public int? Blog_ID { get; set; }
        public int? Tag_ID { get; set; }

        [ForeignKey("Blog_ID")]
        public virtual Blog Blog { get; set; }

        [ForeignKey("Tag_ID")]
        public virtual Tags Tags { get; set; }
    }
}
