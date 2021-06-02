using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    [Table("tbl_Notification")]
    public class Notifaction
    {
        [Key]
        public int Id { get; set; }
        public string NotifiType { get; set; }
        public string NotifisubmitTo { get; set; }
        public string NotifisubmitFrom { get; set; }
        public int UserId { get; set; }
        public user User { get; set; }
    }
}