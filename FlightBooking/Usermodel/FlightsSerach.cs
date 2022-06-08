using System;
using System.Collections.Generic;

namespace FlightBooking.Usermodel
{
    public partial class FlightsSerach
    {
        public int FlightNo { get; set; }
        public string FlightName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string FDate { get; set; }
        public string FTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string Oneway { get; set; }
        public string RoundTrip { get; set; }
        public decimal? OnewayPrice { get; set; }
        public decimal? RoundtripPrice { get; set; }
        public decimal? DicountPrice { get; set; }
    }
}
