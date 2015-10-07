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
        
        [Required(ErrorMessage = "Employee FirstName is required")]
        public string Fname { get; set; }
        
        [Required(ErrorMessage = "Employee LastName is required")]
        public string Lname { get; set; }
        
        public string Department { get; set; }
        
        [Required(ErrorMessage="Contact NUmber is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage="Contact NUmber is not in valid format")]
        public string  Mobile { get; set; }

        [Required(ErrorMessage = "Email Id is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Emailid { get; set; }

        [Required(ErrorMessage="Password is Required")]
        
        public string Password { get; set; }

    }
}