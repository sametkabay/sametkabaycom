using System;
using System.Collections.Generic;
using System.Text;

namespace SametKabay.Application
{
    public class PagedAndSortedInputDto : IPaged, ISorted
    {
        public string[] Tags { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Sorting { get; set; }
        public string[] Categories { get; set; }
    }
}
