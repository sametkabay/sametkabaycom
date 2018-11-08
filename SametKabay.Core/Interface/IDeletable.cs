using System;
using System.Collections.Generic;
using System.Text;

namespace SametKabay.Core.Interface
{
    public interface IDeletable
    {
        DateTime? DeletionDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
