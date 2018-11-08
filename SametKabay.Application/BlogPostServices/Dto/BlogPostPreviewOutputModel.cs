using System;
using System.Collections.Generic;
using System.Text;

namespace SametKabay.Application.BlogPostServices.Dto
{
    public class BlogPostPreviewOutputModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string SafeTitle { get; set; }
        public object PictureUrl { get; set; }
    }
}
