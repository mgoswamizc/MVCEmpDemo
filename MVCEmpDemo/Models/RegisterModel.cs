using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEmpDemo.Models
{
    public class RegisterModel : User
    {
        [Required]
        [Display(Name="Confirm password")]
        [Compare("Password",ErrorMessage="Password does not match!")]
        public string ConfirmPassword { get; set; }
    }
}