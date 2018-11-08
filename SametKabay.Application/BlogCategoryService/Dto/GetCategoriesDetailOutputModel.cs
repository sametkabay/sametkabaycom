using System;
using System.Collections.Generic;
using System.Text;

namespace SametKabay.Application.BlogCategoryService.Dto
{
    public class GetCategoriesDetailOutputModel
    {
        public int Id { get; set; }
        public string SafeName { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Detail { get; set; }
        public int PostCount { get; set; }

    }
}
