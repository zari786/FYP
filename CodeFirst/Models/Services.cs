using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Services
    {
        public Services()
        {
            customers = new List<Customer>();
            //admins = new List<Admin>();
        }
        public int ServicesId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="FlightNo is Required.")]        
        [RegularExpression(@"([A-Z]{2})([1-9]{1})([0-9]{1}([0-9]{1}[0-9]{1}))$", ErrorMessage ="Enter Valid FlightNo.")]
        public string FlightNo { get; set; }
	
	    [Required(AllowEmptyStrings =false, ErrorMessage ="RegistrationNo is Required.")]
        [RegularExpression(@"([A-Z]{2})([-])([A-Z]{4})$", ErrorMessage ="Enter Valid RegistrationNo.")]
        public string RegistrationNo { get; set; }
        public string Country { get; set; }
	
	    [Required(AllowEmptyStrings =false, ErrorMessage ="Arrival Route is Required.")]
        [RegularExpression(@"([A-Z]{3})$", ErrorMessage ="Enter Valid Arrival Route.")]
        public string ArrivalRoute { get; set; }

	    [Required(AllowEmptyStrings =false, ErrorMessage ="Arrival Destination is Required.")]
        [RegularExpression(@"([A-Z]{3})$", ErrorMessage ="Enter Valid Arrival Destination.")]
        public string ArrivalDestination { get; set; }
        public string Address { get; set; }

        [ScaffoldColumn(false)]
        public bool GroundHandling { get; set; }

	    [Range(1, 9999999, ErrorMessage = "Enter valid amount of MTOW")]
        public int MTOW { get; set; }
        public string PassengerHandling { get; set; }
        public string ATCFlightPlan { get; set; }
        public string LoadingOffLoading { get; set; }

        [ScaffoldColumn(false)]
        public bool Catering { get; set; }

        [Range(1, 1000, ErrorMessage = "Enter valid amount of Passenger")]
        public int NoOfPassenger { get; set; }
        public int NoOfMeal { get; set; }
        public string MealInformation { get; set; }

        [ScaffoldColumn(false)]
        public bool Refueling { get; set; }


        public string TypeOfFuel { get; set; }
        public int Quantity { get; set; }

        [ScaffoldColumn(false)]
        public bool OverFlyPermit { get; set; }

        public string Itenary { get; set; }
        public string EntryPoint { get; set; }
        public string ExitPoint { get; set; }

        [ScaffoldColumn(false)]
        public bool IsCompleted { get; set; }


        public List<Customer> customers { get; set; }
        //public List<Admin> admins { get; set; }
    }
}