using System;
using System.ComponentModel.DataAnnotations;

namespace SametKabay.Core.Interface
{
    public interface IBaseEntity : IDeletable, IActivable, ICreatable, IModifiable
    {
        [Key]
        int Id { get; set; }
    }
}