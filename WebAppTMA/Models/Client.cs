using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    [Table("tbl_Client")]
    public class Clientes
    { 
        [Key]
        public int Id { get; set; }
        [Required]
        public string clientType { get; set; }
        [Required]
        public string address{ get; set; }
        [Required]
        public string phone { get; set; }
    }
}