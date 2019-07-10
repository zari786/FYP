using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public List<Services> services { get; set; }
    }
}