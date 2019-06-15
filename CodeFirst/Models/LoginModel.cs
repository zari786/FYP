using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 6 character required")]
        public string Password { set; get; }
    }
}