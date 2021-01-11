using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Mines_Web.Models
{
    //First Name, Last Name, Sex, Age, State, Email Address, Username, and Password
    public class UserModel
    {
        [Required]
        [DisplayName("User Name")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 20 characters")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 20 characters")]
        public string Password { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(40, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(40, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$")]
        public string Email { get; set; }

        [Compare("Email")]
        public string CompareEmail { get; set; }

        [Required]
        public string State { get; set; }
        // 1 = male 0 = female

        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1, 130)]
        public int Age { get; set; }
    }
}