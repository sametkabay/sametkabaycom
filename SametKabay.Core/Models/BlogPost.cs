using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SametKabay.Core.Interface;

namespace SametKabay.Core.Models
{
    public class BlogPost : IBaseEntity
    {
        #region Interface Property

        [Key]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public User ActivatedUser { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        #endregion Interface


        #region Special Property

        [Required]
        [MinLength(4)]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(64)]
        [Index("SafeTitle", IsClustered = true, IsUnique = true)]
        public string SafeTitle { get; set; }

        [MaxLength(256)]
        public string Detail { get; set; }

        public string Text { get; set; }

        [Url]
        [MaxLength(1024)]
        public string PictureUrl { get; set; }

        #endregion


        #region RELATIONSHIP

        public ICollection<BlogPostCategory> PostCategory { get; set; }

        public virtual User CreatorUser { get; set; }
        public virtual User ModifierUser { get; set; }
        public virtual User DeleterUser { get; set; }

        public ICollection<BlogPostTag> Tags { get; set; }

        public ICollection<BlogComment> Comments { get; set; }

        #endregion

    }
}
