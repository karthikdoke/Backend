using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMode.Usermodel;

namespace UserMode.Controllers
{
    
    [ApiController]
    public class RegistationController : ControllerBase
    {


        [HttpGet]
        [Route("api/Registation/AlluserDetails")]
        public List<UserRegistation> AlluserDetails()
        {
            using (UserDbContext db=new UserDbContext())
            {
                return db.UserRegistation.ToList();

            }
        }
        [HttpPost]
        [Route("api/Registation/UserRegistation")]
        public int UserRegistation( UserRegistation  k)
        {
            using (UserDbContext db = new UserDbContext())
            {
                db.UserRegistation.Add(k);
                return db.SaveChanges();
            }
        }
    }
}
