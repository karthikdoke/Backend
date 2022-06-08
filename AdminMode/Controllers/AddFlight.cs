using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminMode.Models;

namespace AdminMode.Controllers
{
   
    [ApiController]
    public class AddFlight : ControllerBase
    {
        [HttpGet]
        [Route("api/AddFlight/AllFlightDetails")]
        public List<AddDetailsOfAirLine> AllFlightDetails()
        {
            using (AdminDbContext db = new AdminDbContext())
            {
                return db.AddDetailsOfAirLine.ToList();

            }
        }
        [HttpPost]
        [Route("api/AddFlight/InsertFlight")]
        public int InsertFlight([FromBody] AddDetailsOfAirLine FlG)
        {
            using (AdminDbContext db = new AdminDbContext())
            {
                db.AddDetailsOfAirLine.Add(FlG);
                return db.SaveChanges();
            }
        }

       
    }
}
