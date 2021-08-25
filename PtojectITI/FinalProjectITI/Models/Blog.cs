using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key , DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Blog_ID { get; set; }

        [Required , MaxLength(100)]
        public string Blog_Title { get; set; }
        [Required]
        public string Blog_Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime Blog_Date { get; set; }
        public string Blog_Image { get; set; }
        public virtual ICollection<BlogTags> BlogTags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
