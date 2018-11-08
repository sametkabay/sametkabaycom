using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JWT;
using JWT.Serializers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SametKabayApi.Model
{
    /// <summary>
    /// Token Validator
    /// </summary>
    public class TokenValidator
    {
        private static string _secretKey;
        private static IConfigurationRoot Configuration { get; set; }

        /// Token Validator Ctor
        public TokenValidator()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            _secretKey = Configuration.GetSection("Jwt:Key").Value;
        }

        public string IsValid(string token)
        {
            if (token.Length < 7) return null;
            token = token.Substring(7);
            bool result = false;

            //try
            //{
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            var json = decoder.Decode(token, _secretKey, verify: true);
            JwtParsedData data = new JwtParsedData();
            data = JsonConvert.DeserializeObject<JwtParsedData>(json);
            return data.UserId;
        }

        public class JwtParsedData
        {
            public string sub { get; set; }
            public string email { get; set; }
            public string jti { get; set; }
            public string Admin { get; set; }
            public string UserId { get; set; }
            public int exp { get; set; }
            public string iss { get; set; }
            public string aud { get; set; }
        }
    }
}
