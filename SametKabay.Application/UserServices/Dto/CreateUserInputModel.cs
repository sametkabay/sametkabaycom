using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SametKabay.Core.Models;

namespace SametKabay.Application.UserServices.Dto
{
    public class CreateUserInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string UserName { get; set; }

        public string Password { get; set; }
        
        [Url]
        [MaxLength(1024)]
        public string PictureUrl { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string Surname { get; set; }

        [MaxLength(512)]
        public string About { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
        
    }
}
