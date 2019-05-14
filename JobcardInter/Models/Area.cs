using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobcardInter.Models
{
    public class Area
    {
        [Key]

        public int AreaID { get; set; }

        [Display(Name = "Area")]
        public string area { get; set; }
    }
}