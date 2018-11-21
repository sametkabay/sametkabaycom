using System;
using System.Collections.Generic;
using System.Text;
using SametKabay.Core.Models;

namespace SametKabay.Core.Interface
{
    public interface IDeletable
    {
        User DeleterUser { get; set; }
        DateTime? DeletionDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
