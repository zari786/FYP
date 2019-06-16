using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class UserAccount
    {

        public UserAccount()
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
        //[RegularExpression(@"^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$", ErrorMessage = "Password must contain at least one letter, one number and more than six charaters")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 character required")]
        public string Password { get; set; }


        public string JobTitle { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Phone Number is Required.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public List<Services> services { get; set; }
    }
}