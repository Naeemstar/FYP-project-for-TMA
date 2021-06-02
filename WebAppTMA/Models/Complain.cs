using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    [Table("tbl_Complain")]
    public class Complain
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="this field is required")]
       
        public string complainType { get; set; }
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "this field is required")]
        public DateTime complaindata { get; set; }
    }
}