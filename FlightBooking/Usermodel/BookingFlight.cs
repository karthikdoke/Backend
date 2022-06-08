using System;
using System.Collections.Generic;

namespace FlightBooking.Usermodel
{
    public partial class BookingFlight
    {
        public int BookingId { get; set; }
        public string UserName { get; set; }
        public string UEmail { get; set; }
        public string PassName { get; set; }
        public int PassAge { get; set; }
        public string Veg { get; set; }
        public string NonVeg { get; set; }
        public string SelectsSeats { get; set; }
        public int? Pnr { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}
