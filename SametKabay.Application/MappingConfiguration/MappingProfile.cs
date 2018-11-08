using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SametKabay.Application.BlogPostServices.Dto;
using SametKabay.Application.UserServices.Dto;
using SametKabay.Core.Models;

namespace SametKabay.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPostInputModel, BlogPost>();
            CreateMap<BlogPost, BlogPostOutputModel>();
            CreateMap<CreateUserInputModel, User>();
        }
    }
}
