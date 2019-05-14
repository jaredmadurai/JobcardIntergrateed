using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobcardInter.Models
{
    public class Supplier
    {
        [Key]
        [Display(Name="Supplier ID")]
        public int supplierId { get; set; }

        [Display(Name ="Supplier Name")]
        public string supplierName { get; set; }

        [Display(Name ="Supplier Contact")]
        public int supplierContact { get; set; }

        [Required(ErrorMessage = "*Please enter supplier email.")]
        [Display(Name = "Email Address:")]
        [EmailAddress]
        public string supplierEmail { get; set; }

        [Display(Name ="Products")]
        public string products { get; set; }
    }
}