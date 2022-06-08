using System;
using System.Collections.Generic;

namespace UserMode.Usermodel
{
    public partial class UserRegistation
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Addresss { get; set; }
    }
}
