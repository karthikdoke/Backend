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
    public class BlockFlightController : ControllerBase
    {
        [HttpDelete]
        [Route("api/BlockFlight/DeleteFlight")]
        public int DeleletEmployee(int FlightNo)
        {
            using (AdminDbContext db = new AdminDbContext())
            {
                var Flg = db.AddDetailsOfAirLine.Find(FlightNo);
                db.AddDetailsOfAirLine.Remove(Flg);
                return db.SaveChanges();
            }
        }
    }
}
