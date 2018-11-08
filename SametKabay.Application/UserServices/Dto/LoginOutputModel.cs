using System;
using System.Collections.Generic;
using System.Text;

namespace SametKabay.Application.UserServices.Dto
{
    public class LoginOutputModel
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
