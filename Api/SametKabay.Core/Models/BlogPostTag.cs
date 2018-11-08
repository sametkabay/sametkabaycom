using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SametKabay.Core.Models
{
    public class BlogPostTag
    {
        #region Interface Property

        [Key]
        public int Id { get; set; }

        [DefaultValue(false)]

        public bool IsDeleted { get; set; }
        
        #endregion Interface


        #region Special Property

        [MinLength(2)]
        [MaxLength(32)]
        public string Text { get; set; }

        #endregion


        #region RELATIONSHIP



        #endregion

    }
}
