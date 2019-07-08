using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Models
{
    public class Customer
    {

        public Customer()
        {
            services = new List<Services>();
        }

        [Key]
        public int CustomerId { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Name is Required.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Email is Required.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" , ErrorMessage ="Enter a valid Email Address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 character required")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "Password and Confirm Password Does not Match")]
        public string ConfirmPassword { get; set; }

        public string JobTitle { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Phone Number is Required.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Please Select the Country.")]
        public string Country { get; set; }

        [ScaffoldColumn(false)]
        public bool isEmailVerified { get; set; }
        [ScaffoldColumn(false)]
        public System.Guid ActivationCode { get; set; }
        [ScaffoldColumn(false)]
        public string ResetPassword { get; set; }

        public List<Services> services { get; set; }

    }
}