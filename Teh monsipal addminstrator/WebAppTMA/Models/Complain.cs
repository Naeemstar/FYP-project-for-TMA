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
        public string complainType { get; set; }
        public DateTime complaindata { get; set; }
        public int UserId { get; set; }
        public user User { get; set; }
    }
}