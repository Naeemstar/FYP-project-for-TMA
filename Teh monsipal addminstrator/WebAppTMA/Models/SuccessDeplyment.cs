using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    [Table("tbl_SuccessDeplyment")]
    public class SuccessDeplyment
    {
        [Key]
        public int Id { get; set; }
        public string project_Name { get; set; }
        public int project_Budget { get; set; }
        public string project_Status { get; set; }
        public int UserId { get; set; }
        public user User { get; set; }
    }
}