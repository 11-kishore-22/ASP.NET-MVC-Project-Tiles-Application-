using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Ganesh_tiles.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please give the Employee Name")]
        [Display(Name ="Employee Name *")]
        public string emp_Name { get; set; }


        [Required(ErrorMessage = "Please give the Employee Email")]
        [Display(Name = "Employee Email *")]
        public string emp_Email { get; set; }


        [Required(ErrorMessage = "Please give the Age > 18")]
        [Display(Name = "Age *")]
        public string emp_Age { get; set; }


        [Required(ErrorMessage = "Please give the Employee Role")]
        [Display(Name = "Employee Role *")]
        public string emp_Dsgn { get; set; }

        [Display(Name = "Location *")]
        public string emp_Location { get; set; }

        [Display(Name = "Salary *")]
        public string emp_Salary { get; set; }
    }
}