using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBooking.Usermodel;

namespace FlightBooking.Controllers
{
    
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpPost]
        [Route("api/Booking/UserDetails")]
        public string TicketBooking([FromBody] BookingFlight Book)
        {
            using (F_BookingContext db = new F_BookingContext())
            {
                Random any = new Random();
                Book.Pnr = any.Next(100000, 999999);
                db.BookingFlight.Add(Book);
                db.SaveChanges();
                return "ticket Booked successfull";
            }
        }
        [HttpGet]
        [Route("api/Booking/History")]
        public List<BookingFlight> History()
        {
            using (F_BookingContext db = new F_BookingContext())
            {
                return db.BookingFlight.ToList();

            }
        }
        [HttpGet]
        [Route("api/Booking/HistorywithPNR")]
        public BookingFlight HistorywithPNR(int PNR)
        {
            using (F_BookingContext Db = new F_BookingContext())
            {
                var Ticket = Db.BookingFlight.Where(m => m.Pnr == PNR).FirstOrDefault();
                return Ticket;
                
            }
        }
        [HttpDelete]
        [Route("api/Booking/CancelTicket")]
        public string DeleletEmployee(int PNR)
        {
            using (F_BookingContext db = new F_BookingContext())
            {
                var Flg = db.BookingFlight.Find(PNR);
                db.BookingFlight.Remove(Flg);
                return "Your Ticket was Cancelled";
            }
        }
    }
}
