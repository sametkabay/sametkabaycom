using System;
using System.Collections.Generic;
using System.Text;

namespace SametKabay.Application.UserServices.Dto
{
    public class LoginInputModel
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
