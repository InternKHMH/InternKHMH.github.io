using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Intern_Management.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="please Provide UserName")]
        public string  UserName { get; set; }
        [Required(ErrorMessage ="please Provide Password")]
        public string Password { get; set;}
        public bool Remember { get; set; }
    }
}