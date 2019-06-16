using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Services
    {
        public int ServicesId { get; set; }
        public int FlightNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Country { get; set; }
        public string ArrivalRoute { get; set; }
        public string ArrivalDestination { get; set; }
        public string Address { get; set; }

        public bool GroundHandling { get; set; }

        public int MTOW { get; set; }
        public string PassengerHandling { get; set; }
        public string ATCFlightPlan { get; set; }
        public string LoadingOffLoading { get; set; }

        public bool Catering { get; set; }

        public int NoOfPassenger { get; set; }
        public int NoOfMeal { get; set; }
        public string MealInformation { get; set; }

        public bool Refueling { get; set; }

        public string TypeOfFuel { get; set; }
        public int Quantity { get; set; }

        public bool OverFlyPermit { get; set; }

        public string Itenary { get; set; }
        public string EntryPoint { get; set; }
        public string ExitPoint { get; set; }
    }
}