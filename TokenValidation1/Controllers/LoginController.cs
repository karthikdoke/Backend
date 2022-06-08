using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenValidation1.IRepository;
using UserMode.Usermodel;

namespace TokenValidation1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Ilogin _login;

        public LoginController(Ilogin login)
        {
            _login = login;
        }
        [Route("validateLogin")]
        [HttpPost]

        public ActionResult validateLogin([FromBody] UserRegistation user1)
        {
            UserDbContext db = new UserDbContext();
            var user = db.UserRegistation.Where(m => m.UserName == user1.UserName && m.Password == user1.Password).FirstOrDefault();
            if (user == null)
            {
                return NotFound("User Not found please valid user name");
            }
            var token = _login.Builder(user.UserName);
            return Ok(new{ token=token,success=1});
        }
    }
}
