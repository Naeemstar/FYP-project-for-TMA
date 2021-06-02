using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    [Table("tbl_Role")]
    public class Rolee
    {
        [Key]
        public int RoleId { get; set; }
        [Required(ErrorMessage ="this field is required")]
        public string RoleName { get; set; }
    }
}