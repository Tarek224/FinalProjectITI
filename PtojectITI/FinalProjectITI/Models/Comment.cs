using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Comment_ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Customer_ID { get; set; }

        public int Blog_ID { get; set; }

        [Column(TypeName ="date")]
        public DateTime Comment_Date { get; set; }

        [ForeignKey("Blog_ID")]
        public virtual Blog Blog { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual IdentityUser Customer { get; set; }
    }
}
