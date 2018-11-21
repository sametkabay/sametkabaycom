using System;
using SametKabay.Core.Models;

namespace SametKabay.Core.Interface
{
    public interface ICreatable
    {
        User CreatorUser { get; set; }
        DateTime CreationDate { get; set; }
    }
}