//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCEmpDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage="First name is Required")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "User-Name is Required")]
        public string Username { get; set; }

       // [DataType(DataType.PhoneNumber, ErrorMessage="Enter Valid Contact")]
     [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid phone number")]
        public string Mobile { get; set; }

        //[DataType(DataType.EmailAddress,ErrorMessage="E-mail is not valid")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = " Invalid E-mail Address")]
        public string Emailid { get; set; }

        [Required(ErrorMessage="Please select department")]
        public int DeptId { get; set; }

        
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

      //  [Compare("Password")]
      //  [DataType(DataType.Password, ErrorMessage="Password Doesn't match")] 
      //public string ConfirmPassword { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
