using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.ViewModel
{
    public class RoleViewModel
    {
       
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
