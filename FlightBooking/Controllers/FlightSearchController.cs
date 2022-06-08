using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBooking.Usermodel;
using Microsoft.AspNetCore.Authorization;

namespace FlightBooking.Controllers
{
    
    [ApiController]
    public class FlightSearchController : ControllerBase
    {
        
        [Route("api/FlightSearch/AllFlights")]
        [HttpGet]
        public IEnumerable<FlightsSerach> Get()
        {
            using (var context = new F_BookingContext())
            {
                return context.FlightsSerach.ToList();

            }
        }
        
       
        [HttpGet]
        [Route("api/FlightSearch/FSerchBySourceDestination")]
        public FlightsSerach FSerchBySourceDestination( string Source, string Destination)
        {
            using (F_BookingContext Db = new F_BookingContext())
            {
                return Db.FlightsSerach.Where(m => m.Source == Source && m.Destination == Destination).FirstOrDefault();
            }
        }
       
    }
}
