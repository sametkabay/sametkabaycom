using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SametKabay.Core.Interface;

namespace SametKabay.Core.Models
{

    public class BlogCategory: IBaseEntity
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
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(64)]
        [Index("SafeName", IsClustered = true, IsUnique = true)]
        public string SafeName { get; set; }



        [MaxLength(256)]
        public string Detail { get; set; }

        [Url]
        [MaxLength(1024)]
        public string PictureUrl { get; set; }

        #endregion


        #region RELATIONSHIP

        public User CreatorUser { get; set; }
        public User ModifierUser { get; set; }
        public User DeleterUser { get; set; }

        public ICollection<BlogPostCategory> PostCategory { get; set; }

        public virtual BlogCategory Parent { get; set; }
        public ICollection<BlogCategory> Children { get; set; }


        //public ICollection<BlogCategoryTag> Tags { get; set; }


        #endregion

    }
}
