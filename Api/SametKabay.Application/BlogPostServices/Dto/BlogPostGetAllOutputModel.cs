using System;
using System.Collections.Generic;
using System.Text;
using SametKabay.Core.Models;

namespace SametKabay.Application.BlogPostServices.Dto
{
    public class BlogPostGetAllOutputModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string SafeTitle { get; set; }
        public string Detail { get; set; }
        public object PictureUrl { get; set; }
        public List<Category> Categories { get; set; }
        public CreatorUser CreatorUser { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
