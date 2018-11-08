using SametKabay.Core.Models;

namespace SametKabay.Core.Interface
{
    public interface IActivable
    {
        User ActivatedUser { get; set; }
        bool IsActive { get; set; }
    }
}