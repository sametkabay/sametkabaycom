using System;
using SametKabay.Core.Models;

namespace SametKabay.Core.Interface
{
    public interface IModifiable
    {
        User ModifierUser { get; set; }
        DateTime? ModifyDate { get; set; }
    }
}