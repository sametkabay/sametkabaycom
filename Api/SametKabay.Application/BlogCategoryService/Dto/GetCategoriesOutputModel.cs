using System;
using System.Collections.Generic;
using System.Text;

namespace SametKabay.Application.BlogCategoryService.Dto
{
    public class GetCategoriesOutputModel
    {
        public int Id { get; set; }
        public string SafeName { get; set; }
        public string Name { get; set; }
    }
}
