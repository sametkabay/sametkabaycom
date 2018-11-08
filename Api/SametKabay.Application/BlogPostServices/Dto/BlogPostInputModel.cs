using System.ComponentModel.DataAnnotations;

namespace SametKabay.Application.BlogPostServices.Dto
{
    public class BlogPostInputModel
    {
        [Required]
        public int CreatorUserId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        [MaxLength(100)]
        [Required]
        public string SafeTitle { get; set; }

        public string Detail { get; set; }

        public string Text { get; set; }
    }
    
}
