using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Services
    {
        public int ServicesId { get; set; }
        public string FlightNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Country { get; set; }
        public string ArrivalRoute { get; set; }
        public string ArrivalDestination { get; set; }
        public string Address { get; set; }

        [ScaffoldColumn(false)]
        public bool GroundHandling { get; set; }

        public int MTOW { get; set; }
        public string PassengerHandling { get; set; }
        public string ATCFlightPlan { get; set; }
        public string LoadingOffLoading { get; set; }

        [ScaffoldColumn(false)]
        public bool Catering { get; set; }

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
        public bool isCompleted { get; set; }

    }
}