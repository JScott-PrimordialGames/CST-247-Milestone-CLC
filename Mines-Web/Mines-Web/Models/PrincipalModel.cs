using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mines_Web.Models
{
    public class PrincipalModel
    {
        [Required]
        [StringLength(40)]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 20 characters")]
        public string Password { get; set; }
    }
}