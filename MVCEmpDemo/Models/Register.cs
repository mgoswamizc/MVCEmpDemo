using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEmpDemo.Models
{
    public class Register
    {
        public int Id { get; set; }
        
        public string Fname { get; set; }
        
        public string Lname { get; set; }
        [Required]
        public string Username { get; set; }
    
        public long  Mobile { get; set; }
           
        public string Emailid { get; set; }

        [Required]
        public string Password { get; set; }

    }
}