using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobcardInter.Models
{
    public class Technician
    {
        [Key]
        public int TechnicianID { get; set; }

        [Display(Name = "Full Name")]
        public string TechFullName { get; set; }

        [Display(Name = "Identity Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Area")]
        public string area { get; set; }

       // public virtual Area areas { get; set; }
    }
}