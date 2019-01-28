using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CORED.Models
{
    public class ProfileVm
    {
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "Please enter a valid First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Please enter a valid Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Age:")]
        [Required(ErrorMessage = "Please enter a valid Age")]
        public int Age { get; set; }
    }
}
