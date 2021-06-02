using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    public class Contact
    {      [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="this field is required")]
        public string Name{ get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Email{ get; set; }
        public string phone { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Message{ get; set; }
    }
}