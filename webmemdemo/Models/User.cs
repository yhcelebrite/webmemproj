using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webmemdemo.Models
{
    [Serializable]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }
        [Required]
        [StringLength(32)]
        public string username { set; get; }

        public DateTime birthday { set; get; }
        [Required]
        [StringLength(32)]
        public string passward { get; set; }

        public decimal salary { set; get; }
    }
}