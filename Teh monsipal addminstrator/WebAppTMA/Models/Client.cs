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
        public int clientType { get; set; }
    }
}