using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    [Table("tbl_user")]
    public class user
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "user name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "email is required")]
        [Display(Name = "Email id")]
        [DataType(DataType.EmailAddress, ErrorMessage = "email is not valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "contact")]
        public string Contact { get; set; }

        [Display(Name = "profile")]
        public string profile { get; set; }
       
        public int RoleId { get; set; }
        public Rolee Role { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }


    }
}