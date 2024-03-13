using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ganesh_tiles.Model
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Customer Name")]
        public string cus_Name { get; set; }

        [Display(Name = "Brand")]
        public string pdt_Brand { get; set; }
        [Required]
        [Display(Name = "Design Type")]
        public string pdt_Type { get; set; }

        [Display(Name = "No.of Boxes")]

        public int pdt_Qty { get; set; }

        [Display(Name = "Each Box Price")]
        public string pdt_Perbox { get; set; }

        [Display(Name = "Total Cost")]
        public string total_Cost { get; set; }

        
       
    }
}