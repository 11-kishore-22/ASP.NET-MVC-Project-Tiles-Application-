using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ganesh_tiles.Model
{
    public class Register
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your Name.")]
        [DisplayName("Your Name")]
        public string Name {get; set; }


        [Required(ErrorMessage = "Please enter Username.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter Email.")]
        [DisplayName("Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter password.")]
        [DisplayName("Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter your location.")]
        [DisplayName("Enter your location")]
        public string Location { get; set; }
    }
}