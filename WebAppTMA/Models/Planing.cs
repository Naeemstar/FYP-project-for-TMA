using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    [Table("tbl_planing")]
    public class Planing

    {
        [Key]
        public int Id { get; set; }
        public string planning_Type { get; set; }
        public int planning_Payment { get; set; }
        public int UserId { get; set; }
        public user User { get; set; }
        public int ClientId { get; set; }
        public Clientes Client { get; set; }

    
    }
    
}