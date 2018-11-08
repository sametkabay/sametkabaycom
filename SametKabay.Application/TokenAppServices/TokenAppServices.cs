using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JWT;
using JWT.Serializers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SametKabay.Application.TokenAppServices
{
    public class TokenAppServices : ITokenAppServices
    {
        private string _secretKey;
        private static IConfigurationRoot Configuration { get; set; }

        public TokenAppServices()
        {
        }

        public string GetUserId(string token)
        {
            return "";
        }
    }
}
